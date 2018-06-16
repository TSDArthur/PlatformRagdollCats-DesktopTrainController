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
	internal partial class formMonitor : Form
	{
		public formMonitor()
		{
            InitializeComponent();
        }

		public string taskRecord = "";
		public string frameMCU = "";

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.RefreshInfoTextBox();
        }

        private void btnStartRead_Click(object sender, EventArgs e)
        {
            this.InitialSerialPort();

            this.btnRead.Enabled = false;
            this.btnStopRead.Enabled = true;
        }

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            this.DisposeSerialPort();

            this.btnStopRead.Enabled = false;
            this.btnRead.Enabled = true;
        }

        private void btnArduinoStartSend_Click(object sender, EventArgs e)
        {
            this.ChangeArduinoSendStatus(true);
        }

        private void btnArduinoStopSend_Click(object sender, EventArgs e)
        {
            this.ChangeArduinoSendStatus(false);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DisposeSerialPort();
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
                port = new SerialPort(portName, 115200);
                port.Encoding = Encoding.ASCII;
				port.ReceivedBytesThreshold = 1;
				port.DataReceived += port_DataReceived;
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
                    this.ChangeArduinoSendStatus(false);
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

        /// <summary>
        /// Switch the controller
        /// </summary>
        /// <param name="allowSend">is it on?</param>
        private void ChangeArduinoSendStatus(bool allowSend)
        {
            if (port != null && port.IsOpen)
            {
                if (allowSend)
                {
                    port.WriteLine("1");
                }
                else
                {
                    port.WriteLine("0");
                }
            }
        }

        /// <summary>
        /// read data from serial
        /// </summary>
        /// <returns></returns>
        private string ReadSerialData()
        {
            string value = String.Empty;
            try
            {
				port.ReceivedBytesThreshold = port.ReadBufferSize;
				while (port != null && port.BytesToRead > 0)
                {
					value += port.ReadExisting();
				}
            }
            catch (Exception ex)
            {
				MessageBox.Show("Error：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			port.ReceivedBytesThreshold = 1;
			return value;
        }

        /// <summary>
        /// refresh the task list
        /// </summary>
        private void RefreshInfoTextBox()
        {
			string value = this.ReadSerialData();
			taskRecord += value;
			if (taskRecord.Substring(taskRecord.Length-1,1)!="!") return;
			Action<string> setValueAction = text =>
			{
				this.txtBoxRecieve.Text = text;
				doEvents(taskRecord);
				listBoxTsk.Items.Insert(0, DateTime.Now.ToString() + " >> Recieve:" + taskRecord);
				taskRecord = String.Empty;
			};

			if (this.txtBoxRecieve.InvokeRequired)
            {
                this.txtBoxRecieve.Invoke(setValueAction, taskRecord);
            }
            else
            {
                setValueAction(taskRecord);
            }
        }

		private void doEvents(string frame)
		{
			string mcuFrame = FrameCoverter.GetDataToArduino();
			FrameCoverter.RecieceFrame(frame);
			port.Write(mcuFrame);
			this.txtBoxSend.Text = mcuFrame;
			this.listBoxTsk.Items.Insert(0, DateTime.Now.ToString() + " >> Send:" + mcuFrame);
			this.listBoxTsk.SelectedIndex = this.listBoxTsk.Items.Count - 1;
			if (listBoxTsk.Items.Count > 25) listBoxTsk.Items.Clear();
			return;
		}

		private void btnHornSt_Click(object sender, EventArgs e)
		{
			TrainFunctions.HornStart();
		}

		private void btnHornEd_Click(object sender, EventArgs e)
		{
			TrainFunctions.HornStop();
		}

		private void btnTimer_Click(object sender, EventArgs e)
		{
			tmrUpdate.Enabled = true;
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			try
			{
				txtBoxPwr.Text = TrainFunctions.GetPower().ToString();
				txtBoxReserver.Text = TrainFunctions.GetReverser().ToString();
				txtBoxSignal.Text = TrainFunctions.GetSignal().ToString();
				txtBoxSignalDis.Text = TrainFunctions.GetSignalDis().ToString();
				txtBoxSpeed.Text = TrainFunctions.GetSpeed().ToString();
				txtBoxSpdLimit.Text = TrainFunctions.GetSpeedLimit().ToString();
				txtBoxBrakeHandle.Text = TrainManager.PlayerTrain.Handles.Brake.Actual.ToString();
				txtBoxPowerHandle.Text = TrainManager.PlayerTrain.Handles.Power.Actual.ToString();
				txtBoxConstSpeed.Text = TrainFunctions.GetConstSpeed().ToString();
				//
				btnBack.Enabled = true;
				btnDown.Enabled = true;
				btnFor.Enabled = true;
				btnHornSt.Enabled = true;
				btnNeu.Enabled = true;
				btnUp.Enabled = true;
			}
			catch (Exception ex)
			{
				//continue
				btnBack.Enabled = false;
				btnDown.Enabled = false;
				btnFor.Enabled = false;
				btnHornSt.Enabled = false;
				btnNeu.Enabled = false;
				btnUp.Enabled = false;
			}

			if (SerialPort.GetPortNames().Length > cmbSerials.Items.Count)
			{
				cmbSerials.Items.Clear();
				cmbSerials.Items.AddRange(SerialPort.GetPortNames());
				cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			}

			if (SerialPort.GetPortNames().Length==0)
			{
				btnRead.Enabled = false;
				btnStopRead.Enabled = false;
				cmbSerials.Items.Clear();
			}
		}

		private void btnFor_Click(object sender, EventArgs e)
		{
			TrainFunctions.ReverserForward();
		}

		private void btnNeu_Click(object sender, EventArgs e)
		{
			TrainFunctions.ReverserNeutral();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			TrainFunctions.ReverserBackward();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			TrainFunctions.PowerUp();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			TrainFunctions.PowerDown();
		}

		private void formCM_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DisposeSerialPort();
		}

		private void formCM_Load(object sender, EventArgs e)
		{
			this.cmbSerials.Items.AddRange(SerialPort.GetPortNames());
			this.cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			TrainFunctions.AttachMainTimerInterrupt(500);
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

		private void btnHornSt_MouseDown(object sender, MouseEventArgs e)
		{
			TrainFunctions.HornStart();
		}

		private void btnHornSt_MouseUp(object sender, MouseEventArgs e)
		{
			TrainFunctions.HornStop();
		}

		private void btnEmeOn_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetEmergency(1);
		}

		private void btnEmeOff_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetEmergency(0);
		}

		private void btnKeyUnlock_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetMasterKey(1);
		}

		private void btnKeyLock_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetMasterKey(0);
		}

		private void btnAPON_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetAutoPilot(TrainFunctions.GetSpeed());
		}

		private void btnAPOFF_Click(object sender, EventArgs e)
		{
			TrainFunctions.SetAutoPilot(0);
		}
	}
}
