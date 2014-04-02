namespace KinectIntegrationForEV3NXT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelMotorsL = new System.Windows.Forms.Label();
            this.labelMotorsR = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSpeech = new System.Windows.Forms.Label();
            this.labelDriver = new System.Windows.Forms.Label();
            this.labelManipulator = new System.Windows.Forms.Label();
            this.timerLoader = new System.Windows.Forms.Timer(this.components);
            this.timerKinectConnection = new System.Windows.Forms.Timer(this.components);
            this.timerSpeech = new System.Windows.Forms.Timer(this.components);
            this.labelLMotors = new System.Windows.Forms.Label();
            this.labelRMotors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxComPort = new System.Windows.Forms.TextBox();
            this.buttonBluetooth = new System.Windows.Forms.Button();
            this.buttonTiltUp = new System.Windows.Forms.Button();
            this.buttonTiltDown = new System.Windows.Forms.Button();
            this.btnTglDrive = new System.Windows.Forms.Button();
            this.btnTglManip = new System.Windows.Forms.Button();
            this.btnEStop = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatusNxt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timerHideStatKinect = new System.Windows.Forms.Timer(this.components);
            this.timerHideStatNxt = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.timerUpdateNxt = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureIconEV3 = new System.Windows.Forms.PictureBox();
            this.pictureIconNXT = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureNXT = new System.Windows.Forms.PictureBox();
            this.pictureKinect = new System.Windows.Forms.PictureBox();
            this.pictureBtIcon = new System.Windows.Forms.PictureBox();
            this.overlayLift = new System.Windows.Forms.PictureBox();
            this.overlayTilt = new System.Windows.Forms.PictureBox();
            this.overlayPowR = new System.Windows.Forms.PictureBox();
            this.overlayPowL = new System.Windows.Forms.PictureBox();
            this.overlayDeadzoneR = new System.Windows.Forms.PictureBox();
            this.overlayDeadzoneL = new System.Windows.Forms.PictureBox();
            this.overlayBarR = new System.Windows.Forms.PictureBox();
            this.overlayBarL = new System.Windows.Forms.PictureBox();
            this.pictureSpeech = new System.Windows.Forms.PictureBox();
            this.videoImage = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconEV3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconNXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKinect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBtIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayLift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayPowR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayPowL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayDeadzoneR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayDeadzoneL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBarL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpeech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMotorsL
            // 
            this.labelMotorsL.AutoSize = true;
            this.labelMotorsL.Location = new System.Drawing.Point(35, 717);
            this.labelMotorsL.Name = "labelMotorsL";
            this.labelMotorsL.Size = new System.Drawing.Size(147, 20);
            this.labelMotorsL.TabIndex = 0;
            this.labelMotorsL.Text = "Left Motor Power: 0";
            this.labelMotorsL.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelMotorsR
            // 
            this.labelMotorsR.AutoSize = true;
            this.labelMotorsR.Location = new System.Drawing.Point(12, 776);
            this.labelMotorsR.Name = "labelMotorsR";
            this.labelMotorsR.Size = new System.Drawing.Size(157, 20);
            this.labelMotorsR.TabIndex = 1;
            this.labelMotorsR.Text = "Right Motor Power: 0";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.labelStatus.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(523, 94);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(264, 43);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Disconnected";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(294, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kinect Integration For EV3/NXT";
            // 
            // labelSpeech
            // 
            this.labelSpeech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSpeech.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeech.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSpeech.Location = new System.Drawing.Point(1223, 82);
            this.labelSpeech.Name = "labelSpeech";
            this.labelSpeech.Size = new System.Drawing.Size(304, 38);
            this.labelSpeech.TabIndex = 4;
            this.labelSpeech.Text = "LISTENING . . .";
            this.labelSpeech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDriver
            // 
            this.labelDriver.AutoSize = true;
            this.labelDriver.BackColor = System.Drawing.Color.Transparent;
            this.labelDriver.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDriver.ForeColor = System.Drawing.Color.DarkGray;
            this.labelDriver.Location = new System.Drawing.Point(582, 160);
            this.labelDriver.Name = "labelDriver";
            this.labelDriver.Size = new System.Drawing.Size(108, 39);
            this.labelDriver.TabIndex = 8;
            this.labelDriver.Text = "Driver";
            this.labelDriver.Visible = false;
            // 
            // labelManipulator
            // 
            this.labelManipulator.AutoSize = true;
            this.labelManipulator.BackColor = System.Drawing.Color.White;
            this.labelManipulator.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManipulator.ForeColor = System.Drawing.Color.DarkGray;
            this.labelManipulator.Location = new System.Drawing.Point(1228, 160);
            this.labelManipulator.Name = "labelManipulator";
            this.labelManipulator.Size = new System.Drawing.Size(205, 39);
            this.labelManipulator.TabIndex = 9;
            this.labelManipulator.Text = "Manipulator";
            this.labelManipulator.Visible = false;
            // 
            // timerLoader
            // 
            this.timerLoader.Enabled = true;
            this.timerLoader.Interval = 300;
            this.timerLoader.Tick += new System.EventHandler(this.timerLoader_Tick);
            // 
            // timerKinectConnection
            // 
            this.timerKinectConnection.Interval = 10;
            this.timerKinectConnection.Tick += new System.EventHandler(this.timerKinectConnection_Tick);
            // 
            // timerSpeech
            // 
            this.timerSpeech.Interval = 4000;
            this.timerSpeech.Tick += new System.EventHandler(this.timerSpeech_Tick);
            // 
            // labelLMotors
            // 
            this.labelLMotors.AutoSize = true;
            this.labelLMotors.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLMotors.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelLMotors.Location = new System.Drawing.Point(785, 432);
            this.labelLMotors.Name = "labelLMotors";
            this.labelLMotors.Size = new System.Drawing.Size(59, 34);
            this.labelLMotors.TabIndex = 13;
            this.labelLMotors.Text = "L: 0";
            this.labelLMotors.Visible = false;
            // 
            // labelRMotors
            // 
            this.labelRMotors.AutoSize = true;
            this.labelRMotors.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRMotors.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelRMotors.Location = new System.Drawing.Point(412, 432);
            this.labelRMotors.Name = "labelRMotors";
            this.labelRMotors.Size = new System.Drawing.Size(63, 34);
            this.labelRMotors.TabIndex = 14;
            this.labelRMotors.Text = "R: 0";
            this.labelRMotors.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(314, 974);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // textBoxComPort
            // 
            this.textBoxComPort.Location = new System.Drawing.Point(153, 177);
            this.textBoxComPort.Name = "textBoxComPort";
            this.textBoxComPort.Size = new System.Drawing.Size(31, 26);
            this.textBoxComPort.TabIndex = 26;
            this.textBoxComPort.Text = "7";
            // 
            // buttonBluetooth
            // 
            this.buttonBluetooth.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBluetooth.ForeColor = System.Drawing.Color.SteelBlue;
            this.buttonBluetooth.Location = new System.Drawing.Point(199, 172);
            this.buttonBluetooth.Name = "buttonBluetooth";
            this.buttonBluetooth.Size = new System.Drawing.Size(96, 35);
            this.buttonBluetooth.TabIndex = 28;
            this.buttonBluetooth.Text = "Connect";
            this.buttonBluetooth.UseVisualStyleBackColor = true;
            this.buttonBluetooth.Click += new System.EventHandler(this.buttonBluetooth_Click);
            // 
            // buttonTiltUp
            // 
            this.buttonTiltUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTiltUp.Location = new System.Drawing.Point(247, 94);
            this.buttonTiltUp.Name = "buttonTiltUp";
            this.buttonTiltUp.Size = new System.Drawing.Size(21, 33);
            this.buttonTiltUp.TabIndex = 29;
            this.buttonTiltUp.Text = "↑";
            this.buttonTiltUp.UseVisualStyleBackColor = true;
            this.buttonTiltUp.Click += new System.EventHandler(this.buttonTiltUp_Click);
            // 
            // buttonTiltDown
            // 
            this.buttonTiltDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTiltDown.Location = new System.Drawing.Point(274, 94);
            this.buttonTiltDown.Name = "buttonTiltDown";
            this.buttonTiltDown.Size = new System.Drawing.Size(21, 33);
            this.buttonTiltDown.TabIndex = 30;
            this.buttonTiltDown.Text = "↓";
            this.buttonTiltDown.UseVisualStyleBackColor = true;
            this.buttonTiltDown.Click += new System.EventHandler(this.buttonTiltDown_Click);
            // 
            // btnTglDrive
            // 
            this.btnTglDrive.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTglDrive.Location = new System.Drawing.Point(28, 782);
            this.btnTglDrive.Name = "btnTglDrive";
            this.btnTglDrive.Size = new System.Drawing.Size(137, 38);
            this.btnTglDrive.TabIndex = 44;
            this.btnTglDrive.Text = "DRIVE";
            this.btnTglDrive.UseVisualStyleBackColor = true;
            this.btnTglDrive.Click += new System.EventHandler(this.btnTglDrive_Click);
            // 
            // btnTglManip
            // 
            this.btnTglManip.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTglManip.Location = new System.Drawing.Point(28, 837);
            this.btnTglManip.Name = "btnTglManip";
            this.btnTglManip.Size = new System.Drawing.Size(137, 38);
            this.btnTglManip.TabIndex = 45;
            this.btnTglManip.Text = "MANIPULATE";
            this.btnTglManip.UseVisualStyleBackColor = true;
            this.btnTglManip.Click += new System.EventHandler(this.btnTglManip_Click);
            // 
            // btnEStop
            // 
            this.btnEStop.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnEStop.FlatAppearance.BorderSize = 3;
            this.btnEStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnEStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnEStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEStop.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEStop.ForeColor = System.Drawing.Color.Red;
            this.btnEStop.Location = new System.Drawing.Point(28, 895);
            this.btnEStop.Name = "btnEStop";
            this.btnEStop.Size = new System.Drawing.Size(245, 93);
            this.btnEStop.TabIndex = 46;
            this.btnEStop.Text = "E-STOP";
            this.btnEStop.UseVisualStyleBackColor = true;
            this.btnEStop.Click += new System.EventHandler(this.btnEStop_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(106, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "COM";
            // 
            // labelStatusNxt
            // 
            this.labelStatusNxt.AutoSize = true;
            this.labelStatusNxt.BackColor = System.Drawing.Color.LightGray;
            this.labelStatusNxt.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusNxt.ForeColor = System.Drawing.Color.Black;
            this.labelStatusNxt.Location = new System.Drawing.Point(385, 177);
            this.labelStatusNxt.Name = "labelStatusNxt";
            this.labelStatusNxt.Size = new System.Drawing.Size(264, 43);
            this.labelStatusNxt.TabIndex = 49;
            this.labelStatusNxt.Text = "Disconnected";
            this.labelStatusNxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(139, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "KINECT TILT";
            // 
            // timerHideStatKinect
            // 
            this.timerHideStatKinect.Interval = 4000;
            this.timerHideStatKinect.Tick += new System.EventHandler(this.timerHideStatKinect_Tick);
            // 
            // timerHideStatNxt
            // 
            this.timerHideStatNxt.Interval = 4000;
            this.timerHideStatNxt.Tick += new System.EventHandler(this.timerHideStatNxt_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label9.Location = new System.Drawing.Point(1447, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 21);
            this.label9.TabIndex = 60;
            this.label9.Text = "version 2.0.0.055";
            // 
            // timerUpdateNxt
            // 
            this.timerUpdateNxt.Tick += new System.EventHandler(this.timerUpdateNxt_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1717, 925);
            this.trackBar1.Maximum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(88, 69);
            this.trackBar1.TabIndex = 65;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // pictureIconEV3
            // 
            this.pictureIconEV3.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.ev3_red;
            this.pictureIconEV3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureIconEV3.Location = new System.Drawing.Point(1811, 912);
            this.pictureIconEV3.Name = "pictureIconEV3";
            this.pictureIconEV3.Size = new System.Drawing.Size(57, 67);
            this.pictureIconEV3.TabIndex = 67;
            this.pictureIconEV3.TabStop = false;
            // 
            // pictureIconNXT
            // 
            this.pictureIconNXT.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.nxt_green;
            this.pictureIconNXT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureIconNXT.Location = new System.Drawing.Point(1653, 912);
            this.pictureIconNXT.Name = "pictureIconNXT";
            this.pictureIconNXT.Size = new System.Drawing.Size(58, 67);
            this.pictureIconNXT.TabIndex = 66;
            this.pictureIconNXT.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.kifen;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Location = new System.Drawing.Point(1656, 15);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(181, 178);
            this.pictureBox11.TabIndex = 61;
            this.pictureBox11.TabStop = false;
            // 
            // pictureNXT
            // 
            this.pictureNXT.BackColor = System.Drawing.Color.White;
            this.pictureNXT.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.nxt_red;
            this.pictureNXT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureNXT.Location = new System.Drawing.Point(301, 160);
            this.pictureNXT.Name = "pictureNXT";
            this.pictureNXT.Size = new System.Drawing.Size(89, 63);
            this.pictureNXT.TabIndex = 11;
            this.pictureNXT.TabStop = false;
            // 
            // pictureKinect
            // 
            this.pictureKinect.BackColor = System.Drawing.Color.White;
            this.pictureKinect.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.kinect_red;
            this.pictureKinect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureKinect.Location = new System.Drawing.Point(301, 82);
            this.pictureKinect.Name = "pictureKinect";
            this.pictureKinect.Size = new System.Drawing.Size(228, 58);
            this.pictureKinect.TabIndex = 10;
            this.pictureKinect.TabStop = false;
            // 
            // pictureBtIcon
            // 
            this.pictureBtIcon.BackColor = System.Drawing.Color.White;
            this.pictureBtIcon.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.bluetooth_logo;
            this.pictureBtIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBtIcon.Location = new System.Drawing.Point(69, 160);
            this.pictureBtIcon.Name = "pictureBtIcon";
            this.pictureBtIcon.Size = new System.Drawing.Size(41, 63);
            this.pictureBtIcon.TabIndex = 27;
            this.pictureBtIcon.TabStop = false;
            // 
            // overlayLift
            // 
            this.overlayLift.BackColor = System.Drawing.Color.White;
            this.overlayLift.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.Circle_idle;
            this.overlayLift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overlayLift.Location = new System.Drawing.Point(1475, 384);
            this.overlayLift.Name = "overlayLift";
            this.overlayLift.Size = new System.Drawing.Size(70, 70);
            this.overlayLift.TabIndex = 25;
            this.overlayLift.TabStop = false;
            this.overlayLift.Visible = false;
            // 
            // overlayTilt
            // 
            this.overlayTilt.BackColor = System.Drawing.Color.White;
            this.overlayTilt.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.Circle_idle;
            this.overlayTilt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.overlayTilt.Location = new System.Drawing.Point(1114, 384);
            this.overlayTilt.Name = "overlayTilt";
            this.overlayTilt.Size = new System.Drawing.Size(70, 70);
            this.overlayTilt.TabIndex = 24;
            this.overlayTilt.TabStop = false;
            this.overlayTilt.Visible = false;
            // 
            // overlayPowR
            // 
            this.overlayPowR.BackColor = System.Drawing.Color.DimGray;
            this.overlayPowR.Location = new System.Drawing.Point(721, 396);
            this.overlayPowR.Name = "overlayPowR";
            this.overlayPowR.Size = new System.Drawing.Size(22, 11);
            this.overlayPowR.TabIndex = 23;
            this.overlayPowR.TabStop = false;
            this.overlayPowR.Visible = false;
            // 
            // overlayPowL
            // 
            this.overlayPowL.BackColor = System.Drawing.Color.DimGray;
            this.overlayPowL.Location = new System.Drawing.Point(507, 396);
            this.overlayPowL.Name = "overlayPowL";
            this.overlayPowL.Size = new System.Drawing.Size(22, 11);
            this.overlayPowL.TabIndex = 22;
            this.overlayPowL.TabStop = false;
            this.overlayPowL.Visible = false;
            // 
            // overlayDeadzoneR
            // 
            this.overlayDeadzoneR.BackColor = System.Drawing.Color.DarkGray;
            this.overlayDeadzoneR.Location = new System.Drawing.Point(721, 413);
            this.overlayDeadzoneR.Name = "overlayDeadzoneR";
            this.overlayDeadzoneR.Size = new System.Drawing.Size(22, 85);
            this.overlayDeadzoneR.TabIndex = 21;
            this.overlayDeadzoneR.TabStop = false;
            this.overlayDeadzoneR.Visible = false;
            // 
            // overlayDeadzoneL
            // 
            this.overlayDeadzoneL.BackColor = System.Drawing.Color.DarkGray;
            this.overlayDeadzoneL.Location = new System.Drawing.Point(507, 413);
            this.overlayDeadzoneL.Name = "overlayDeadzoneL";
            this.overlayDeadzoneL.Size = new System.Drawing.Size(22, 85);
            this.overlayDeadzoneL.TabIndex = 20;
            this.overlayDeadzoneL.TabStop = false;
            this.overlayDeadzoneL.Visible = false;
            // 
            // overlayBarR
            // 
            this.overlayBarR.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.overlayBarR.Location = new System.Drawing.Point(739, 244);
            this.overlayBarR.Name = "overlayBarR";
            this.overlayBarR.Size = new System.Drawing.Size(22, 444);
            this.overlayBarR.TabIndex = 19;
            this.overlayBarR.TabStop = false;
            this.overlayBarR.Visible = false;
            // 
            // overlayBarL
            // 
            this.overlayBarL.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.overlayBarL.Location = new System.Drawing.Point(525, 244);
            this.overlayBarL.Name = "overlayBarL";
            this.overlayBarL.Size = new System.Drawing.Size(22, 444);
            this.overlayBarL.TabIndex = 18;
            this.overlayBarL.TabStop = false;
            this.overlayBarL.Visible = false;
            // 
            // pictureSpeech
            // 
            this.pictureSpeech.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.voice_red;
            this.pictureSpeech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureSpeech.Location = new System.Drawing.Point(1522, 82);
            this.pictureSpeech.Name = "pictureSpeech";
            this.pictureSpeech.Size = new System.Drawing.Size(59, 58);
            this.pictureSpeech.TabIndex = 12;
            this.pictureSpeech.TabStop = false;
            // 
            // videoImage
            // 
            this.videoImage.BackColor = System.Drawing.SystemColors.Window;
            this.videoImage.BackgroundImage = global::KinectIntegrationForEV3NXT.Properties.Resources.kifen_noimg;
            this.videoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.videoImage.Location = new System.Drawing.Point(301, 66);
            this.videoImage.Name = "videoImage";
            this.videoImage.Size = new System.Drawing.Size(1280, 960);
            this.videoImage.TabIndex = 7;
            this.videoImage.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.Location = new System.Drawing.Point(69, 160);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(236, 63);
            this.pictureBox9.TabIndex = 50;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.Location = new System.Drawing.Point(124, 82);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(181, 58);
            this.pictureBox10.TabIndex = 51;
            this.pictureBox10.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1912, 1038);
            this.Controls.Add(this.pictureIconEV3);
            this.Controls.Add(this.pictureIconNXT);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureNXT);
            this.Controls.Add(this.pictureKinect);
            this.Controls.Add(this.labelStatusNxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEStop);
            this.Controls.Add(this.btnTglManip);
            this.Controls.Add(this.btnTglDrive);
            this.Controls.Add(this.buttonTiltDown);
            this.Controls.Add(this.buttonTiltUp);
            this.Controls.Add(this.buttonBluetooth);
            this.Controls.Add(this.pictureBtIcon);
            this.Controls.Add(this.textBoxComPort);
            this.Controls.Add(this.labelRMotors);
            this.Controls.Add(this.labelLMotors);
            this.Controls.Add(this.overlayLift);
            this.Controls.Add(this.overlayTilt);
            this.Controls.Add(this.overlayPowR);
            this.Controls.Add(this.overlayPowL);
            this.Controls.Add(this.overlayDeadzoneR);
            this.Controls.Add(this.overlayDeadzoneL);
            this.Controls.Add(this.overlayBarR);
            this.Controls.Add(this.overlayBarL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDriver);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureSpeech);
            this.Controls.Add(this.labelManipulator);
            this.Controls.Add(this.labelSpeech);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelMotorsR);
            this.Controls.Add(this.labelMotorsL);
            this.Controls.Add(this.videoImage);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "KIFEN";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconEV3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIconNXT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNXT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKinect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBtIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayLift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayPowR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayPowL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayDeadzoneR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayDeadzoneL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBarL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSpeech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMotorsL;
        private System.Windows.Forms.Label labelMotorsR;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSpeech;
        private System.Windows.Forms.PictureBox videoImage;
        private System.Windows.Forms.Label labelDriver;
        private System.Windows.Forms.Label labelManipulator;
        private System.Windows.Forms.PictureBox pictureKinect;
        private System.Windows.Forms.PictureBox pictureNXT;
        private System.Windows.Forms.PictureBox pictureSpeech;
        private System.Windows.Forms.Timer timerLoader;
        private System.Windows.Forms.Timer timerKinectConnection;
        private System.Windows.Forms.Timer timerSpeech;
        private System.Windows.Forms.Label labelLMotors;
        private System.Windows.Forms.Label labelRMotors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox overlayBarL;
        private System.Windows.Forms.PictureBox overlayBarR;
        private System.Windows.Forms.PictureBox overlayDeadzoneL;
        private System.Windows.Forms.PictureBox overlayDeadzoneR;
        private System.Windows.Forms.PictureBox overlayPowL;
        private System.Windows.Forms.PictureBox overlayPowR;
        private System.Windows.Forms.PictureBox overlayTilt;
        private System.Windows.Forms.PictureBox overlayLift;
        private System.Windows.Forms.TextBox textBoxComPort;
        private System.Windows.Forms.PictureBox pictureBtIcon;
        private System.Windows.Forms.Button buttonBluetooth;
        private System.Windows.Forms.Button buttonTiltUp;
        private System.Windows.Forms.Button buttonTiltDown;
        private System.Windows.Forms.Button btnTglDrive;
        private System.Windows.Forms.Button btnTglManip;
        private System.Windows.Forms.Button btnEStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelStatusNxt;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timerHideStatKinect;
        private System.Windows.Forms.Timer timerHideStatNxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Timer timerUpdateNxt;
        private System.Windows.Forms.PictureBox pictureIconEV3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureIconNXT;
    }
}

