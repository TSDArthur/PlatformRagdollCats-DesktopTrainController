using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialCommunication
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Reference:http://www.cnblogs.com/catcn/archive/2008/12/07/1349757.html

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.cmbSerials.Items.AddRange(SerialPort.GetPortNames());
            this.cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;//Arduino一般在最后一个串口

            this.btnRead.Enabled = true;
            this.btnStopRead.Enabled = false;
            this.btnArduinoStartSend.Enabled = this.btnArduinoStopSend.Enabled = false;
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.RefreshInfoTextBox();
        }

        private void btnStartRead_Click(object sender, EventArgs e)
        {
            this.InitialSerialPort();

            this.btnRead.Enabled = false;
            this.btnStopRead.Enabled = true;
            this.btnArduinoStartSend.Enabled = false;
            this.btnArduinoStopSend.Enabled = true;
        }

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            this.DisposeSerialPort();

            this.btnStopRead.Enabled = false;
            this.btnArduinoStartSend.Enabled = this.btnArduinoStopSend.Enabled = false;
            this.btnRead.Enabled = true;
        }

        private void btnArduinoStartSend_Click(object sender, EventArgs e)
        {
            this.btnArduinoStartSend.Enabled = false;
            this.btnArduinoStopSend.Enabled = true;
            this.ChangeArduinoSendStatus(true);
        }

        private void btnArduinoStopSend_Click(object sender, EventArgs e)
        {
            this.btnArduinoStartSend.Enabled = true;
            this.btnArduinoStopSend.Enabled = false;
            this.ChangeArduinoSendStatus(false);
        }

        private void btnCleanTextBox_Click(object sender, EventArgs e)
        {
            this.txtInfo.Text = "";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DisposeSerialPort();
        }

        private SerialPort port = null;
        /// <summary>
        /// 初始化串口实例
        /// </summary>
        private void InitialSerialPort()
        {
            try
            {
                string portName = this.cmbSerials.SelectedItem.ToString();
                port = new SerialPort(portName, 9600);
                port.Encoding = Encoding.ASCII;
                port.DataReceived += port_DataReceived;
                port.Open();
                this.ChangeArduinoSendStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化串口发生错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 关闭并销毁串口实例
        /// </summary>
        private void DisposeSerialPort()
        {
            if (port != null)
            {
                try
                {
                    this.ChangeArduinoSendStatus(false);
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                    port.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭串口发生错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 改变Arduino串口的发送状态
        /// </summary>
        /// <param name="allowSend">是否允许发送数据</param>
        private void ChangeArduinoSendStatus(bool allowSend)
        {
            if (port != null && port.IsOpen)
            {
                if (allowSend)
                {
                    port.WriteLine("serial start");
                }
                else
                {
                    port.WriteLine("serial stop");
                }
            }
        }

        /// <summary>
        /// 从串口读取数据并转换为字符串形式
        /// </summary>
        /// <returns></returns>
        private string ReadSerialData()
        {
            string value = "";
            try
            {
                if (port != null && port.BytesToRead > 0)
                {
                    value = port.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取串口数据发生错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return value;
        }

        /// <summary>
        /// 在读取到数据时刷新文本框的信息
        /// </summary>
        private void RefreshInfoTextBox()
        {
            string value = this.ReadSerialData();
            Action<string> setValueAction = text => this.txtInfo.Text += text;

            if (this.txtInfo.InvokeRequired)
            {
                this.txtInfo.Invoke(setValueAction, value);
            }
            else
            {
                setValueAction(value);
            }
        }


    }
}
