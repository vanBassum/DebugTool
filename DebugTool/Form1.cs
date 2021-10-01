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



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConsoleTextbox1_OnCommand(object sender, FRMLib.Controls.CMDArgs e)
        {
            TLOGGER logger = new TLOGGER();
            logger.Level = LogLevel.VERBOSE;
            logger.Stream = e.OutputStream;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            string reply = client.SendSmallRequest(e.RawCommand).Result;

            stopwatch.Stop();
            logger.LOGI($"response time {stopwatch.ElapsedMilliseconds} ms");
            logger.LOGI($"Recieved '{reply}'");
            logger.LOGI("");
        }

        

        private async void button_connect_Click(object sender, EventArgs e)
        {
            button_connect.Enabled = false;
            TcpSocketClient tcpSocket = new TcpSocketClient();
            await tcpSocket.ConnectAsync(textBox_tcpip_host.Text, int.Parse(textBox_tcpip_port.Text));
            client.AddConnection(tcpSocket);
        }
    }
}
