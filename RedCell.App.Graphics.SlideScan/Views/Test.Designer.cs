namespace RedCell.App.Graphics.SlideScan
{
    partial class Test
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
            System.Windows.Forms.Button ReverseButton;
            System.Windows.Forms.Button ForwardButton;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            this.ExposureCompensationLabel = new System.Windows.Forms.Label();
            this.ShutterSpeedLabel = new System.Windows.Forms.Label();
            this.ApertureLabel = new System.Windows.Forms.Label();
            this.IsoLabel = new System.Windows.Forms.Label();
            this.SlideProjectorGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CameraGroupBox = new System.Windows.Forms.GroupBox();
            this.LiveViewButton = new System.Windows.Forms.Button();
            this.ExposureCompensationBar = new System.Windows.Forms.TrackBar();
            this.ShutterSpeedBar = new System.Windows.Forms.TrackBar();
            this.ApertureBar = new System.Windows.Forms.TrackBar();
            this.IsoBar = new System.Windows.Forms.TrackBar();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.CameraPictureBox = new System.Windows.Forms.PictureBox();
            this.LiveView = new CameraControl.Devices.Example.LiveView();
            ReverseButton = new System.Windows.Forms.Button();
            ForwardButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SlideProjectorGroupBox.SuspendLayout();
            this.CameraGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExposureCompensationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShutterSpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApertureBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsoBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReverseButton
            // 
            ReverseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            ReverseButton.Location = new System.Drawing.Point(331, 33);
            ReverseButton.Margin = new System.Windows.Forms.Padding(4);
            ReverseButton.Name = "ReverseButton";
            ReverseButton.Size = new System.Drawing.Size(100, 28);
            ReverseButton.TabIndex = 3;
            ReverseButton.Text = "Reverse";
            ReverseButton.UseVisualStyleBackColor = true;
            ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // ForwardButton
            // 
            ForwardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            ForwardButton.Location = new System.Drawing.Point(223, 33);
            ForwardButton.Margin = new System.Windows.Forms.Padding(4);
            ForwardButton.Name = "ForwardButton";
            ForwardButton.Size = new System.Drawing.Size(100, 28);
            ForwardButton.TabIndex = 3;
            ForwardButton.Text = "Forward";
            ForwardButton.UseVisualStyleBackColor = true;
            ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(173, 39);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 17);
            label2.TabIndex = 2;
            label2.Text = "ms";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 39);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 17);
            label1.TabIndex = 0;
            label1.Text = "Pulse Width";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(8, 246);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(161, 17);
            label7.TabIndex = 4;
            label7.Text = "Exposure Compensation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 176);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(99, 17);
            label5.TabIndex = 3;
            label5.Text = "Shutter Speed";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 102);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 17);
            label4.TabIndex = 2;
            label4.Text = "Aperture";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 31);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 17);
            label3.TabIndex = 1;
            label3.Text = "ISO";
            // 
            // ExposureCompensationLabel
            // 
            this.ExposureCompensationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExposureCompensationLabel.AutoSize = true;
            this.ExposureCompensationLabel.Location = new System.Drawing.Point(383, 246);
            this.ExposureCompensationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExposureCompensationLabel.Name = "ExposureCompensationLabel";
            this.ExposureCompensationLabel.Size = new System.Drawing.Size(46, 17);
            this.ExposureCompensationLabel.TabIndex = 12;
            this.ExposureCompensationLabel.Text = "+0 EV";
            this.ExposureCompensationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ShutterSpeedLabel
            // 
            this.ShutterSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShutterSpeedLabel.AutoSize = true;
            this.ShutterSpeedLabel.Location = new System.Drawing.Point(391, 176);
            this.ShutterSpeedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShutterSpeedLabel.Name = "ShutterSpeedLabel";
            this.ShutterSpeedLabel.Size = new System.Drawing.Size(36, 17);
            this.ShutterSpeedLabel.TabIndex = 11;
            this.ShutterSpeedLabel.Text = "1/60";
            this.ShutterSpeedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ApertureLabel
            // 
            this.ApertureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApertureLabel.AutoSize = true;
            this.ApertureLabel.Location = new System.Drawing.Point(417, 102);
            this.ApertureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ApertureLabel.Name = "ApertureLabel";
            this.ApertureLabel.Size = new System.Drawing.Size(12, 17);
            this.ApertureLabel.TabIndex = 10;
            this.ApertureLabel.Text = "f";
            this.ApertureLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // IsoLabel
            // 
            this.IsoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsoLabel.AutoSize = true;
            this.IsoLabel.Location = new System.Drawing.Point(397, 31);
            this.IsoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IsoLabel.Name = "IsoLabel";
            this.IsoLabel.Size = new System.Drawing.Size(31, 17);
            this.IsoLabel.TabIndex = 9;
            this.IsoLabel.Text = "ISO";
            this.IsoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SlideProjectorGroupBox
            // 
            this.SlideProjectorGroupBox.Controls.Add(ReverseButton);
            this.SlideProjectorGroupBox.Controls.Add(ForwardButton);
            this.SlideProjectorGroupBox.Controls.Add(label2);
            this.SlideProjectorGroupBox.Controls.Add(this.textBox1);
            this.SlideProjectorGroupBox.Controls.Add(label1);
            this.SlideProjectorGroupBox.Location = new System.Drawing.Point(16, 406);
            this.SlideProjectorGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.SlideProjectorGroupBox.Name = "SlideProjectorGroupBox";
            this.SlideProjectorGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.SlideProjectorGroupBox.Size = new System.Drawing.Size(453, 85);
            this.SlideProjectorGroupBox.TabIndex = 0;
            this.SlideProjectorGroupBox.TabStop = false;
            this.SlideProjectorGroupBox.Text = "Slide Projector";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 22);
            this.textBox1.TabIndex = 1;
            // 
            // CameraGroupBox
            // 
            this.CameraGroupBox.Controls.Add(this.LiveViewButton);
            this.CameraGroupBox.Controls.Add(this.ExposureCompensationLabel);
            this.CameraGroupBox.Controls.Add(this.ShutterSpeedLabel);
            this.CameraGroupBox.Controls.Add(this.ApertureLabel);
            this.CameraGroupBox.Controls.Add(this.IsoLabel);
            this.CameraGroupBox.Controls.Add(label7);
            this.CameraGroupBox.Controls.Add(label5);
            this.CameraGroupBox.Controls.Add(label4);
            this.CameraGroupBox.Controls.Add(label3);
            this.CameraGroupBox.Controls.Add(this.ExposureCompensationBar);
            this.CameraGroupBox.Controls.Add(this.ShutterSpeedBar);
            this.CameraGroupBox.Controls.Add(this.ApertureBar);
            this.CameraGroupBox.Controls.Add(this.IsoBar);
            this.CameraGroupBox.Controls.Add(this.CaptureButton);
            this.CameraGroupBox.Location = new System.Drawing.Point(16, 15);
            this.CameraGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.CameraGroupBox.Name = "CameraGroupBox";
            this.CameraGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.CameraGroupBox.Size = new System.Drawing.Size(453, 369);
            this.CameraGroupBox.TabIndex = 1;
            this.CameraGroupBox.TabStop = false;
            this.CameraGroupBox.Text = "Camera";
            // 
            // LiveViewButton
            // 
            this.LiveViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveViewButton.Location = new System.Drawing.Point(223, 330);
            this.LiveViewButton.Margin = new System.Windows.Forms.Padding(4);
            this.LiveViewButton.Name = "LiveViewButton";
            this.LiveViewButton.Size = new System.Drawing.Size(100, 28);
            this.LiveViewButton.TabIndex = 13;
            this.LiveViewButton.Text = "Live View";
            this.LiveViewButton.UseVisualStyleBackColor = true;
            this.LiveViewButton.Click += new System.EventHandler(this.LiveViewButton_Click);
            // 
            // ExposureCompensationBar
            // 
            this.ExposureCompensationBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExposureCompensationBar.Location = new System.Drawing.Point(12, 266);
            this.ExposureCompensationBar.Margin = new System.Windows.Forms.Padding(4);
            this.ExposureCompensationBar.Name = "ExposureCompensationBar";
            this.ExposureCompensationBar.Size = new System.Drawing.Size(419, 56);
            this.ExposureCompensationBar.TabIndex = 8;
            // 
            // ShutterSpeedBar
            // 
            this.ShutterSpeedBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShutterSpeedBar.Location = new System.Drawing.Point(12, 196);
            this.ShutterSpeedBar.Margin = new System.Windows.Forms.Padding(4);
            this.ShutterSpeedBar.Name = "ShutterSpeedBar";
            this.ShutterSpeedBar.Size = new System.Drawing.Size(419, 56);
            this.ShutterSpeedBar.TabIndex = 7;
            // 
            // ApertureBar
            // 
            this.ApertureBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApertureBar.Location = new System.Drawing.Point(12, 122);
            this.ApertureBar.Margin = new System.Windows.Forms.Padding(4);
            this.ApertureBar.Name = "ApertureBar";
            this.ApertureBar.Size = new System.Drawing.Size(419, 56);
            this.ApertureBar.TabIndex = 6;
            // 
            // IsoBar
            // 
            this.IsoBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IsoBar.Location = new System.Drawing.Point(12, 50);
            this.IsoBar.Margin = new System.Windows.Forms.Padding(4);
            this.IsoBar.Name = "IsoBar";
            this.IsoBar.Size = new System.Drawing.Size(419, 56);
            this.IsoBar.TabIndex = 5;
            // 
            // CaptureButton
            // 
            this.CaptureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CaptureButton.Location = new System.Drawing.Point(331, 330);
            this.CaptureButton.Margin = new System.Windows.Forms.Padding(4);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(100, 28);
            this.CaptureButton.TabIndex = 0;
            this.CaptureButton.Text = "Capture";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // CameraPictureBox
            // 
            this.CameraPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraPictureBox.Location = new System.Drawing.Point(492, 24);
            this.CameraPictureBox.Name = "CameraPictureBox";
            this.CameraPictureBox.Size = new System.Drawing.Size(634, 467);
            this.CameraPictureBox.TabIndex = 2;
            this.CameraPictureBox.TabStop = false;
            // 
            // LiveView
            // 
            this.LiveView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveView.Location = new System.Drawing.Point(492, 24);
            this.LiveView.Name = "LiveView";
            this.LiveView.Size = new System.Drawing.Size(634, 467);
            this.LiveView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LiveView.TabIndex = 3;
            this.LiveView.TabStop = false;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 496);
            this.Controls.Add(this.LiveView);
            this.Controls.Add(this.CameraPictureBox);
            this.Controls.Add(this.CameraGroupBox);
            this.Controls.Add(this.SlideProjectorGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(501, 543);
            this.Name = "Test";
            this.Text = "Test";
            this.SlideProjectorGroupBox.ResumeLayout(false);
            this.SlideProjectorGroupBox.PerformLayout();
            this.CameraGroupBox.ResumeLayout(false);
            this.CameraGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExposureCompensationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShutterSpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApertureBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsoBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar IsoBar;
        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.TrackBar ExposureCompensationBar;
        private System.Windows.Forms.TrackBar ShutterSpeedBar;
        private System.Windows.Forms.TrackBar ApertureBar;
        private System.Windows.Forms.GroupBox SlideProjectorGroupBox;
        private System.Windows.Forms.GroupBox CameraGroupBox;
        private System.Windows.Forms.Label ApertureLabel;
        private System.Windows.Forms.Label ExposureCompensationLabel;
        private System.Windows.Forms.Label ShutterSpeedLabel;
        private System.Windows.Forms.Label IsoLabel;
        private System.Windows.Forms.Button LiveViewButton;
        private System.Windows.Forms.PictureBox CameraPictureBox;
        private CameraControl.Devices.Example.LiveView LiveView;
    }
}