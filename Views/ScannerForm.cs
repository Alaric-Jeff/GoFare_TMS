using System;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using IPT_TMS_GoFare.Models;
using IPT_TMS_GoFare.Repositories;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace IPT_TMS_GoFare.Views
{
    public partial class ScannerForm : Form
    {
        SerialPort serialPort = new SerialPort("COM6", 9600);
        SessionRepository sessionRepository = new SessionRepository();
        ClientRepository clientRepository = new ClientRepository();
        WalletRepository walletRepository = new WalletRepository();
        RFIDRepository rfidRepository = new RFIDRepository();
        PaymentRepository paymentRepository = new PaymentRepository();
        string[] stations = { "Station 1", "Station 2", "Station 3", "Station 4", "Station 5", "Station 6", "Station 7", "Station 8", "Station 9", "Station 10" };
        decimal baseFare = 20;
        int currentStationIndex = 0;
        bool movingForward = true;
        System.Timers.Timer stationChangeTimer = new System.Timers.Timer(8000);

        public ScannerForm()
        {
            InitializeComponent();
            serialPort.DataReceived += SerialPort_DataReceived;
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                Info.Text = $"Failed to open COM port: {ex.Message}";
            }
            StationBox.Text = stations[currentStationIndex];
            stationChangeTimer.Elapsed += ChangeStation;
            stationChangeTimer.Start();
        }

        private string CleanRFID(string input)
        {
            return new string(input.Where(c => !char.IsControl(c)).ToArray()).Trim();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string rawData = serialPort.ReadLine();
            Debug.WriteLine("Raw RFID Data: " + rawData);
            string data = CleanRFID(rawData);
            Debug.WriteLine("Clean RFID Data: " + data);
            Invoke((MethodInvoker)delegate
            {
                if (string.IsNullOrWhiteSpace(data))
                    return;
                TransportProcess(data);
            });
        }

        public void TransportProcess(string rfid)
        {
            rfid = CleanRFID(rfid);
            var record = rfidRepository.GetRecordBasedOnRFID(rfid);
            if (record == null)
                return;
            var client = clientRepository.GetClient(record.client_id);
            var wallet = walletRepository.GetWallet(record.client_id);
            if (wallet == null)
                return;

            string currentStation = StationBox.Text;
            bool sessionExists = sessionRepository.FindSession(rfid);

            if (!sessionExists)
            {
                sessionRepository.AddSession(rfid, currentStation);
                Info.Text = $"Session started\nPick Up: {currentStation}\nRFID: {record.rfid}\nBalance: {wallet.balance}";
            }
            else
            {
                sessionRepository.UpdateDropOff(rfid, currentStation);
                var session = sessionRepository.GetSession(rfid);
                string pickUp = session != null ? session.pick_up : currentStation;
                int pickUpIndex = Array.IndexOf(stations, pickUp);
                int dropOffIndex = Array.IndexOf(stations, currentStation);

                if (pickUpIndex < 0 || dropOffIndex < 0)
                {
                    pickUpIndex = 0;
                    dropOffIndex = 0;
                }

                int distance = Math.Abs(dropOffIndex - pickUpIndex);
                decimal fare = baseFare + (distance * 2);

                bool paymentSuccess = false;
                if (wallet.loaned > 0)
                {
                    paymentSuccess = paymentRepository.PayWithLoan(wallet, fare);
                }
                else
                {
                    paymentSuccess = paymentRepository.PayWithoutLoan(wallet, fare);
                }

                if (!paymentSuccess)
                {
                    Info.Text = $"Payment failed. Insufficient funds.";
                    return;
                }

                sessionRepository.RemoveSession(rfid);
                Info.Text = $"Session ended\nPick Up: {pickUp}\nDrop Off: {currentStation}\nRFID: {record.rfid}\nFare: {fare}\nNew Balance: {wallet.balance}\nLoan: {wallet.loaned}";
            }
        }

        private void ChangeStation(object sender, ElapsedEventArgs e)
        {
            if (movingForward)
            {
                currentStationIndex++;
                if (currentStationIndex >= stations.Length)
                {
                    currentStationIndex = stations.Length - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentStationIndex--;
                if (currentStationIndex < 0)
                {
                    currentStationIndex = 1;
                    movingForward = true;
                }
            }

            Invoke((MethodInvoker)delegate
            {
                StationBox.Text = stations[currentStationIndex];
            });
        }

        private void StationBox_Click(object sender, EventArgs e)
        {
        }
    }
}
