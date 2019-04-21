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
		static public Point formMonitorPosition = new Point(0,0);
		static public bool isConnected = false;
		static public int selectPort = 0;
		static public int connectedLasting = 0;
		static public int BaudRate = 115200;

		void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.RefreshInfoTextBox();
        }

        private void btnStartRead_Click(object sender, EventArgs e)
        {
			//SerialManager.Enabled = false;
			this.DisposeSerialPort();
            this.InitialSerialPort(cmbSerials.SelectedItem.ToString(), BaudRate);
            this.btnRead.Enabled = false;
            this.btnStopRead.Enabled = true;
			toolStripLabel.Text = "Controller Connected.";
		}

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            this.DisposeSerialPort();
			this.btnStopRead.Enabled = false;
            this.btnRead.Enabled = true;
			toolStripLabel.Text = "Ready.";
			txtBoxRecieve.Text = "";
			txtBoxSend.Text = "";
		}

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
			try
			{
				if (MessageBox.Show("Would you want to restart the simulator?", "RAGLINK+ CabViewer",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.DisposeSerialPort();
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
        private void InitialSerialPort(String portName, int BAUD)
        {
            try
            {
                port = new SerialPort(portName, BAUD);
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
				if (taskRecord.Substring(i, 1) == "#")
				{
					st = i;
					break;
				}
			}
			for (int i = taskRecord.Length - 1; i >= 0; i--)
			{
				if (taskRecord.Substring(i, 1) == "!")
				{
					ed = i;
					break;
				}
			}
			if (ed <= st) return;
			taskRecord = taskRecord.Substring(st, ed - st + 1);
			Action<string> setValueAction = text =>
			{
				this.txtBoxRecieve.Text = taskRecord;
				doEvents(taskRecord);
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
			DataCoverter.RecieceFrame(frame);
			string mcuFrame = DataCoverter.GetDataToArduino();
			port.Write(mcuFrame);
			this.txtBoxSend.Text = mcuFrame;
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
				txtBoxSpeed.Text = "SPD : " + ((double)((int)(TrainMethods.GetSpeedDouble() * 10)) / 10.0).ToString();
				txtBoxSpdLimit.Text = "SPD_LIM : " + TrainMethods.GetSpeedLimit().ToString();
				txtBoxBrakeHandle.Text = "BKE : " + TrainMethods.GetBrake().ToString();
				txtBoxPowerHandle.Text = "PWR : " + trainInfo.Handles.Power.Driver.ToString();
				txtBoxConstSpeed.Text = "ATC_SPD : " + ((double)((int)(TrainMethods.GetATCCurrentSpeed() * 10)) / 10.0).ToString();
				txtBoxCurrentStation.Text = "CUR_STA : " + TrainMethods.GetCurrentStationName();
				txtBoxNextStation.Text = "NEX_STA : " + TrainMethods.GetNextStationName();
				txtBoxNextStationDis.Text = "NEX_STADIS : " + 
					(TrainMethods.GetNextStationDis() >= 1000 ? 
					decimal.Round(decimal.Parse((TrainMethods.GetNextStationDis() / 1000).ToString()) , 2) : 
					decimal.Round(decimal.Parse((TrainMethods.GetNextStationDis()).ToString()), 1)) + 
					" / " + (TrainMethods.GetNextStationStopMode() == 1 ? "VIA" : "STOP") + " / " + 
					(TrainMethods.GetStopDis() == double.NegativeInfinity ? "N/A" : decimal.Round(decimal.Parse(TrainMethods.GetStopDis().ToString()), 1).ToString());
				txtBoxArrivalTime.Text = "AT : " + TrainMethods.GetNextStationArrialTime();
				txtBoxDepartureTime.Text = "DT : " + TrainMethods.GetCurrentStationDepartureTime();
				txtBoxCurrentTime.Text = "TIME : " + TrainMethods.GetCurrentTime();
				txtBoxRouteName.Text = "ROUTE_NAME : " + TrainMethods.GetCurrentRouteName();
				txBoxTrainName.Text = "TRAIN : " + TrainMethods.GetCurrentTrainName();
				txtBoxCylinder.Text = "CYL : " + TrainMethods.GetCylinderPressure().ToString();
				txtBoxPipe.Text = "PIP : " + TrainMethods.GetPipePressure().ToString();
				txtBoxDestination.Text = "DEST_STA : " + TrainMethods.GetDestinationName();
				txtBoxStationCounter.Text = "STATION : " + TrainMethods.GetNextStationIndex().ToString() + " / " + TrainMethods.GetStationCount().ToString();
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
				btnRestartGame.Enabled = true;
				btnLeftDoorClose.Enabled = true;
				btnLeftDoorOpen.Enabled = true;
				btnRightDoorClose.Enabled = true;
				btnRightDoorOpen.Enabled = true;
				//
				if (toolStripLabel.Text == "Environment initializing...")
					toolStripLabel.Text = "Ready.";
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
				btnRestartGame.Enabled = false;
				btnLeftDoorClose.Enabled = false;
				btnLeftDoorOpen.Enabled = false;
				btnRightDoorClose.Enabled = false;
				btnRightDoorOpen.Enabled = false;
				//
				toolStripLabel.Text = "Environment initializing...";
			}

			if (SerialPort.GetPortNames().Length > cmbSerials.Items.Count)
			{
				cmbSerials.Items.Clear();
				cmbSerials.Items.AddRange(SerialPort.GetPortNames());
				cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
				//
			}

			if (SerialPort.GetPortNames().Length == 0)
			{
				DisposeSerialPort();
				btnRead.Enabled = false;
				btnStopRead.Enabled = false;
				cmbSerials.Items.Clear();
			}
			//

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
			this.Top = 50;
			this.Left = 1;
			this.cmbSerials.Items.AddRange(SerialPort.GetPortNames());
			this.cmbSerials.SelectedIndex = this.cmbSerials.Items.Count - 1;
			formMonitorPosition.X = this.Location.X;
			formMonitorPosition.Y = this.Location.Y + 594;
			TrainMethods.AttachMainTimerInterrupt(500);
			isConnected = false;
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
			toolStripLabel.Text = "Refreshing devices...";

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

			toolStripLabel.Text = "Ready.";
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
			TrainMethods.SetATCState(true);
		}

		private void btnAPOFF_Click(object sender, EventArgs e)
		{
			TrainMethods.SetATCState(false);
		}

		private void btnRestartGame_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Would you want to restart the simulator?", "RAGLINK+ CabViewer",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (!TrainMethods.RestartGame())
					{
						MessageBox.Show("Unable to restart simulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to restart simulator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnLeftDoorOpen_Click(object sender, EventArgs e)
		{
			TrainMethods.LeftDoorOpen();
		}

		private void btnLeftDoorClose_Click(object sender, EventArgs e)
		{
			TrainMethods.LeftDoorClose();
		}

		private void btnRightDoorOpen_Click(object sender, EventArgs e)
		{
			TrainMethods.RightDoorOpen();
		}

		private void btnRightDoorClose_Click(object sender, EventArgs e)
		{
			TrainMethods.RightDoorClose();
		}

		private void formMonitor_Move(object sender, EventArgs e)
		{
			formMonitorPosition.X = this.Location.X;
			formMonitorPosition.Y = this.Location.Y + 594;
		}
	}
}
