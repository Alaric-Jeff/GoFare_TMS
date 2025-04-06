using System;
using System.Windows.Forms;

namespace IPT_TMS_GoFare
{
    public partial class DestinationForm : Form
    {
        public DestinationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            paymentDisplay.Text = "₱0";
            PaymentBox.Text = "Please scan your card";
        }

        private void PickUpDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateFare();
        }

        private void DropOffDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateFare();
        }

        private void CalculateFare()
        {
            if (PickUpDropDown.SelectedIndex == -1 || DropOffDropDown.SelectedIndex == -1)
            {
                return;
            }

            int pickUpIndex = PickUpDropDown.SelectedIndex;
            int dropOffIndex = DropOffDropDown.SelectedIndex;

            if (pickUpIndex == dropOffIndex)
            {
                paymentDisplay.Text = "Invalid Selection";
                return;
            }

            int distance = Math.Abs(dropOffIndex - pickUpIndex);
            double baseFare = 13.0;
            double fareIncrement = 2.0;
            double totalFare = baseFare + (distance - 1) * fareIncrement;

            paymentDisplay.Text = $"₱{totalFare:F2}";
        }

        private void PickUpLabel_Click(object sender, EventArgs e) { }
        private void DropOffLabel_Click(object sender, EventArgs e) { }
        private void Payment_Click(object sender, EventArgs e) { }
        private void Balance_Click(object sender, EventArgs e) { }
        private void CurrentBalance_Click(object sender, EventArgs e) { }
        private void PaymentBox_TextChanged(object sender, EventArgs e) { }
        private void cbTextBox_TextChanged(object sender, EventArgs e) { }
    }
}
