using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using Microsoft.Kinect;
using Microsoft.Speech.Recognition;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Microsoft.Speech.AudioFormat;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using NKH.MindSqualls;
using MonoBrick.EV3;

namespace KinectIntegrationForEV3NXT
{
    public partial class Form1 : Form
    {
        KinectSensor sensor;
        SpeechRecognitionEngine speechRecognizer;

        NxtBrick nxt;
        Brick<Sensor, Sensor, Sensor, Sensor> ev3;

        DispatcherTimer readyTimer;

        bool isDriving = false;
        bool isManipulating = false;

        Skeleton[] skeletons;
        byte[] colorBytes;

        string statusNXT = "disconnected";
        string statusKinect = "initializing";

        double deadzone = 0.4; //EDITABLE - Percent of threshold that is ignored and returns 0 as the power
        double maxPower = 85; //EDITABLE - Maximum allowed power

        double percentL = 0;
        double percentR = 0;
        double distance = 0;
        double powerL = 0;
        double powerR = 0;

        string name = "none";

        bool liftUp = false;
        bool liftDown = false;
        bool tiltUp = false;
        bool tiltDown = false;

        bool isCustom = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region Initialization

        private void timerLoader_Tick(object sender, EventArgs e)
        {
            this.timerLoader.Enabled = false;
            sensor = KinectSensor.KinectSensors.FirstOrDefault();
            if (sensor == null)
            {
                this.timerKinectConnection.Enabled = true;
                return;
            }

            if (sensor.Status != KinectStatus.Connected)
            {
                this.timerKinectConnection.Enabled = true;
                return;
            }

            loadKinect();
        }

        private void loadKinect()
        {
            sensor.Start();

            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
            sensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);

            //sensor.DepthStream.Enable(DepthImageFormat.Resolution1    1x480Fps30);

            sensor.SkeletonStream.Enable();
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(sensor_SkeletonFrameReady);

            //sensor.ElevationAngle = 10;

            InitializeSpeechRecognition();

            this.pictureKinect.BackgroundImage = Properties.Resources.kinect_blue;
            this.statusKinect = "Connected";
            refreshStat();

            this.timerHideStatKinect.Enabled = true;
        }

        private void timerKinectConnection_Tick(object sender, EventArgs e)
        {
            sensor = KinectSensor.KinectSensors.FirstOrDefault();

            if (sensor == null)
            {
                this.timerKinectConnection.Enabled = true;
            }
            else if (sensor.Status != KinectStatus.Connected)
            {
                this.timerKinectConnection.Enabled = true;
                this.labelStatus.Text = sensor.Status.ToString();
                this.pictureKinect.BackgroundImage = Properties.Resources.kinect_yellow;
            }
            else
            {
                loadKinect();
                this.timerKinectConnection.Enabled = false;
            }
        }

        private void buttonBluetooth_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelStatusNxt.Text = "Attempting to connect. . .";
                this.labelStatusNxt.Refresh();

                if (trackBar1.Value == 0)
                {
                    this.nxt = new NxtBrick(NxtCommLinkType.Bluetooth, (byte)Convert.ToInt32(textBoxComPort.Text));
                    this.nxt.Connect();
                    this.nxt.PlayTone(8000, 500);
                    this.pictureNXT.BackgroundImage = Properties.Resources.nxt_green;
                    this.nxt.MotorB = new NxtMotor();
                    this.nxt.MotorC = new NxtMotor();

                    if (nxt.Programs.Contains("KIFS.rxe"))
                    {
                        nxt.Program = "KIFS.rxe";
                        this.isCustom = true;
                    }

                    name = nxt.Name;
                }
                else
                {
                    this.ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("COM" + textBoxComPort.Text);
                    this.ev3.Connection.Open();
                    this.ev3.PlayTone(5, (ushort) 8000, (ushort) 500);
                    this.pictureNXT.BackgroundImage = Properties.Resources.nxt_green;

                    if (ev3.GetRunningProgram().Contains("kifen"))
                        this.isCustom = true;

                    name = "EV3";
                }

