using System;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPT_TMS_GoFare.Models;
using IPT_TMS_GoFare.Repositories;
using Microsoft.Data.SqlClient;

namespace IPT_TMS_GoFare.Views
{
    public partial class ScannerForm : Form
    {
        SerialPort serialPort = new SerialPort("COM5", 9600);
        SessionRepository sessionRepository = new SessionRepository();
        ClientRepository clientRepository = new ClientRepository();
        WalletRepository walletRepository = new WalletRepository();
        RFIDRepository rfidRepository = new RFIDRepository();
        PaymentRepository paymentRepository = new PaymentRepository();
        WebsocketRepository ws = new WebsocketRepository(); // Our WebSocket integration.
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

            // Subscribe to WebSocket events to update UI.
            ws.OnStatusUpdated += (status) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    Info.Text += "\n" + status;
                }));
            };

            ws.OnMessageReceived += (message) =>
            {
                Invoke((MethodInvoker)(() =>
                {
                    Info.Text += "\n" + message;
                }));
            };

            // Start the WebSocket connection asynchronously.
            Task.Run(() => ws.ConnectToWebSocketAsync());
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
                if (wallet.balance <= 0 && wallet.loaned > 0)
                {
                    MessageBox.Show("You have no balance and your loan is already maxed out. Please recharge your wallet.");
                    return;
                }

                sessionRepository.AddSession(rfid, currentStation);
                Info.Text = $"Session started\nPick Up: {currentStation}\nRFID: {record.rfid}\nBalance: {wallet.balance}";

                // Optionally, notify backend via WebSocket.
                Task.Run(() => ws.SendMessageAsync($"Session started for RFID: {rfid} at {currentStation}"));
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

                bool successful = paymentRepository.Pay(wallet, fare);

                if (!successful)
                {
                    Info.Text = $"Payment failed. Insufficient funds.";
                    return;
                }
                else
                {
                    sessionRepository.RemoveSession(rfid);
                    Info.Text = $"Session ended\nPick Up: {pickUp}\nDrop Off: {currentStation}\nRFID: {record.rfid}\nFare: {fare}\nNew Balance: {wallet.balance}\nLoan: {wallet.loaned}";

                    // Optionally, notify backend via WebSocket.
                    Task.Run(() => ws.SendMessageAsync($"Session ended for RFID: {rfid}. Fare: {fare}"));
                }
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
