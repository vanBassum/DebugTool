using FRMLib;
using STDLib.Ethernet;
using STDLib.JBVProtocol;
using STDLib.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        JBVClient client = new JBVClient(SoftwareID.DebugTool);
        TcpSocketClient tcpSocket = new TcpSocketClient();
        CancellationTokenSource cts_connect;
        public Form1()
        {
            InitializeComponent();
            menuStrip1.AddMenuItem("File/Exit", () => this.Close());
            consoleTextbox1.Start();
            consoleTextbox1.OnCommand += ConsoleTextbox1_OnCommand;
        }

        private void ConsoleTextbox1_OnCommand(object sender, FRMLib.Controls.CMDArgs e)
        {
            TLOGGER logger = new TLOGGER();
            logger.Level = LogLevel.VERBOSE;
            logger.Stream = e.OutputStream;
            
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


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (client.Connection == null)
            {
                Connect();
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
        }

        void Connect()
        {
            int timeout = 1000;

            if (!int.TryParse(textBox_timeout.Text, out timeout))
                textBox_timeout.Text = timeout.ToString();


            cts_connect = new CancellationTokenSource(timeout);

            switch (tabControl1.SelectedIndex)
            {
                case 0:         //TCP/IP
                    client.Connection = tcpSocket;
                    client.Connection.PropertyChanged += Connection_PropertyChanged;
                    tcpSocket.ConnectAsync(textBox_tcpip_host.Text, 31600, cts_connect);
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
