using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenBve.UserInterface;
using OpenBveApi.Packages;
using OpenBve;

namespace OpenBve
{
	internal partial class formHMI : Form
	{
		public formHMI()
		{
            InitializeComponent();
        }

		static public string frameMCU = "";
		static private int nowHMISend = 0;
		static byte[] endSymmbol = new byte[3] { 0xff, 0xff, 0xff };

        private void btnStartRead_Click(object sender, EventArgs e)
        {
            this.InitialSerialPort();
            this.btnRead.Enabled = false;
            this.btnStopRead.Enabled = true;
			tmrSend.Enabled = true;
		}

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            this.DisposeSerialPort();
            this.btnStopRead.Enabled = false;
            this.btnRead.Enabled = true;
			tmrSend.Enabled = false;
		}

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DisposeSerialPort();
			try
			{
				if (MessageBox.Show("Would you want to restart the simulator?", "RAGDOLL Controller",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (!TrainMethods.RestartGame())
					{
						MessageBox.Show("Unable to restart simulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				e.Cancel = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to restart simulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private SerialPort port = null;
        /// <summary>
        /// Initialize Serials
        /// </summary>
        private void InitialSerialPort()
        {
            try
            {
                string portName = cmbSerials.SelectedItem.ToString();
				port = new SerialPort(portName, 115200)
				{
					Encoding = Encoding.ASCII,
					ReceivedBytesThreshold = 1
				};
                port.Open();
                //this.ChangeArduinoSendStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Dispose Serials
        /// </summary>
        private void DisposeSerialPort()
        {
            if (port != null)
            {
                try
                {
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                    port.Dispose();
                }
                catch (Exception ex)
                {
					MessageBox.Show("Error：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
            }
        }

		private void doEvents()
		{
			string mcuFrame = DataCoverter.GetDataToHMI(nowHMISend++);
			if (mcuFrame == string.Empty)
			{
				nowHMISend = 0;
			}
			else
			{
				port.Write(mcuFrame);
				this.txtBoxSend.Text = mcuFrame;
				port.Write(endSymmbol, 0, 3);
			}
			//update something everytime
			mcuFrame = DataCoverter.GetDataToHMI(2); //distance to next station
			port.Write(mcuFrame);
			//this.txtBoxSend.Text = mcuFrame;
			port.Write(endSymmbol, 0, 3);
			//this.listBoxTsk.Items.Insert(0, DateTime.Now.ToString() + " >> Send: " + mcuFrame);
			//this.listBoxTsk.SelectedIndex = this.listBoxTsk.Items.Count - 1;
			//if (listBoxTsk.Items.Count > 18) listBoxTsk.Items.Clear();
			return;
		}
	
		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			tmrSend.Enabled = false;
			try
			{
				//update next station distance every time

				//invoke the TrainManager to throw a error
				for (int i = 0; i < 2; i++)
				{
					doEvents();
				}
			}
			catch (Exception ex)
			{}
			tmrSend.Enabled = true;
		}

		private void formCM_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DisposeSerialPort();
		}

		private void formCM_Load(object sender, EventArgs e)
		{
			this.cmbSerials.Items.AddRange(SerialPort.GetPortNames());
			this.cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
		}

		private void cmbSerials_TextChanged(object sender, EventArgs e)
		{
			if (cmbSerials.Text == "")
			{
				btnRead.Enabled = false;
				btnStopRead.Enabled = false;
			}
			else
			{
				btnRead.Enabled = true;
				btnStopRead.Enabled = false;
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			if (SerialPort.GetPortNames().Length > cmbSerials.Items.Count)
			{
				cmbSerials.Items.Clear();
				cmbSerials.Items.AddRange(SerialPort.GetPortNames());
				cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			}

			if (SerialPort.GetPortNames().Length == 0)
			{
				btnRead.Enabled = false;
				btnStopRead.Enabled = false;
				cmbSerials.Items.Clear();
			}
		}

		private void tmrSerial_Tick(object sender, EventArgs e)
		{
			if (tmrSend.Enabled == true)
			{
				if (txtBoxSend.BackColor == Color.Black)
					txtBoxSend.BackColor = Color.DarkGreen;
				else txtBoxSend.BackColor = Color.Black;
			}
			if (SerialPort.GetPortNames().Length > cmbSerials.Items.Count)
			{
				cmbSerials.Items.Clear();
				cmbSerials.Items.AddRange(SerialPort.GetPortNames());
				cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			}

			if (SerialPort.GetPortNames().Length == 0)
			{
				btnRead.Enabled = false;
				btnStopRead.Enabled = false;
				cmbSerials.Items.Clear();
			}

			this.Location = formMonitor.formMonitorPosition;
		}
	}
}
