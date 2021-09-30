using FRMLib;
using STDLib.Ethernet;
using STDLib.JBVProtocol;
using STDLib.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugTool
{
    public partial class Form1 : Form
    {
        Client client = new Client();
        
        UdpSocketClient udpSocket = new UdpSocketClient();


        public Form1()
        {
            InitializeComponent();
            menuStrip1.AddMenuItem("File/Exit", () => this.Close());
            consoleTextbox1.Start();
            consoleTextbox1.OnCommand += ConsoleTextbox1_OnCommand;

            udpSocket.Connect(new IPEndPoint(IPAddress.Broadcast, 51100));
            client.AddConnection(udpSocket);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 3 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        private void ConsoleTextbox1_OnCommand(object sender, FRMLib.Controls.CMDArgs e)
        {
            TLOGGER logger = new TLOGGER();
            logger.Level = LogLevel.VERBOSE;
            logger.Stream = e.OutputStream;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RequestFrame request = new RequestFrame();
            request.Data = e.Command;
            request.DstAddress = 0x000010c2d18e0d84;

            ResponseFrame response = client.SendRequest(request).Result;
            stopwatch.Stop();
            logger.LOGI($"Recieved {response.Data.Length} bytes from {response.DstAddress.ToString("X16")} in {stopwatch.ElapsedMilliseconds}ms");
            logger.LOGI(Encoding.ASCII.GetString(response.Data));
            logger.LOGI("");
        }

        

        private async void button_connect_Click(object sender, EventArgs e)
        {
            button_connect.Enabled = false;
            TcpSocketClient tcpSocket = new TcpSocketClient();
            await tcpSocket.ConnectAsync(textBox_tcpip_host.Text, int.Parse(textBox_tcpip_port.Text));
            client.AddConnection(tcpSocket);
        }


        private void Connection_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
            if(e.PropertyName == nameof(IConnection.ConnectionStatus))
            {
                if (sender is IConnection connection)
                {
                    textBox1.InvokeIfRequired(()=> {
                        textBox1.Text = connection.ConnectionStatus.ToString();

                        switch (connection.ConnectionStatus)
                        {
                            case ConnectionStatus.Connected:
                                button_connect.Text = "Disconnect";
                                break;
                            case ConnectionStatus.Disconnected:
                            case ConnectionStatus.Error:
                            case ConnectionStatus.Canceled:
                                button_connect.Text = "Connect";
                                break;
                            case ConnectionStatus.Connecting:
                                button_connect.Text = "Cancel";
                                break;
                        }
                    });
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.SendDiscoveryRequest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Test();
        }
    }
}
