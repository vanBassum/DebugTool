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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (string file in Directory.GetFiles(path, "*.lst"))
            {
                listBox2.Items.Add(Path.GetFileName(file));
            }


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

        private async void button3_Click(object sender, EventArgs e)
        {
            if (selectedDevice is FunctionGenerator dev)
            {
                bool oke = await dev.FillScreen(pictureBox1.BackColor);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color c = cd.Color;
                pictureBox1.BackColor = c;
            }
        }


        int GetInt(string line, string pattern, int def)
        {
            int val = def;
            Match m = Regex.Match(line, pattern);
            if (m.Success)
                val = int.Parse(m.Groups[1].Value);
            return val;
        }



        async Task<bool> ParseLine(string line)
        {
            if (selectedDevice is FunctionGenerator dev)
            {
                if (line.StartsWith("BGND"))
                {
                    Color c = Color.Black;
                    int r = GetInt(line, @"R:(\d+)", c.R);
                    int g = GetInt(line, @"G:(\d+)", c.G);
                    int b = GetInt(line, @"B:(\d+)", c.B);
                    return await dev.FillScreen(Color.FromArgb(r, g, b));
                }
                else if (line.StartsWith("DELAY"))
                {
                    int delay = GetInt(line, @"T:(\d+)", 1000);
                    System.Threading.Thread.Sleep(delay);
                    return true;
                }
                else if (line.StartsWith("LINE"))
                {
                    Color c = Color.Red;
                    int r = GetInt(line, @"R:(\d+)", c.R);
                    int g = GetInt(line, @"G:(\d+)", c.G);
                    int b = GetInt(line, @"B:(\d+)", c.B);
                    UInt16 x1 = (UInt16)GetInt(line, @"X1:(\d+)", 0);
                    UInt16 x2 = (UInt16)GetInt(line, @"X2:(\d+)", 0);
                    UInt16 y1 = (UInt16)GetInt(line, @"Y1:(\d+)", 0);
                    UInt16 y2 = (UInt16)GetInt(line, @"Y2:(\d+)", 0);

                    return await dev.DrawLine(x1, y1, x2, y2, Color.FromArgb(r, g, b));
                }
            }
            return false;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;

            if (listBox2.SelectedItem is string file)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string[] lines;

                using (StreamReader rdr = new StreamReader(Path.Combine(path, file)))
                    lines = rdr.ReadToEnd().Split('\n');



                int i = 0;

                for(i = 0; i<lines.Length; i++)
                {
                    
                    string line = lines[i].Trim('\r');

                    label2.Text = $"{i} - {line}";

                    if (line.StartsWith("GOTO"))
                    {
                        string label = line.Substring(4).Trim('\t').Trim(' ') + ":";

                        int ind = 0;
                        for (ind = 0; ind < lines.Length; ind++)
                        {
                            if (lines[ind].StartsWith(label))
                            {
                                i = ind;   //Next round i will be increased by 1.
                                break;
                            }
                        }
                    }
                    else
                    {
                        bool oke = await ParseLine(line);
                        if (oke)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
            button4.Enabled = true;
        }
    }
}
