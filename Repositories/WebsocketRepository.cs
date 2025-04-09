using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_TMS_GoFare.Repositories
{
    internal class WebsocketRepository
    {
        private ClientWebSocket wsClient = new ClientWebSocket();
        private CancellationTokenSource cts = new CancellationTokenSource();
        public event Action<string> OnMessageReceived;
        public event Action<string> OnStatusUpdated;

        public async Task ConnectToWebSocketAsync()
        {
            try
            {
                Uri serverUri = new Uri("ws://localhost:3001");
                await wsClient.ConnectAsync(serverUri, cts.Token);

                OnStatusUpdated?.Invoke("Connected to Node.js backend via WebSocket.");
                await ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebSocket connection failed: {ex.Message}");
                OnStatusUpdated?.Invoke($"WebSocket connection failed: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024];
            try
            {
                while (wsClient.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await wsClient.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        OnStatusUpdated?.Invoke("WebSocket closed by the server.");
                    }
                    else
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        OnMessageReceived?.Invoke("Received from backend: " + message);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WebSocket receive error: " + ex.Message);
                OnStatusUpdated?.Invoke("WebSocket receive error: " + ex.Message);
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (wsClient.State == WebSocketState.Open)
            {
                var encodedMessage = Encoding.UTF8.GetBytes(message);
                try
                {
                    await wsClient.SendAsync(new ArraySegment<byte>(encodedMessage),
                        WebSocketMessageType.Text, true, cts.Token);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("WebSocket send error: " + ex.Message);
                    OnStatusUpdated?.Invoke("WebSocket send error: " + ex.Message);
                }
            }
            else
            {
                OnStatusUpdated?.Invoke("WebSocket is not open.");
            }
        }

       
        public void Disconnect()
        {
            if (wsClient.State == WebSocketState.Open || wsClient.State == WebSocketState.CloseReceived)
            {
                cts.Cancel();
                wsClient.Dispose();
            }
        }
    }
}