                this.labelStatusNxt.Text = "Connected to " + name;
                this.timerHideStatNxt.Enabled = true;
                this.timerUpdateNxt.Enabled = true;
            }
            catch (Exception enxt)
            {
                Console.Write(enxt.StackTrace);
                this.labelStatusNxt.Text = "Disconnected";
            }
        }

        #endregion

        #region Gesture Processing

        void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            double powL = powerL;
            double powR = powerR;
            bool lUp = liftUp;
            bool lDown = liftDown;
            bool tUp = tiltUp;
            bool tDown = tiltDown;

            using (var skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame == null)
                    return;

                if (skeletons == null ||
                    skeletons.Length != skeletonFrame.SkeletonArrayLength)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }

                skeletonFrame.CopySkeletonDataTo(skeletons);
            }

            Skeleton closestSkeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                                                .OrderBy(s => s.Position.X) //Switched X & Z to do left and right
                                                .FirstOrDefault();

            if (closestSkeleton == null)
            {
                this.labelDriver.Visible = false;
                this.labelDriver.Visible = false;
                this.overlayBarL.Visible = false;
                this.overlayBarR.Visible = false;
                this.labelLMotors.Visible = false;
                this.labelRMotors.Visible = false;
                this.overlayDeadzoneL.Visible = false;
                this.overlayDeadzoneR.Visible = false;
                this.overlayPowL.Visible = false;
                this.overlayPowR.Visible = false;

                this.labelManipulator.Visible = false;

                this.labelStatus.Text = "Tracking 0/2";
                this.pictureKinect.BackgroundImage = Properties.Resources.kinect_blue;
                return;
            }
            else
            {
                this.labelDriver.Visible = true;
                //this.overlayBarL.Visible = true;
                //this.overlayBarR.Visible = true;
                this.labelLMotors.Visible = true;
                this.labelRMotors.Visible = true;
                //this.overlayDeadzoneL.Visible = true;
                //this.overlayDeadzoneR.Visible = true;
                //this.overlayPowL.Visible = true;
                //this.overlayPowR.Visible = true;

                this.labelStatus.ForeColor = System.Drawing.Color.Green;
                this.pictureKinect.BackgroundImage = Properties.Resources.kinect_green;
            }
            Skeleton[] skeleSorted = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                                                .OrderBy(s => s.Position.X).ToArray();
            Skeleton secondSkeleton = null;

            if (skeleSorted.Length >= 2)
                secondSkeleton = skeleSorted[1];

            var head = closestSkeleton.Joints[JointType.Head];
            var rightHand = closestSkeleton.Joints[JointType.HandRight];
            var leftHand = closestSkeleton.Joints[JointType.HandLeft];

            if (head.TrackingState == JointTrackingState.NotTracked ||
                rightHand.TrackingState == JointTrackingState.NotTracked ||
                leftHand.TrackingState == JointTrackingState.NotTracked)
            {
                //Don't have a good read on the joints so we cannot process gestures
                this.labelStatus.Text = "Tracking Error";
                return;
            }
            this.labelStatus.Text = "Tracking 1/2";

            ProcessDriveGestures(closestSkeleton);

            LabelDriver(closestSkeleton, true);

            if (secondSkeleton == null)
            {
                this.labelManipulator.Visible = false;
                this.overlayTilt.Visible = false;
                this.overlayLift.Visible = false;
            }
            else
            {
                this.labelManipulator.Visible = true;
                this.overlayTilt.Visible = true;
                this.overlayLift.Visible = true;
                this.labelStatus.Text = "Tracking 2/2";
                ProcessManipGestures(secondSkeleton);
                LabelManipulator(secondSkeleton, true);
            }

            if (powerL != powL || powerR != powR || tiltDown != tDown || tiltUp != tUp || liftDown != lDown || liftUp != lUp)
                updateBrick();

            Console.Out.WriteLine("Processed skeletons");
        }

        private void ProcessDriveGestures(Skeleton skeleton)
        {
            Joint waist = skeleton.Joints[JointType.HipCenter];
            Joint shoulderC = skeleton.Joints[JointType.ShoulderCenter];
            Joint shoulderL = skeleton.Joints[JointType.ShoulderLeft];
            Joint shoulderR = skeleton.Joints[JointType.ShoulderRight];
            Joint elbowL = skeleton.Joints[JointType.ElbowLeft];
            Joint elbowR = skeleton.Joints[JointType.ElbowRight];
            Joint head = skeleton.Joints[JointType.Head];
            Joint leftHand = skeleton.Joints[JointType.HandLeft];
            Joint rightHand = skeleton.Joints[JointType.HandRight];

            distance = (float) Math.Sqrt(Math.Pow(shoulderL.Position.X - elbowL.Position.X, 2) + 
                Math.Pow(shoulderL.Position.Y - elbowL.Position.Y, 2) +
                Math.Pow(shoulderL.Position.Z - elbowL.Position.Z, 2));

            percentL = (leftHand.Position.Y - elbowL.Position.Y) / distance;
            percentR = (rightHand.Position.Y - elbowR.Position.Y) / distance;

            if (isDriving)
            {
                if (percentL < deadzone * -1)
                    this.powerL = Math.Floor((percentL + deadzone) * 60 / 10) * 10;
                else if (percentL > deadzone)
                    this.powerL = Math.Floor((percentL - deadzone) * 60 / 10) * 10;
                else
                    this.powerL = 0;

                if (percentR < deadzone * -1)
                    this.powerR = Math.Floor((percentR + deadzone) * 60 / 10) * 10;
                else if (percentR > deadzone)
                    this.powerR = Math.Floor((percentR - deadzone) * 60 / 10) * 10;
                else
                    this.powerR = 0;
            }
            else
            {
                this.powerL = 0;
                this.powerR = 0;
            }

            this.labelLMotors.Text = "L: " + powerL;
            this.labelRMotors.Text = "R: " + powerR;
        }

        private void ProcessManipGestures(Skeleton skeleton)
        {
            Joint elbowL = skeleton.Joints[JointType.ElbowLeft];
            Joint elbowR = skeleton.Joints[JointType.ElbowRight];
            Joint handL = skeleton.Joints[JointType.HandLeft];
            Joint handR = skeleton.Joints[JointType.HandRight];
            Joint shoulderL = skeleton.Joints[JointType.ShoulderLeft];
            Joint shoulderR = skeleton.Joints[JointType.ShoulderRight];

            float distance = (float)Math.Sqrt(Math.Pow(shoulderL.Position.X - elbowL.Position.X, 2) +
                Math.Pow(shoulderL.Position.Y - elbowL.Position.Y, 2) +
                Math.Pow(shoulderL.Position.Z - elbowL.Position.Z, 2));

            if(isManipulating)
            {
                percentL = (handL.Position.Y - elbowL.Position.Y) / distance;
                percentR = (handR.Position.Y - elbowR.Position.Y) / distance;

                this.label1.Visible = true;
                this.label1.Text = percentL + "%";

                if (percentL < deadzone * -1)
                {
                    liftUp = false;
                    liftDown = true;
                }
                else if (percentL > deadzone)
                {
                    liftUp = true;
                    liftDown = false;
                }
                else
                {
                    liftUp = false;
                    liftDown = false;
                }

                if (percentR < deadzone * -1)
                {
                    tiltUp = false;
                    tiltDown = true;
                }
                else if (percentR > deadzone)
                {
                    tiltUp = true;
                    tiltDown = false;
                }
                else
                {
                    tiltUp = false;
                    tiltDown = false;
                }
            }
            else
            {
                liftUp = false;
                liftDown = false;
                tiltUp = false;
                tiltUp = false;
            }
        }

        #endregion

        #region Image Rendering & UI

        private void LabelDriver(Skeleton skeleton, bool isTracked)
        {
            Joint head = skeleton.Joints[JointType.Head];
            Joint handL = skeleton.Joints[JointType.HandLeft];
            Joint handR = skeleton.Joints[JointType.HandRight];
            Joint elbowL = skeleton.Joints[JointType.ElbowLeft];
            Joint elbowR = skeleton.Joints[JointType.ElbowRight];
            Joint chest = skeleton.Joints[JointType.Spine];
            Joint waist = skeleton.Joints[JointType.HipCenter];
            Joint shoulder = skeleton.Joints[JointType.ShoulderCenter];
            Joint shoulderL = skeleton.Joints[JointType.ShoulderLeft];

            //Driver tag
            if (head != null)
                this.labelDriver.SetBounds((int) KinectX(head), (int) KinectY(head) - 4,
                    this.labelDriver.Bounds.Width, this.labelDriver.Bounds.Height);
            if (this.isDriving && isTracked)
                this.labelDriver.BackColor = System.Drawing.Color.DeepSkyBlue;
            else if (isTracked)
                this.labelDriver.BackColor = System.Drawing.Color.Black;
            else
                this.labelDriver.BackColor = System.Drawing.Color.Red;

            //Left Bar
            double rTop = (Math.Abs(KinectY(handL) - KinectY(elbowL)) * distance) / (handL.Position.Y - elbowL.Position.Y);
            this.overlayBarL.SetBounds((int)KinectX(elbowL) - 50, (int)(KinectY(elbowL) - rTop), overlayBarL.Bounds.Width, (int)rTop * 2);

            if (isDriving && powerL != 0)
                overlayBarL.BackColor = System.Drawing.Color.Chartreuse;
            else if (isDriving)
                overlayBarL.BackColor = System.Drawing.Color.DeepSkyBlue;
            else
                overlayBarL.BackColor = System.Drawing.Color.DarkGray;

            //Left Power
            this.labelLMotors.SetBounds((int) overlayBarL.Bounds.X - labelLMotors.Width - overlayBarL.Width,
                (int) KinectY(elbowL) + (labelLMotors.Height / 2), labelLMotors.Bounds.Width, labelLMotors.Bounds.Height);

            //Left Deadzone
            this.overlayDeadzoneL.SetBounds((int)KinectX(elbowL) - 50,
                (int)(Math.Abs(rTop / percentL) * deadzone + KinectX(elbowL)),
                overlayDeadzoneL.Bounds.Width, (int)(Math.Abs(rTop / percentL) * deadzone * 2));

            if (isDriving && powerL == 0)
                overlayDeadzoneL.BackColor = System.Drawing.Color.Chartreuse;
            else if (isDriving)
                overlayDeadzoneL.BackColor = System.Drawing.Color.DeepSkyBlue;
            else
                overlayDeadzoneL.BackColor = System.Drawing.Color.DarkGray;

            //Left Indicator
            this.overlayPowL.SetBounds((int)KinectX(elbowL) - 50, (int)KinectY(handL), overlayPowL.Width, overlayPowL.Height);

            //Right Bar
            this.overlayBarR.SetBounds((int)KinectX(elbowR), (int)(KinectY(elbowR) - rTop), overlayBarR.Bounds.Width, (int)rTop * 2);

            if (isDriving && powerR != 0)
                overlayBarR.BackColor = System.Drawing.Color.Chartreuse;
            else if (isDriving)
                overlayBarR.BackColor = System.Drawing.Color.DeepSkyBlue;
            else
                overlayBarR.BackColor = System.Drawing.Color.DarkGray;

            //Right Power
            this.labelRMotors.SetBounds((int)KinectX(elbowR) - 50 + labelRMotors.Width - (this.overlayBarR.Width * 2),
                (int)KinectY(elbowL) + (labelRMotors.Height / 2), labelRMotors.Bounds.Width, labelRMotors.Bounds.Height);

            //Right Deadzone
            this.overlayDeadzoneR.SetBounds((int)KinectX(elbowR) - 50,
                (int)(Math.Abs(rTop / percentR) * deadzone + KinectX(elbowR)),
                overlayDeadzoneR.Bounds.Width, (int)(Math.Abs(rTop / percentR) * deadzone * 2));

            if (isDriving && powerR == 0)
                overlayDeadzoneR.BackColor = System.Drawing.Color.Chartreuse;
            else if (isDriving)
                overlayDeadzoneR.BackColor = System.Drawing.Color.DeepSkyBlue;
            else
                overlayDeadzoneR.BackColor = System.Drawing.Color.DarkGray;

            //Right Indicator
            this.overlayPowR.SetBounds((int)KinectX(elbowR) - 50, (int)KinectY(handR), overlayPowR.Width, overlayPowR.Height);

            //Arrange
            this.labelLMotors.BringToFront();
            this.overlayBarL.SendToBack();
            this.labelRMotors.BringToFront();
            this.overlayBarR.SendToBack();
        }

        private void LabelManipulator(Skeleton skeleton, bool isTracked)
        {
            Joint head = skeleton.Joints[JointType.Head];
            Joint handL = skeleton.Joints[JointType.HandLeft];
            Joint handR = skeleton.Joints[JointType.HandRight];
            Joint elbowL = skeleton.Joints[JointType.ElbowLeft];
            Joint elbowR = skeleton.Joints[JointType.ElbowRight];

            //Manipulator tag
            if (head != null)
                this.labelManipulator.SetBounds((int) KinectX(head), (int) KinectY(head),
                    this.labelManipulator.Bounds.Width, this.labelManipulator.Bounds.Height);
            if (this.isManipulating && isTracked)
                this.labelManipulator.BackColor = System.Drawing.Color.DeepSkyBlue;
            else if (isTracked)
                this.labelManipulator.BackColor = System.Drawing.Color.White;
            else
                this.labelManipulator.BackColor = System.Drawing.Color.Red;

            //Left Indicator (tilt)
            this.overlayTilt.SetBounds((int) KinectX(elbowL), (int) (KinectY(elbowL) + (overlayTilt.Height / 2)), 
                overlayTilt.Width, overlayTilt.Height);

            if (tiltUp)
                this.overlayTilt.BackgroundImage = Properties.Resources.Circle_up;
            else if (tiltDown)
                this.overlayTilt.BackgroundImage = Properties.Resources.Circle_down;
            else
                this.overlayTilt.BackgroundImage = Properties.Resources.Circle_idle;

            //Right Indicator (lift)
            this.overlayLift.SetBounds((int) KinectX(elbowR) - overlayLift.Width, (int) (KinectY(elbowR) + (overlayLift.Height / 2)), 
                overlayLift.Width, overlayLift.Height);

            if (liftUp)
                this.overlayLift.BackgroundImage = Properties.Resources.Circle_up;
            else if (liftDown)
                this.overlayLift.BackgroundImage = Properties.Resources.Circle_down;
            else
                this.overlayLift.BackgroundImage = Properties.Resources.Circle_idle;
        }

        void sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var image = e.OpenColorImageFrame())
            {
                if (image == null)
                    return;

                if (colorBytes == null ||
                    colorBytes.Length != image.PixelDataLength)
                {
                    colorBytes = new byte[image.PixelDataLength];
                }

                image.CopyPixelDataTo(colorBytes);

                byte[] pixeldata = new byte[image.PixelDataLength];
                image.CopyPixelDataTo(pixeldata);
                Bitmap bmap = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                BitmapData bmapdata = bmap.LockBits(
                    new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.WriteOnly,
                    bmap.PixelFormat);
                IntPtr ptr = bmapdata.Scan0;
                Marshal.Copy(pixeldata, 0, ptr, image.PixelDataLength);
                bmap.UnlockBits(bmapdata);
                videoImage.Image = bmap;
            }
            //Console.Out.WriteLine("Rendered image");
        }

        #endregion

        #region Speech Recognition

        private static RecognizerInfo GetKinectRecognizer()
        {
            Func<RecognizerInfo, bool> matchingFunc = r =>
            {
                string value;
                r.AdditionalInfo.TryGetValue("Kinect", out value);
                return "True".Equals(value, StringComparison.InvariantCultureIgnoreCase) && "en-US".Equals(r.Culture.Name, StringComparison.InvariantCultureIgnoreCase);
            };
            return SpeechRecognitionEngine.InstalledRecognizers().Where(matchingFunc).FirstOrDefault();
        }

        private void InitializeSpeechRecognition()
        {
            RecognizerInfo ri = GetKinectRecognizer();
            if (ri == null)
            {
                MessageBox.Show(
                    @"There was a problem initializing Speech Recognition.
Ensure you have the Microsoft Speech SDK installed.",
                    "Failed to load Speech SDK");
                return;
            }

            try
            {
                speechRecognizer = new SpeechRecognitionEngine(ri.Id);
            }
            catch
            {
                MessageBox.Show(
                    @"There was a problem initializing Speech Recognition.
Ensure you have the Microsoft Speech SDK installed and configured.",
                    "Failed to load Speech SDK");
            }

            var phrases = new Choices();
            phrases.Add("kifen toggle drive");
            phrases.Add("kifen toggle manip");
            phrases.Add("kifen ready flag");
            phrases.Add("kifen idle flag");
            phrases.Add("kifen spin flag");
            phrases.Add("kifen stop spin");
            phrases.Add("kifen do a barrel roll");
            phrases.Add("e stop");

            var gb = new GrammarBuilder();
            //Specify the culture to match the recognizer in case we are running in a different culture.                                 
            gb.Culture = ri.Culture;
            gb.Append(phrases);

            // Create the actual Grammar instance, and then load it into the speech recognizer.
            var g = new Grammar(gb);

            speechRecognizer.LoadGrammar(g);
            speechRecognizer.SpeechRecognized += SreSpeechRecognized;
            speechRecognizer.SpeechHypothesized += SreSpeechHypothesized;
            speechRecognizer.SpeechRecognitionRejected += SreSpeechRecognitionRejected;

            this.readyTimer = new DispatcherTimer();
            this.readyTimer.Tick += this.ReadyTimerTick;
            this.readyTimer.Interval = new TimeSpan(0, 0, 4);
            this.readyTimer.Start();

            this.pictureSpeech.BackgroundImage = Properties.Resources.voice_blue;

        }
        private void ReadyTimerTick(object sender, EventArgs e)
        {
            this.StartSpeechRecognition();
            this.readyTimer.Stop();
            this.readyTimer.Tick -= ReadyTimerTick;
            this.readyTimer = null;
        }

        private void StartSpeechRecognition()
        {
            if (sensor == null || speechRecognizer == null)
                return;

            var audioSource = this.sensor.AudioSource;
            audioSource.BeamAngleMode = BeamAngleMode.Adaptive;
            var kinectStream = audioSource.Start();

            speechRecognizer.SetInputToAudioStream(
                    kinectStream, new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);

        }

        void SreSpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Trace.WriteLine("\nSpeech Rejected, confidence: " + e.Result.Confidence);
        }

        void SreSpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Trace.Write("\rSpeech Hypothesized: \t{0}", e.Result.Text);
        }

        void SreSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //This first release of the Kinect language pack doesn't have a reliable confidence model, so 
            //we don't use e.Result.Confidence here.
            if (e.Result.Confidence < 0.70)
            {
                Trace.WriteLine("\nSpeech Rejected filtered, confidence: " + e.Result.Confidence);
                return;
            }

            Trace.WriteLine("\nSpeech Recognized, confidence: " + e.Result.Confidence + ": \t{0}", e.Result.Text);

            this.labelSpeech.Text = e.Result.Text;
            this.pictureSpeech.BackgroundImage = Properties.Resources.voice_green;

            if (e.Result.Text == "kifen start driving")
                this.isDriving = true;
            if (e.Result.Text == "kifen stop driving")
                this.isDriving = false;
            if (e.Result.Text == "kifen start manipulating")
                this.isManipulating = true;
            if (e.Result.Text == "kifen stop manipulating")
                this.isManipulating = false;
            if (e.Result.Text == "kifen toggle drive")
            {
                if (isDriving)
                    isDriving = false;
                else
                    isDriving = true;
            }
            if (e.Result.Text == "kifen toggle manip")
            {
                if (isManipulating)
                    isManipulating = false;
                else
                    isManipulating = true;
            }
            if (nxt != null && nxt.IsConnected)
            {
                if (e.Result.Text == "kifen ready flag")
                {
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "S");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "9");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                }
                if (e.Result.Text == "kifen idle flag")
                {
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "S");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                }
                if (e.Result.Text == "kifen spin flag")
                {
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "F");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "8");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                }
                if (e.Result.Text == "kifen stop spin")
                {
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "F");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                    this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, "z");
                }
            }
            if (e.Result.Text == "e stop")
            {
                this.isDriving = false;
                this.isManipulating = false;
                this.powerL = 0;
                this.powerR = 0;
                this.tiltDown = false;
                this.tiltUp = false;
                this.liftDown = false;
                this.liftUp = false;
                updateBrick();
            }

            this.timerSpeech.Enabled = true;

            refreshStat();
        }

        private void timerSpeech_Tick(object sender, EventArgs e)
        {
            this.labelSpeech.Text = "LISTENING . . .";
            this.pictureSpeech.BackgroundImage = Properties.Resources.voice_blue;
        }

        #endregion

        #region NXT/EV3 Managment
        private void updateBrick()
        {
            if (trackBar1.Value == 0)
                updateNxt();
            else
                updateEv3();
        }

        private void updateNxt()
        {
            if (nxt == null || !nxt.IsConnected)
                return;

            //Robots that aren't Susan
            if (!isCustom)
            {
                nxt.MotorB.Run((sbyte)powerL, 0);
                nxt.MotorC.Run((sbyte)powerR, 0);
                return;
            }

            //Tilt bucket
            if (tiltUp)
            {
                this.nxt.MotorB.Run(80, 0);
                this.nxt.MotorC.Run(80, 0);
            }
            else if (tiltDown)
            {
                this.nxt.MotorB.Run(-80, 0);
                this.nxt.MotorC.Run(-80, 0);
            }
            else
            {
                this.nxt.MotorB.Run(0, 0);
                this.nxt.MotorC.Run(0, 0);
            }

            string msgB;

            if (liftUp)
                msgB = "B80";
            else if (liftDown)
                msgB = "b80";
            else
                msgB = "B00";

            //this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, Encoding.ASCII.GetBytes(msgB));

            //Drive powers
            string msgL;

            if (powerL < 0)
                if (powerL > -10)
                    msgL = "l0" + Math.Abs(powerL);
                else
                    msgL = "l" + Math.Abs(powerL);
            else if (powerL < 10)
                msgL = "L0" + powerL;
            else
                msgL = "L" + powerL;

            System.Threading.Thread.Sleep(60);

            this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, Encoding.ASCII.GetBytes(msgL));

            string msgR;

            if (powerR < 0)
                if (powerR > -10)
                    msgR = "r0" + Math.Abs(powerR);
                else
                    msgR = "r" + Math.Abs(powerR);
            else if (powerR < 10)
                msgR = "R0" + powerR;
            else
                msgR = "R" + powerR;

            System.Threading.Thread.Sleep(60);

            this.nxt.CommLink.MessageWrite(NxtMailbox.Box0, Encoding.ASCII.GetBytes(msgR));

            Console.Out.WriteLine("Done a send of " + msgB + msgL + msgR);
        }

        private void updateEv3()
        {
            if (ev3 == null || !ev3.Connection.IsConnected)
                return;

            //Robots that aren't customized
            if (!isCustom)
            {
                if (powerL == 0)
                    ev3.MotorB.Off();
                else
                    ev3.MotorB.On((sbyte)powerL);

                if (powerR == 0)
                    ev3.MotorC.Off();
                else
                    ev3.MotorC.On((sbyte)powerR);
                return;
            }

            int n80 = -80;

            //Tilt bucket
            if (tiltUp)
            {
                ev3.MotorB.SetPower(80);
                ev3.MotorC.SetPower(80);
            }
            else if (tiltDown)
            {
                ev3.MotorB.SetPower((byte) n80);
                ev3.MotorC.SetPower((byte) n80);
            }
            else
            {
                ev3.MotorB.SetPower(0);
                ev3.MotorC.SetPower(0);
            }

            string msgB;

            if (liftUp)
                msgB = "B80";
            else if (liftDown)
                msgB = "b80";
            else
                msgB = "B00";

            ev3.Mailbox.Send("kifen_B", Encoding.ASCII.GetBytes(msgB));

            //Drive powers
            string msgL;

            if (powerL < 0)
                if (powerL > -10)
                    msgL = "l0" + Math.Abs(powerL);
                else
                    msgL = "l" + Math.Abs(powerL);
            else if (powerL < 10)
                msgL = "L0" + powerL;
            else
                msgL = "L" + powerL;

            ev3.Mailbox.Send("kifen_L", Encoding.ASCII.GetBytes(msgL));

            string msgR;

            if (powerR < 0)
                if (powerR > -10)
                    msgR = "r0" + Math.Abs(powerR);
                else
                    msgR = "r" + Math.Abs(powerR);
            else if (powerR < 10)
                msgR = "R0" + powerR;
            else
                msgR = "R" + powerR;

            ev3.Mailbox.Send("kifen_R", Encoding.ASCII.GetBytes(msgR));
        }

        private void btnTglDrive_Click(object sender, EventArgs e)
        {
            if (isDriving)
                isDriving = false;
            else
                isDriving = true;
        }

        private void btnTglManip_Click(object sender, EventArgs e)
        {
            if (isManipulating)
                isManipulating = false;
            else
                isManipulating = true;
        }

        private void btnEStop_Click(object sender, EventArgs e)
        {
            this.isDriving = false;
            this.isManipulating = false;
            this.powerL = 0;
            this.powerR = 0;
            this.tiltDown = false;
            this.tiltUp = false;
            this.liftDown = false;
            this.liftUp = false;
            updateBrick();
        }

        private void timerHideStatKinect_Tick(object sender, EventArgs e)
        {
            timerHideStatKinect.Enabled = false;
            labelStatus.Visible = false;
        }

        private void timerHideStatNxt_Tick(object sender, EventArgs e)
        {
            timerHideStatNxt.Enabled = false;
            labelStatusNxt.Visible = false;
        }

        private void timerUpdateNxt_Tick(object sender, EventArgs e)
        {
            this.timerUpdateNxt.Enabled = true;
            updateBrick();
            //this.pictureNXT.BackgroundImage = Properties.Resources.nxt_red;
            //this.labelStatusNxt.Text = "Disconnected";
            //this.labelStatusNxt.Visible = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                if (ev3 != null && ev3.Connection.IsConnected)
                {
                    this.ev3.Connection.Close();
                    this.ev3 = null;
                }

                labelStatusNxt.Text = "Disconnected";
                labelStatusNxt.Visible = true;

                pictureNXT.BackgroundImage = Properties.Resources.nxt_red;

                pictureIconEV3.BackgroundImage = Properties.Resources.ev3_red;
                pictureIconNXT.BackgroundImage = Properties.Resources.nxt_green;
            }
            else
            {
                if (nxt != null && nxt.IsConnected)
                {
                    this.nxt.Disconnect();
                    this.nxt = null;
                }

                labelStatusNxt.Text = "Disconnected";
                labelStatusNxt.Visible = true;

                pictureNXT.BackgroundImage = Properties.Resources.ev3_red;

                pictureIconEV3.BackgroundImage = Properties.Resources.ev3_green;
                pictureIconNXT.BackgroundImage = Properties.Resources.nxt_red;
            }
        }
        #endregion 

        #region Kinect Managment

        void MainWindow_Loaded(object sender, EventArgs e)
        {

        }

        private void refreshStat()
        {
            this.labelStatus.Text = statusKinect;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (speechRecognizer != null)
            {
                speechRecognizer.RecognizeAsyncCancel();
                speechRecognizer.RecognizeAsyncStop();
            }
            if (sensor != null)
            {
                sensor.AudioSource.Stop();
                sensor.Stop();
                sensor.Dispose();
                sensor = null;
            }
        }

        public float KinectX(Joint joint)
        {
            CoordinateMapper mapper = sensor.CoordinateMapper;
            var map = mapper.MapSkeletonPointToColorPoint(joint.Position, sensor.ColorStream.Format);
            return map.X + this.videoImage.Bounds.X;
        }

        public float KinectY(Joint joint)
        {
            CoordinateMapper mapper = sensor.CoordinateMapper;
            var map = mapper.MapSkeletonPointToColorPoint(joint.Position, sensor.ColorStream.Format);
            return map.Y + this.videoImage.Bounds.Y;
        }

        private void buttonTiltUp_Click(object sender, EventArgs e)
        {
            if (sensor == null || sensor.Status != KinectStatus.Connected)
                return;

            if (sensor.ElevationAngle < sensor.MaxElevationAngle - 5)
                sensor.ElevationAngle += 5;
        }

        private void buttonTiltDown_Click(object sender, EventArgs e)
        {
            if (sensor == null || sensor.Status != KinectStatus.Connected)
                return;

            if (sensor.ElevationAngle > sensor.MinElevationAngle + 5)
                sensor.ElevationAngle -= 5;
        }
        #endregion
    }
}
