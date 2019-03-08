using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenBve.UserInterface;
using OpenBveApi.Packages;
using OpenBve;

namespace OpenBve
{
	public partial class formAnalysis : Form
	{
		public formAnalysis()
		{
			InitializeComponent();
		}

		static private int xData;
		static private int yData;
		static private int overspeedCount;
		static private int overspeedLastingTime;
		static private bool isInOverspeedProcess;
		static private bool isInRecord;

		private void formAnalysis_Load(object sender, EventArgs e)
		{
			comboInterval.SelectedIndex = 0;
			//
			this.Location = new Point(formMonitor.formMonitorPosition.X + 438,
				formMonitor.formMonitorPosition.Y - 540);
			//this.TopMost = true;
			//
			isInRecord = false;
			xData = 0;
			yData = 0;
			overspeedCount = 0;
			overspeedLastingTime = 0;
			isInOverspeedProcess = false;
		}

		//Add data to speed
		private void AddDataToSpeedChart(double Time)
		{
			try
			{
				double speedData = Math.Abs(TrainMethods.GetSpeed());
				chartSpeed.Series[0].Points.AddXY(Time, speedData);
				//
				chartSpeed.ChartAreas["ChartSpeedArea"].AxisX.ScaleView.Position = xData - chartSpeed.ChartAreas["ChartSpeedArea"].AxisX.ScaleView.Size;
			}
			catch(Exception ex) { };
		}

		//Add data to speed limit
		private void AddDataToSpeedLimitChart(double Time)
		{
			try
			{
				double speedData = TrainMethods.GetSpeedLimit();
				chartSpeed.Series[1].Points.AddXY(Time, speedData);
				//
				chartSpeed.ChartAreas["ChartSpeedArea"].AxisX.ScaleView.Position =
					xData - chartSpeed.ChartAreas["ChartSpeedArea"].AxisX.ScaleView.Size;
			}
			catch (Exception ex) { };
		}

		//Add data to overspeed counter
		private void AddDataToOverspeedCount(double Time)
		{
			try
			{
				
				double speedLimit = TrainMethods.GetSpeedLimit();
				double speedData = Math.Abs(TrainMethods.GetSpeed());
				//
				if (speedData > speedLimit)
				{
					if (isInOverspeedProcess)
					{
						overspeedLastingTime += TimerUpdate.Interval / 1000;
					}
					else
					{
						isInOverspeedProcess = true;
						overspeedCount++;
						overspeedLastingTime = 0;
					}
				}
				else
				{
					if (isInOverspeedProcess)
					{
						chartSpeed.Series[2].Points.AddXY(Time - overspeedLastingTime, overspeedLastingTime);
						//
						chartSpeed.ChartAreas["ChartOverspeedArea"].AxisX.ScaleView.Position =
							xData - chartSpeed.ChartAreas["ChartOverspeedArea"].AxisX.ScaleView.Size;
						isInOverspeedProcess = false;
					}
				}

			}catch (Exception ex) { };
		}

		//Add data to overspeed rate
		private void AddDataToOverspeedRate(double Time)
		{
			try
			{
				double speedLimit = TrainMethods.GetSpeedLimit();
				double speedData = Math.Abs(TrainMethods.GetSpeed());
				double rate = 0;
				//
				if (speedData <= speedLimit)
				{
					rate = 0;
				}
				else
				{
					rate = (speedData - speedLimit) / speedLimit * 100;
				}
				//
				chartSpeed.Series[3].Points.AddXY(Time, rate);
				//
				chartSpeed.ChartAreas["ChartOverspeedRate"].AxisX.ScaleView.Position =
							xData - chartSpeed.ChartAreas["ChartOverspeedRate"].AxisX.ScaleView.Size;
			}catch (Exception ex) { };
		}

		//Set seize mode
		private void SetChartAsSeizeMode(System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea)
		{
			try
			{
				chartArea.AxisX.ScaleView.Size = chartArea.AxisX.ScaleView.MinSize;
				chartArea.AxisX.Minimum = 0;
				chartArea.AxisX.ScrollBar.Enabled = false;
			}catch(Exception ex) { };
		}

		//Set scroll mode
		private void SetChartAsScrollMode(System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea, int size)
		{
			try
			{
				chartArea.AxisX.ScaleView.Size = size;
				chartArea.AxisX.Minimum = 0;
				chartArea.AxisX.ScrollBar.Enabled = true;
			}catch(Exception ex) { };
		}

		private void comboInterval_SelectedIndexChanged(object sender, EventArgs e)
		{
			TimerUpdate.Interval = Int32.Parse(comboInterval.Items[comboInterval.SelectedIndex].ToString()) * 1000;
		}

		private void TimerUpdate_Tick(object sender, EventArgs e)
		{
			if (isInRecord)
			{
				//Update Speed
				AddDataToSpeedChart(xData);
				AddDataToSpeedLimitChart(xData);
				//Update Overspeed
				AddDataToOverspeedCount(xData);
				AddDataToOverspeedRate(xData);
			}
			xData = xData + 1;
		}

		private void btnStopRecord_Click(object sender, EventArgs e)
		{
			try
			{
				TimerUpdate.Enabled = false;
				isInRecord = false;
			}
			catch (Exception ex) { };
		}

		private void btnPauseRecord_Click(object sender, EventArgs e)
		{
			TimerUpdate.Enabled = true;
			isInRecord = false;
		}

		private void btnStartRecord_Click(object sender, EventArgs e)
		{
			try
			{
				TimerUpdate.Enabled = true;
				isInRecord = true;
			}
			catch (Exception ex) { };
		}

		private void btnScrMode_Click(object sender, EventArgs e)
		{
			SetChartAsScrollMode(chartSpeed.ChartAreas["ChartSpeedArea"], 9);
			SetChartAsScrollMode(chartSpeed.ChartAreas["ChartOverspeedArea"], 19);
			SetChartAsScrollMode(chartSpeed.ChartAreas["ChartOverspeedRate"], 9);
			//
			btnScrollMode.BackColor = Color.DarkGreen;
			btnSeizeMode.BackColor = Color.DimGray;
		}

		private void btnSeizeMode_Click(object sender, EventArgs e)
		{
			SetChartAsSeizeMode(chartSpeed.ChartAreas["ChartSpeedArea"]);
			SetChartAsSeizeMode(chartSpeed.ChartAreas["ChartOverspeedArea"]);
			SetChartAsSeizeMode(chartSpeed.ChartAreas["ChartOverspeedRate"]);
			//
			btnScrollMode.BackColor = Color.DimGray;
			btnSeizeMode.BackColor = Color.DarkGreen;
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{

		}

		private void btnNext_Click(object sender, EventArgs e)
		{

		}
	}
}
