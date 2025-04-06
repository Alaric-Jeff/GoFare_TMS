using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IPT_TMS_GoFare.Views
{
    public partial class ScanForm : Form
    {
        SerialPort serialPort = new SerialPort("COM5", 9600); // Change COM5 if needed

        public ScanForm()
        {
            InitializeComponent();

            //serialPort.DataReceived += SerialPort_DataReceived;
            //serialPort.Open(); // Open the port here
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            Invoke((MethodInvoker)delegate
            {
                UID_Box.Text = data;
            });
        }

        private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                serialPort.Dispose();
            }
        }
    }
}
