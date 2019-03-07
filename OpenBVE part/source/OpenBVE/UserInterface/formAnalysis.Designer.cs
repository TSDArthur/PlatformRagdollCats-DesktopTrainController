namespace OpenBve.UserInterface
{
	partial class formAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAnalysis));
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSpeed = new System.Windows.Forms.TabPage();
            this.btnScrollMode = new System.Windows.Forms.Button();
            this.btnSeizeMode = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chartSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabIndex = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabAcceleraion = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAnalysis = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.imageListTabs = new System.Windows.Forms.ImageList(this.components);
            this.toolStripHeader = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.comboInterval = new System.Windows.Forms.ToolStripComboBox();
            this.btnStartRecord = new System.Windows.Forms.ToolStripButton();
            this.btnPauseRecord = new System.Windows.Forms.ToolStripButton();
            this.btnStopRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimerUpdate = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStripBottom.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).BeginInit();
            this.tabIndex.SuspendLayout();
            this.tabAcceleraion.SuspendLayout();
            this.tabAnalysis.SuspendLayout();
            this.toolStripHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStripBottom.Location = new System.Drawing.Point(0, 709);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.Size = new System.Drawing.Size(652, 25);
            this.toolStripBottom.TabIndex = 0;
            this.toolStripBottom.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Ready";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabSpeed);
            this.tabMain.Controls.Add(this.tabIndex);
            this.tabMain.Controls.Add(this.tabAcceleraion);
            this.tabMain.Controls.Add(this.tabAnalysis);
            this.tabMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.ImageList = this.imageListTabs;
            this.tabMain.Location = new System.Drawing.Point(0, 87);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(652, 623);
            this.tabMain.TabIndex = 2;
            // 
            // tabSpeed
            // 
            this.tabSpeed.BackColor = System.Drawing.Color.DimGray;
            this.tabSpeed.Controls.Add(this.btnScrollMode);
            this.tabSpeed.Controls.Add(this.btnSeizeMode);
            this.tabSpeed.Controls.Add(this.btnPrevious);
            this.tabSpeed.Controls.Add(this.btnNext);
            this.tabSpeed.Controls.Add(this.button1);
            this.tabSpeed.Controls.Add(this.chartSpeed);
            this.tabSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabSpeed.ImageIndex = 1;
            this.tabSpeed.Location = new System.Drawing.Point(4, 26);
            this.tabSpeed.Name = "tabSpeed";
            this.tabSpeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeed.Size = new System.Drawing.Size(644, 593);
            this.tabSpeed.TabIndex = 0;
            this.tabSpeed.Text = "Speed Analysis";
            // 
            // btnScrollMode
            // 
            this.btnScrollMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollMode.BackColor = System.Drawing.Color.DimGray;
            this.btnScrollMode.ForeColor = System.Drawing.Color.White;
            this.btnScrollMode.Location = new System.Drawing.Point(385, 564);
            this.btnScrollMode.Name = "btnScrollMode";
            this.btnScrollMode.Size = new System.Drawing.Size(103, 26);
            this.btnScrollMode.TabIndex = 9;
            this.btnScrollMode.Text = "Scroll Mode";
            this.btnScrollMode.UseVisualStyleBackColor = false;
            this.btnScrollMode.Click += new System.EventHandler(this.btnScrMode_Click);
            // 
            // btnSeizeMode
            // 
            this.btnSeizeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeizeMode.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSeizeMode.ForeColor = System.Drawing.Color.White;
            this.btnSeizeMode.Location = new System.Drawing.Point(282, 564);
            this.btnSeizeMode.Name = "btnSeizeMode";
            this.btnSeizeMode.Size = new System.Drawing.Size(103, 26);
            this.btnSeizeMode.TabIndex = 8;
            this.btnSeizeMode.Text = "Seize Mode";
            this.btnSeizeMode.UseVisualStyleBackColor = false;
            this.btnSeizeMode.Click += new System.EventHandler(this.btnSeizeMode_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackColor = System.Drawing.Color.DimGray;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(488, 564);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 26);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.DimGray;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(563, 564);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 26);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // chartSpeed
            // 
            this.chartSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartSpeed.BackColor = System.Drawing.Color.LightGray;
            this.chartSpeed.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea4.AxisX.ScrollBar.Enabled = false;
            chartArea4.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea4.AxisX.Title = "Time (s)";
            chartArea4.AxisY.MinorGrid.Enabled = true;
            chartArea4.AxisY.MinorTickMark.Enabled = true;
            chartArea4.AxisY.Title = "Speed (km/h)";
            chartArea4.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartSpeedArea";
            chartArea5.AxisX.IsStartedFromZero = false;
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea5.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea5.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea5.AxisX.ScrollBar.Enabled = false;
            chartArea5.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea5.AxisX.Title = "Overspeed Occured Time (s)";
            chartArea5.AxisY.MinorGrid.Enabled = true;
            chartArea5.AxisY.MinorTickMark.Enabled = true;
            chartArea5.AxisY.ScrollBar.Enabled = false;
            chartArea5.AxisY.Title = "Lasting Time (s)";
            chartArea5.CursorX.IsUserEnabled = true;
            chartArea5.Name = "ChartOverspeedArea";
            chartArea6.AxisX.IsMarginVisible = false;
            chartArea6.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea6.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea6.AxisX.Title = "Time (s)";
            chartArea6.AxisY.MinorGrid.Enabled = true;
            chartArea6.AxisY.MinorTickMark.Enabled = true;
            chartArea6.AxisY.ScaleView.Size = 200D;
            chartArea6.AxisY.Title = "Rate (%)";
            chartArea6.Name = "ChartOverspeedRate";
            this.chartSpeed.ChartAreas.Add(chartArea4);
            this.chartSpeed.ChartAreas.Add(chartArea5);
            this.chartSpeed.ChartAreas.Add(chartArea6);
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.MaximumAutoSize = 100F;
            legend2.Name = "Legend1";
            this.chartSpeed.Legends.Add(legend2);
            this.chartSpeed.Location = new System.Drawing.Point(1, 1);
            this.chartSpeed.Name = "chartSpeed";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartSpeedArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Speed";
            series6.ChartArea = "ChartSpeedArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Red;
            series6.Legend = "Legend1";
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series6.Name = "Speed Limit";
            series7.ChartArea = "ChartOverspeedArea";
            series7.Color = System.Drawing.Color.Red;
            series7.EmptyPointStyle.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            series7.Legend = "Legend1";
            series7.LegendText = "Overspeed Times";
            series7.Name = "OverspeedRecord";
            series7.YValuesPerPoint = 3;
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartOverspeedRate";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.LegendText = "Overspeed Rate";
            series8.Name = "OverspeedRate";
            series8.YValuesPerPoint = 4;
            this.chartSpeed.Series.Add(series5);
            this.chartSpeed.Series.Add(series6);
            this.chartSpeed.Series.Add(series7);
            this.chartSpeed.Series.Add(series8);
            this.chartSpeed.Size = new System.Drawing.Size(642, 561);
            this.chartSpeed.TabIndex = 0;
            this.chartSpeed.Text = "Speed Analysis";
            // 
            // tabIndex
            // 
            this.tabIndex.BackColor = System.Drawing.Color.Gainsboro;
            this.tabIndex.Controls.Add(this.label3);
            this.tabIndex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabIndex.ForeColor = System.Drawing.Color.Black;
            this.tabIndex.ImageIndex = 0;
            this.tabIndex.Location = new System.Drawing.Point(4, 26);
            this.tabIndex.Name = "tabIndex";
            this.tabIndex.Size = new System.Drawing.Size(644, 593);
            this.tabIndex.TabIndex = 3;
            this.tabIndex.Text = "Analysis Index";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "In Developing";
            // 
            // tabAcceleraion
            // 
            this.tabAcceleraion.BackColor = System.Drawing.Color.Gainsboro;
            this.tabAcceleraion.Controls.Add(this.label2);
            this.tabAcceleraion.ImageIndex = 2;
            this.tabAcceleraion.Location = new System.Drawing.Point(4, 26);
            this.tabAcceleraion.Name = "tabAcceleraion";
            this.tabAcceleraion.Size = new System.Drawing.Size(644, 593);
            this.tabAcceleraion.TabIndex = 4;
            this.tabAcceleraion.Text = "Acceleration Analysis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "In Developing";
            // 
            // tabAnalysis
            // 
            this.tabAnalysis.BackColor = System.Drawing.Color.Gainsboro;
            this.tabAnalysis.Controls.Add(this.label1);
            this.tabAnalysis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabAnalysis.ImageIndex = 3;
            this.tabAnalysis.Location = new System.Drawing.Point(4, 26);
            this.tabAnalysis.Name = "tabAnalysis";
            this.tabAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalysis.Size = new System.Drawing.Size(644, 593);
            this.tabAnalysis.TabIndex = 2;
            this.tabAnalysis.Text = "Energy Analysis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "In Developing";
            // 
            // imageListTabs
            // 
            this.imageListTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabs.ImageStream")));
            this.imageListTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabs.Images.SetKeyName(0, "index-o.png");
            this.imageListTabs.Images.SetKeyName(1, "Speed.png");
            this.imageListTabs.Images.SetKeyName(2, "快速路.png");
            this.imageListTabs.Images.SetKeyName(3, "energy.png");
            // 
            // toolStripHeader
            // 
            this.toolStripHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripHeader.AutoSize = false;
            this.toolStripHeader.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripHeader.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.comboInterval,
            this.btnStartRecord,
            this.btnPauseRecord,
            this.btnStopRecord,
            this.toolStripSeparator1});
            this.toolStripHeader.Location = new System.Drawing.Point(3, 59);
            this.toolStripHeader.Name = "toolStripHeader";
            this.toolStripHeader.Size = new System.Drawing.Size(647, 25);
            this.toolStripHeader.Stretch = true;
            this.toolStripHeader.TabIndex = 2;
            this.toolStripHeader.Text = "Menu";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = global::OpenBve.Properties.Resources.Timer1;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(147, 22);
            this.toolStripLabel2.Text = "Update Interval (s）: ";
            // 
            // comboInterval
            // 
            this.comboInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInterval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboInterval.MergeIndex = 0;
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(121, 25);
            this.comboInterval.SelectedIndexChanged += new System.EventHandler(this.comboInterval_SelectedIndexChanged);
            // 
            // btnStartRecord
            // 
            this.btnStartRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRecord.Image")));
            this.btnStartRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartRecord.Name = "btnStartRecord";
            this.btnStartRecord.Size = new System.Drawing.Size(70, 22);
            this.btnStartRecord.Text = "Record";
            this.btnStartRecord.Click += new System.EventHandler(this.btnStartRecord_Click);
            // 
            // btnPauseRecord
            // 
            this.btnPauseRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnPauseRecord.Image")));
            this.btnPauseRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPauseRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPauseRecord.Name = "btnPauseRecord";
            this.btnPauseRecord.Size = new System.Drawing.Size(62, 22);
            this.btnPauseRecord.Text = "Pause";
            this.btnPauseRecord.Click += new System.EventHandler(this.btnPauseRecord_Click);
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRecord.Image")));
            this.btnStopRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(61, 22);
            this.btnStopRecord.Text = "Stop";
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TimerUpdate
            // 
            this.TimerUpdate.Interval = 1000;
            this.TimerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = global::OpenBve.Properties.Resources.Banner22;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(652, 56);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // formAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(652, 734);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolStripHeader);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.toolStripBottom);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " RAGLINK+ Analysis System";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formAnalysis_Load);
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).EndInit();
            this.tabIndex.ResumeLayout(false);
            this.tabIndex.PerformLayout();
            this.tabAcceleraion.ResumeLayout(false);
            this.tabAcceleraion.PerformLayout();
            this.tabAnalysis.ResumeLayout(false);
            this.tabAnalysis.PerformLayout();
            this.toolStripHeader.ResumeLayout(false);
            this.toolStripHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripBottom;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabSpeed;
		private System.Windows.Forms.ToolStrip toolStripHeader;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripComboBox comboInterval;
		private System.Windows.Forms.TabPage tabAnalysis;
		private System.Windows.Forms.TabPage tabIndex;
		private System.Windows.Forms.ToolStripButton btnStartRecord;
		private System.Windows.Forms.ToolStripButton btnPauseRecord;
		private System.Windows.Forms.ToolStripButton btnStopRecord;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartSpeed;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Timer TimerUpdate;
		private System.Windows.Forms.ImageList imageListTabs;
		private System.Windows.Forms.Button btnSeizeMode;
		private System.Windows.Forms.Button btnScrollMode;
		private System.Windows.Forms.TabPage tabAcceleraion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}
