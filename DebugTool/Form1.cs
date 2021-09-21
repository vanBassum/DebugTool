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
        TcpSocketClient tcpSocket = new TcpSocketClient();
        CancellationTokenSource cts_connect;
        public Form1()
        {
            InitializeComponent();
            menuStrip1.AddMenuItem("File/Exit", () => this.Close());
            consoleTextbox1.Start();
            consoleTextbox1.OnCommand += ConsoleTextbox1_OnCommand;
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
            request.DstMAC = new byte[]{ 0xac, 0x67, 0xb2, 0x35, 0xa5, 0xd3 };

            ResponseFrame response = client.SendRequest(request).Result;
            stopwatch.Stop();
            logger.LOGI($"Recieved {response.Data.Length} bytes from {ByteArrayToString(response.SrcMAC)} in {stopwatch.ElapsedMilliseconds}ms");
            logger.LOGI(Encoding.ASCII.GetString(response.Data));
            logger.LOGI("");







            /*
            Frame frame = new Frame();

            checkBox1.InvokeIfRequired(()=> {
                frame.Opts = (checkBox1.Checked ? Frame.Options.Broadcast : Frame.Options.None) | (checkBox2.Checked ? Frame.Options.ASCII : Frame.Options.None) | Frame.Options.Request;
            });
            

           
            frame.SetData(e.Command);
            Frame rx = client.SendFrameAndWaitForReply(frame, logger, e.CancellationToken).Result;

            if(rx != null)
            {
                string result = Encoding.ASCII.GetString(rx.GetData());
                e.OutputStream.Write(result + "\n");
            }
            */

        }

        

        private void button_connect_Click(object sender, EventArgs e)
        {
            Connect();
            /*
            tcpSocket.ConnectAsync();


            if (client.Connection == null)
            {
                
            }
            else
            {
                
                switch (client.Connection.ConnectionStatus)
                {
                    case ConnectionStatus.Connected:
                        throw new NotImplementedException();
                        break;
                    case ConnectionStatus.Disconnected:
                    case ConnectionStatus.Error:
                    case ConnectionStatus.Canceled:
                        Connect();
                        break;
                    case ConnectionStatus.Connecting:
                        cts_connect.Cancel();
                        break;
                }
                
            }
            */
        }

        async void Connect()
        {
            
            int timeout = 1000;

            if (!int.TryParse(textBox_timeout.Text, out timeout))
                textBox_timeout.Text = timeout.ToString();


            cts_connect = new CancellationTokenSource(timeout);

            switch (tabControl1.SelectedIndex)
            {
                case 0:         //TCP/IP
                    client.SetConnection(tcpSocket);
                    tcpSocket.PropertyChanged += Connection_PropertyChanged;
                    await tcpSocket.ConnectAsync(textBox_tcpip_host.Text, 31600, cts_connect);
                    break;
            }
            
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
    }
}
