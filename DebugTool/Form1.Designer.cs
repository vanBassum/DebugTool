namespace DebugTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_tcpip_port = new System.Windows.Forms.TextBox();
            this.textBox_tcpip_host = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_timeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.consoleTextbox1 = new FRMLib.Controls.ConsoleTextbox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.frameTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(211, 715);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(205, 82);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox_tcpip_port);
            this.tabPage1.Controls.Add(this.textBox_tcpip_host);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(197, 56);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP/IP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // textBox_tcpip_port
            // 
            this.textBox_tcpip_port.Location = new System.Drawing.Point(94, 32);
            this.textBox_tcpip_port.Name = "textBox_tcpip_port";
            this.textBox_tcpip_port.Size = new System.Drawing.Size(94, 20);
            this.textBox_tcpip_port.TabIndex = 8;
            this.textBox_tcpip_port.Text = "31600";
            // 
            // textBox_tcpip_host
            // 
            this.textBox_tcpip_host.Location = new System.Drawing.Point(94, 6);
            this.textBox_tcpip_host.Name = "textBox_tcpip_host";
            this.textBox_tcpip_host.Size = new System.Drawing.Size(94, 20);
            this.textBox_tcpip_host.TabIndex = 6;
            this.textBox_tcpip_host.Text = "192.168.11.40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Host";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button_connect);
            this.panel1.Controls.Add(this.textBox_timeout);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 112);
            this.panel1.TabIndex = 12;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(94, 58);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "ASCII";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Broadcast";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(82, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Disconnected";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(94, 29);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(94, 23);
            this.button_connect.TabIndex = 10;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_timeout
            // 
            this.textBox_timeout.Location = new System.Drawing.Point(94, 3);
            this.textBox_timeout.Name = "textBox_timeout";
            this.textBox_timeout.Size = new System.Drawing.Size(94, 20);
            this.textBox_timeout.TabIndex = 9;
            this.textBox_timeout.Text = "1000";
            this.textBox_timeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time-out";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1040, 715);
            this.splitContainer2.SplitterDistance = 862;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.button2);
            this.splitContainer4.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.consoleTextbox1);
            this.splitContainer4.Size = new System.Drawing.Size(862, 715);
            this.splitContainer4.SplitterDistance = 222;
            this.splitContainer4.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Discovery";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // consoleTextbox1
            // 
            this.consoleTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleTextbox1.Location = new System.Drawing.Point(0, 0);
            this.consoleTextbox1.Name = "consoleTextbox1";
            this.consoleTextbox1.Size = new System.Drawing.Size(862, 489);
            this.consoleTextbox1.TabIndex = 0;
            this.consoleTextbox1.Text = "";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 24);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(1255, 715);
            this.splitContainer3.SplitterDistance = 211;
            this.splitContainer3.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1255, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(DebugTool.Form1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Tert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 739);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frameTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FRMLib.Controls.ConsoleTextbox consoleTextbox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_tcpip_port;
        private System.Windows.Forms.TextBox textBox_tcpip_host;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_timeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource frameTypesBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

