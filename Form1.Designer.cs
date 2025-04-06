namespace IPT_TMS_GoFare
{
    partial class DestinationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            PickUpLabel = new System.Windows.Forms.Label();
            DropOffLabel = new System.Windows.Forms.Label();
            Payment = new System.Windows.Forms.Label();
            PickUpDropDown = new System.Windows.Forms.ComboBox();
            DropOffDropDown = new System.Windows.Forms.ComboBox();
            paymentDisplay = new System.Windows.Forms.TextBox();
            PaymentBox = new System.Windows.Forms.TextBox();
            Balance = new System.Windows.Forms.Label();
            CurrentBalance = new System.Windows.Forms.Label();
            cbTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();

            PickUpLabel.AutoSize = true;
            PickUpLabel.Location = new System.Drawing.Point(147, 47);
            PickUpLabel.Name = "PickUpLabel";
            PickUpLabel.Size = new System.Drawing.Size(71, 25);
            PickUpLabel.TabIndex = 0;
            PickUpLabel.Text = "Pick Up";
            PickUpLabel.Click += new System.EventHandler(PickUpLabel_Click);

            DropOffLabel.AutoSize = true;
            DropOffLabel.Location = new System.Drawing.Point(417, 47);
            DropOffLabel.Name = "DropOffLabel";
            DropOffLabel.Size = new System.Drawing.Size(84, 25);
            DropOffLabel.TabIndex = 1;
            DropOffLabel.Text = "Drop Off";
            DropOffLabel.Click += new System.EventHandler(DropOffLabel_Click);

            Payment.AutoSize = true;
            Payment.Location = new System.Drawing.Point(147, 260);
            Payment.Name = "Payment";
            Payment.Size = new System.Drawing.Size(84, 25);
            Payment.TabIndex = 2;
            Payment.Text = "Payment:";
            Payment.Click += new System.EventHandler(Payment_Click);

            PickUpDropDown.FormattingEnabled = true;
            PickUpDropDown.Items.AddRange(new object[] { "Destination 1", "Destination 2", "Destination 3", "Destination 4", "Destination 5" });
            PickUpDropDown.Location = new System.Drawing.Point(147, 75);
            PickUpDropDown.Name = "PickUpDropDown";
            PickUpDropDown.Size = new System.Drawing.Size(182, 33);
            PickUpDropDown.TabIndex = 3;
            PickUpDropDown.SelectedIndexChanged += new System.EventHandler(PickUpDropDown_SelectedIndexChanged);

            DropOffDropDown.FormattingEnabled = true;
            DropOffDropDown.Items.AddRange(new object[] { "Destination 1", "Destination 2", "Destination 3", "Destination 4", "Destination 5" });
            DropOffDropDown.Location = new System.Drawing.Point(407, 75);
            DropOffDropDown.Name = "DropOffDropDown";
            DropOffDropDown.Size = new System.Drawing.Size(182, 33);
            DropOffDropDown.TabIndex = 4;
            DropOffDropDown.SelectedIndexChanged += new System.EventHandler(DropOffDropDown_SelectedIndexChanged);

            paymentDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            paymentDisplay.Location = new System.Drawing.Point(237, 254);
            paymentDisplay.Name = "paymentDisplay";
            paymentDisplay.ReadOnly = true;
            paymentDisplay.Size = new System.Drawing.Size(150, 31);
            paymentDisplay.TabIndex = 5;
            paymentDisplay.Text = "₱0";

            PaymentBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PaymentBox.Location = new System.Drawing.Point(156, 166);
            PaymentBox.Name = "PaymentBox";
            PaymentBox.ReadOnly = true;
            PaymentBox.Size = new System.Drawing.Size(187, 24);
            PaymentBox.TabIndex = 6;
            PaymentBox.Text = "Please scan your card";
            PaymentBox.TextChanged += new System.EventHandler(PaymentBox_TextChanged);

            Balance.AutoSize = true;
            Balance.Location = new System.Drawing.Point(147, 212);
            Balance.Name = "Balance";
            Balance.Size = new System.Drawing.Size(75, 25);
            Balance.TabIndex = 7;
            Balance.Text = "Balance:";
            Balance.Click += new System.EventHandler(Balance_Click);

            CurrentBalance.AutoSize = true;
            CurrentBalance.Location = new System.Drawing.Point(147, 311);
            CurrentBalance.Name = "CurrentBalance";
            CurrentBalance.Size = new System.Drawing.Size(143, 25);
            CurrentBalance.TabIndex = 10;
            CurrentBalance.Text = "Current Balance:";
            CurrentBalance.Click += new System.EventHandler(CurrentBalance_Click);

            cbTextBox.Location = new System.Drawing.Point(296, 305);
            cbTextBox.Name = "cbTextBox";
            cbTextBox.ReadOnly = true;
            cbTextBox.Size = new System.Drawing.Size(150, 31);
            cbTextBox.TabIndex = 11;
            cbTextBox.TextChanged += new System.EventHandler(cbTextBox_TextChanged);

            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(cbTextBox);
            Controls.Add(CurrentBalance);
            Controls.Add(Balance);
            Controls.Add(PaymentBox);
            Controls.Add(paymentDisplay);
            Controls.Add(DropOffDropDown);
            Controls.Add(PickUpDropDown);
            Controls.Add(Payment);
            Controls.Add(DropOffLabel);
            Controls.Add(PickUpLabel);
            Name = "DestinationForm";
            Text = "Terminal";
            Load += new System.EventHandler(Form1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label PickUpLabel;
        private System.Windows.Forms.Label DropOffLabel;
        private System.Windows.Forms.Label Payment;
        private System.Windows.Forms.ComboBox PickUpDropDown;
        private System.Windows.Forms.ComboBox DropOffDropDown;
        private System.Windows.Forms.TextBox paymentDisplay;
        private System.Windows.Forms.TextBox PaymentBox;
        private System.Windows.Forms.Label Balance;
        private System.Windows.Forms.Label CurrentBalance;
        private System.Windows.Forms.TextBox cbTextBox;
    }
}
