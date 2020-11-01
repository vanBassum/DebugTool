using FRMLib;
using STDLib.Ethernet;
using STDLib.JBVProtocol;
using STDLib.JBVProtocol.Devices;
using STDLib.JBVProtocol.DSP50xx;
using STDLib.JBVProtocol.FunctionGenerator;
using STDLib.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugTool
{
    public partial class Form1 : Form
    {
        JBVClient client = new JBVClient(SoftwareID.DebugTool);
        TcpSocketClient socket = new TcpSocketClient();
        BindingList<Device> devices = new BindingList<Device>();
        Device selectedDevice;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.SetConnection(new TCPConnection(socket));
            client.LeaseRecieved += Client_LeaseRecieved;
            Device.Init(client);
            Device.OnDeviceFound += Device_OnDeviceFound;
            listBox1.DataSource = devices;
        }

        private void Client_LeaseRecieved(object sender, Lease e)
        {
            label1.InvokeIfRequired(() => label1.Text = e.ToString());
        }

        private void Device_OnDeviceFound(object sender, Device e)
        {
            listBox1.InvokeIfRequired(()=> devices.Add(e));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = !await socket.ConnectAsync(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            devices.Clear();
            Device.SearchDevices();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Device dev)
                selectedDevice = dev;

        }

        private void SetLED(object sender, EventArgs e)
        {
            if(selectedDevice is FunctionGenerator dev)
            {
                dev.SetLED(checkBox1.Checked);
            }
        }

        private void SetFreq(object sender, EventArgs e)
        {
            if (selectedDevice is FunctionGenerator dev)
            {
                double freq;
                if (double.TryParse(textBox2.Text, out freq))
                {
                    dev.SetFrequency(freq);
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetFreq(null, null);
        }

        double freq = 100;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (selectedDevice is FunctionGenerator dev)
                dev.SetFrequency(freq++);
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 100;
        }
    }
}
