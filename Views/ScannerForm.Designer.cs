namespace IPT_TMS_GoFare.Views
{
    partial class ScannerForm
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
            panel1 = new Panel();
            CurrentStationLabel = new Label();
            StationBox = new Label();
            Info = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(StationBox);
            panel1.Controls.Add(CurrentStationLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(639, 100);
            panel1.TabIndex = 0;
            // 
            // CurrentStationLabel
            // 
            CurrentStationLabel.AutoSize = true;
            CurrentStationLabel.Location = new Point(256, 9);
            CurrentStationLabel.MinimumSize = new Size(120, 0);
            CurrentStationLabel.Name = "CurrentStationLabel";
            CurrentStationLabel.Size = new Size(120, 15);
            CurrentStationLabel.TabIndex = 0;
            CurrentStationLabel.Text = "Current Station";
            CurrentStationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StationBox
            // 
            StationBox.AutoSize = true;
            StationBox.Location = new Point(269, 41);
            StationBox.MinimumSize = new Size(90, 0);
            StationBox.Name = "StationBox";
            StationBox.Size = new Size(90, 15);
            StationBox.TabIndex = 1;
            StationBox.TextAlign = ContentAlignment.MiddleCenter;
            StationBox.Click += StationBox_Click;
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.BackColor = SystemColors.Control;
            Info.BorderStyle = BorderStyle.Fixed3D;
            Info.CausesValidation = false;
            Info.Location = new Point(0, 103);
            Info.MinimumSize = new Size(638, 170);
            Info.Name = "Info";
            Info.Size = new Size(638, 170);
            Info.TabIndex = 1;
            Info.Text = "Scan your RFID";
            Info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 277);
            Controls.Add(Info);
            Controls.Add(panel1);
            Name = "ScannerForm";
            Text = "ScannerForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label StationBox;
        private Label CurrentStationLabel;
        private Label Info;
    }
}