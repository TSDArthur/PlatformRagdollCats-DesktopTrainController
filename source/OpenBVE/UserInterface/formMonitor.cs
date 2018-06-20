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
			int st = 0, ed = 0;
			for (int i = 0; i < taskRecord.Length; i++)
			{
				if (taskRecord.Substring(i, 1) == "#") st = i;
			}
			for (int i = 0; i < taskRecord.Length; i++)
			{
				if (taskRecord.Substring(i, 1) == "!") ed = i;
			}
			if (ed <= st) return;
			taskRecord = taskRecord.Substring(st, ed - st + 1);
			Action<string> setValueAction = text =>
			{
				this.txtBoxRecieve.Text = taskRecord;
				doEvents(taskRecord);
				listBoxTsk.Items.Insert(0, DateTime.Now.ToString() + " >> Recieve: " + taskRecord);
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
			string mcuFrame = DataCoverter.GetDataToArduino();
			DataCoverter.RecieceFrame(frame);
			port.Write(mcuFrame);
			this.txtBoxSend.Text = mcuFrame;
			this.listBoxTsk.Items.Insert(0, DateTime.Now.ToString() + " >> Send: " + mcuFrame);
			this.listBoxTsk.SelectedIndex = this.listBoxTsk.Items.Count - 1;
			if (listBoxTsk.Items.Count > 15) listBoxTsk.Items.Clear();
			return;
		}

		private void btnHornSt_Click(object sender, EventArgs e)
		{
			TrainMethods.HornStart();
		}

		private void btnHornEd_Click(object sender, EventArgs e)
		{
			TrainMethods.HornStop();
		}

		private void btnTimer_Click(object sender, EventArgs e)
		{
			tmrUpdate.Enabled = true;
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			try
			{
				//invoke the TrainManager to throw a error
				TrainManager.Train trainInfo = TrainManager.PlayerTrain;
				txtBoxReserver.Text = "REV : " + TrainMethods.GetReverser().ToString();
				txtBoxSignal.Text = "SIG : " + TrainMethods.GetSignal().ToString();
				txtBoxSignalDis.Text = "SIG_DIS : " + TrainMethods.GetSignalDis().ToString();
				txtBoxSpeed.Text = "SPD : " + TrainMethods.GetSpeed().ToString();
				txtBoxSpdLimit.Text = "SPD_LIM : " + TrainMethods.GetSpeedLimit().ToString();
				txtBoxBrakeHandle.Text = "BKE : " + TrainMethods.GetBrake().ToString();
				txtBoxPowerHandle.Text = "PWR : " + trainInfo.Handles.Power.Driver.ToString();
				txtBoxConstSpeed.Text = "CON_SPD : " + TrainMethods.GetConstSpeed().ToString();
				//
				btnBack.Enabled = true;
				btnDown.Enabled = true;
				btnFor.Enabled = true;
				btnHornSt.Enabled = true;
				btnNeu.Enabled = true;
				btnUp.Enabled = true;
				btnAPOFF.Enabled = true;
				btnAPON.Enabled = true;
				btnEmeOn.Enabled = true;
				btnEmeOff.Enabled = true;
				btnKeyLock.Enabled = true;
				btnKeyUnlock.Enabled = true;
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
				btnAPOFF.Enabled = false;
				btnAPON.Enabled = false;
				btnEmeOn.Enabled = false;
				btnEmeOff.Enabled = false;
				btnKeyLock.Enabled = false;
				btnKeyUnlock.Enabled = false;
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
			TrainMethods.ReverserForward();
		}

		private void btnNeu_Click(object sender, EventArgs e)
		{
			TrainMethods.ReverserNeutral();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			TrainMethods.ReverserBackward();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			TrainMethods.PowerUp();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			TrainMethods.PowerDown();
		}

		private void formCM_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DisposeSerialPort();
		}

		private void formCM_Load(object sender, EventArgs e)
		{
			this.cmbSerials.Items.AddRange(SerialPort.GetPortNames());
			this.cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			TrainMethods.AttachMainTimerInterrupt(500);
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
			TrainMethods.HornStart();
		}

		private void btnHornSt_MouseUp(object sender, MouseEventArgs e)
		{
			TrainMethods.HornStop();
		}

		private void btnEmeOn_Click(object sender, EventArgs e)
		{
			TrainMethods.SetEmergency(1);
		}

		private void btnEmeOff_Click(object sender, EventArgs e)
		{
			TrainMethods.SetEmergency(0);
		}

		private void btnKeyUnlock_Click(object sender, EventArgs e)
		{
			TrainMethods.SetMasterKey(1);
		}

		private void btnKeyLock_Click(object sender, EventArgs e)
		{
			TrainMethods.SetMasterKey(0);
		}

		private void btnAPON_Click(object sender, EventArgs e)
		{
			TrainMethods.SetAutoPilot(TrainMethods.GetSpeed());
		}

		private void btnAPOFF_Click(object sender, EventArgs e)
		{
			TrainMethods.SetAutoPilot(0);
		}
	}
}
