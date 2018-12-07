namespace OpenBve
{
	partial class formMonitor
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMonitor));
            this.toolScripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSerials = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.lblMainSwitch = new System.Windows.Forms.ToolStripLabel();
            this.btnRead = new System.Windows.Forms.ToolStripButton();
            this.btnStopRead = new System.Windows.Forms.ToolStripButton();
            this.txtBoxConstSpeed = new System.Windows.Forms.TextBox();
            this.btnAPOFF = new System.Windows.Forms.Button();
            this.btnKeyLock = new System.Windows.Forms.Button();
            this.btnEmeOff = new System.Windows.Forms.Button();
            this.btnAPON = new System.Windows.Forms.Button();
            this.btnKeyUnlock = new System.Windows.Forms.Button();
            this.btnEmeOn = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.txtBoxRecieve = new System.Windows.Forms.TextBox();
            this.btnHornSt = new System.Windows.Forms.Button();
            this.btnNeu = new System.Windows.Forms.Button();
            this.txtBoxPowerHandle = new System.Windows.Forms.TextBox();
            this.txtBoxBrakeHandle = new System.Windows.Forms.TextBox();
            this.btnFor = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtBoxSpdLimit = new System.Windows.Forms.TextBox();
            this.txtBoxSpeed = new System.Windows.Forms.TextBox();
            this.txtBoxSignalDis = new System.Windows.Forms.TextBox();
            this.txtBoxSignal = new System.Windows.Forms.TextBox();
            this.txtBoxReserver = new System.Windows.Forms.TextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.txtBoxCurrentStation = new System.Windows.Forms.TextBox();
            this.txtBoxNextStation = new System.Windows.Forms.TextBox();
            this.txtBoxArrivalTime = new System.Windows.Forms.TextBox();
            this.txtBoxNextStationDis = new System.Windows.Forms.TextBox();
            this.txtBoxDepartureTime = new System.Windows.Forms.TextBox();
            this.txtBoxCurrentTime = new System.Windows.Forms.TextBox();
            this.txtBoxRouteName = new System.Windows.Forms.TextBox();
            this.txBoxTrainName = new System.Windows.Forms.TextBox();
            this.btnRestartGame = new System.Windows.Forms.Button();
            this.btnLeftDoorOpen = new System.Windows.Forms.Button();
            this.btnLeftDoorClose = new System.Windows.Forms.Button();
            this.btnRightDoorOpen = new System.Windows.Forms.Button();
            this.btnRightDoorClose = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolScripMain.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolScripMain
            // 
            this.toolScripMain.AutoSize = false;
            this.toolScripMain.BackColor = System.Drawing.Color.Black;
            this.toolScripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolScripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbSerials,
            this.btnRefresh,
            this.lblMainSwitch,
            this.btnRead,
            this.btnStopRead});
            this.toolScripMain.Location = new System.Drawing.Point(4, 59);
            this.toolScripMain.Name = "toolScripMain";
            this.toolScripMain.Size = new System.Drawing.Size(435, 25);
            this.toolScripMain.TabIndex = 0;
            this.toolScripMain.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::OpenBve.Properties.Resources.Connected;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            // 
            // cmbSerials
            // 
            this.cmbSerials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerials.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSerials.Name = "cmbSerials";
            this.cmbSerials.Size = new System.Drawing.Size(121, 25);
            this.cmbSerials.TextChanged += new System.EventHandler(this.cmbSerials_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::OpenBve.Properties.Resources.Refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.ToolTipText = "Refresh controller device list.";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblMainSwitch
            // 
            this.lblMainSwitch.Image = global::OpenBve.Properties.Resources.Switch;
            this.lblMainSwitch.Name = "lblMainSwitch";
            this.lblMainSwitch.Size = new System.Drawing.Size(16, 22);
            // 
            // btnRead
            // 
            this.btnRead.ForeColor = System.Drawing.Color.White;
            this.btnRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(59, 22);
            this.btnRead.Text = "Connect";
            this.btnRead.ToolTipText = "Connect to controller.";
            this.btnRead.Click += new System.EventHandler(this.btnStartRead_Click);
            // 
            // btnStopRead
            // 
            this.btnStopRead.ForeColor = System.Drawing.Color.White;
            this.btnStopRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopRead.Name = "btnStopRead";
            this.btnStopRead.Size = new System.Drawing.Size(59, 22);
            this.btnStopRead.Text = "Dispose";
            this.btnStopRead.ToolTipText = "Disconnect to controller.";
            this.btnStopRead.Click += new System.EventHandler(this.btnStopRead_Click);
            // 
            // txtBoxConstSpeed
            // 
            this.txtBoxConstSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxConstSpeed.ForeColor = System.Drawing.Color.White;
            this.txtBoxConstSpeed.Location = new System.Drawing.Point(327, 317);
            this.txtBoxConstSpeed.Name = "txtBoxConstSpeed";
            this.txtBoxConstSpeed.ReadOnly = true;
            this.txtBoxConstSpeed.Size = new System.Drawing.Size(100, 21);
            this.txtBoxConstSpeed.TabIndex = 40;
            this.txtBoxConstSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAPOFF
            // 
            this.btnAPOFF.BackColor = System.Drawing.Color.DimGray;
            this.btnAPOFF.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAPOFF.ForeColor = System.Drawing.Color.White;
            this.btnAPOFF.Location = new System.Drawing.Point(327, 288);
            this.btnAPOFF.Name = "btnAPOFF";
            this.btnAPOFF.Size = new System.Drawing.Size(100, 23);
            this.btnAPOFF.TabIndex = 39;
            this.btnAPOFF.Text = "AP OFF";
            this.btnAPOFF.UseVisualStyleBackColor = false;
            this.btnAPOFF.Click += new System.EventHandler(this.btnAPOFF_Click);
            // 
            // btnKeyLock
            // 
            this.btnKeyLock.BackColor = System.Drawing.Color.DimGray;
            this.btnKeyLock.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnKeyLock.ForeColor = System.Drawing.Color.White;
            this.btnKeyLock.Location = new System.Drawing.Point(220, 207);
            this.btnKeyLock.Name = "btnKeyLock";
            this.btnKeyLock.Size = new System.Drawing.Size(100, 23);
            this.btnKeyLock.TabIndex = 38;
            this.btnKeyLock.Text = "KEY LOCK";
            this.btnKeyLock.UseVisualStyleBackColor = false;
            this.btnKeyLock.Click += new System.EventHandler(this.btnKeyLock_Click);
            // 
            // btnEmeOff
            // 
            this.btnEmeOff.BackColor = System.Drawing.Color.DimGray;
            this.btnEmeOff.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEmeOff.ForeColor = System.Drawing.Color.White;
            this.btnEmeOff.Location = new System.Drawing.Point(327, 152);
            this.btnEmeOff.Name = "btnEmeOff";
            this.btnEmeOff.Size = new System.Drawing.Size(100, 23);
            this.btnEmeOff.TabIndex = 37;
            this.btnEmeOff.Text = "EMER OFF";
            this.btnEmeOff.UseVisualStyleBackColor = false;
            this.btnEmeOff.Click += new System.EventHandler(this.btnEmeOff_Click);
            // 
            // btnAPON
            // 
            this.btnAPON.BackColor = System.Drawing.Color.DimGray;
            this.btnAPON.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAPON.ForeColor = System.Drawing.Color.White;
            this.btnAPON.Location = new System.Drawing.Point(327, 259);
            this.btnAPON.Name = "btnAPON";
            this.btnAPON.Size = new System.Drawing.Size(100, 23);
            this.btnAPON.TabIndex = 36;
            this.btnAPON.Text = "AP ON";
            this.btnAPON.UseVisualStyleBackColor = false;
            this.btnAPON.Click += new System.EventHandler(this.btnAPON_Click);
            // 
            // btnKeyUnlock
            // 
            this.btnKeyUnlock.BackColor = System.Drawing.Color.DimGray;
            this.btnKeyUnlock.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnKeyUnlock.ForeColor = System.Drawing.Color.White;
            this.btnKeyUnlock.Location = new System.Drawing.Point(221, 181);
            this.btnKeyUnlock.Name = "btnKeyUnlock";
            this.btnKeyUnlock.Size = new System.Drawing.Size(100, 23);
            this.btnKeyUnlock.TabIndex = 35;
            this.btnKeyUnlock.Text = "KEY UNLOCK";
            this.btnKeyUnlock.UseVisualStyleBackColor = false;
            this.btnKeyUnlock.Click += new System.EventHandler(this.btnKeyUnlock_Click);
            // 
            // btnEmeOn
            // 
            this.btnEmeOn.BackColor = System.Drawing.Color.DimGray;
            this.btnEmeOn.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEmeOn.ForeColor = System.Drawing.Color.White;
            this.btnEmeOn.Location = new System.Drawing.Point(327, 123);
            this.btnEmeOn.Name = "btnEmeOn";
            this.btnEmeOn.Size = new System.Drawing.Size(100, 23);
            this.btnEmeOn.TabIndex = 4;
            this.btnEmeOn.Text = "EMER ON";
            this.btnEmeOn.UseVisualStyleBackColor = false;
            this.btnEmeOn.Click += new System.EventHandler(this.btnEmeOn_Click);
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSend.ForeColor = System.Drawing.Color.White;
            this.txtBoxSend.Location = new System.Drawing.Point(221, 424);
            this.txtBoxSend.Multiline = true;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.ReadOnly = true;
            this.txtBoxSend.Size = new System.Drawing.Size(206, 52);
            this.txtBoxSend.TabIndex = 32;
            // 
            // txtBoxRecieve
            // 
            this.txtBoxRecieve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxRecieve.ForeColor = System.Drawing.Color.White;
            this.txtBoxRecieve.Location = new System.Drawing.Point(9, 424);
            this.txtBoxRecieve.Multiline = true;
            this.txtBoxRecieve.Name = "txtBoxRecieve";
            this.txtBoxRecieve.ReadOnly = true;
            this.txtBoxRecieve.Size = new System.Drawing.Size(206, 52);
            this.txtBoxRecieve.TabIndex = 31;
            // 
            // btnHornSt
            // 
            this.btnHornSt.BackColor = System.Drawing.Color.DimGray;
            this.btnHornSt.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHornSt.ForeColor = System.Drawing.Color.White;
            this.btnHornSt.Location = new System.Drawing.Point(327, 181);
            this.btnHornSt.Name = "btnHornSt";
            this.btnHornSt.Size = new System.Drawing.Size(100, 72);
            this.btnHornSt.TabIndex = 15;
            this.btnHornSt.Text = "HORN";
            this.btnHornSt.UseVisualStyleBackColor = false;
            this.btnHornSt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHornSt_MouseDown);
            this.btnHornSt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHornSt_MouseUp);
            // 
            // btnNeu
            // 
            this.btnNeu.BackColor = System.Drawing.Color.DimGray;
            this.btnNeu.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNeu.ForeColor = System.Drawing.Color.White;
            this.btnNeu.Location = new System.Drawing.Point(9, 205);
            this.btnNeu.Name = "btnNeu";
            this.btnNeu.Size = new System.Drawing.Size(100, 50);
            this.btnNeu.TabIndex = 14;
            this.btnNeu.Text = "NEUTRAL";
            this.btnNeu.UseVisualStyleBackColor = false;
            this.btnNeu.Click += new System.EventHandler(this.btnNeu_Click);
            // 
            // txtBoxPowerHandle
            // 
            this.txtBoxPowerHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxPowerHandle.ForeColor = System.Drawing.Color.White;
            this.txtBoxPowerHandle.Location = new System.Drawing.Point(115, 152);
            this.txtBoxPowerHandle.Name = "txtBoxPowerHandle";
            this.txtBoxPowerHandle.ReadOnly = true;
            this.txtBoxPowerHandle.Size = new System.Drawing.Size(100, 21);
            this.txtBoxPowerHandle.TabIndex = 13;
            this.txtBoxPowerHandle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPowerHandle.TextChanged += new System.EventHandler(this.txtBoxPowerHandle_TextChanged);
            // 
            // txtBoxBrakeHandle
            // 
            this.txtBoxBrakeHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxBrakeHandle.ForeColor = System.Drawing.Color.White;
            this.txtBoxBrakeHandle.Location = new System.Drawing.Point(115, 317);
            this.txtBoxBrakeHandle.Name = "txtBoxBrakeHandle";
            this.txtBoxBrakeHandle.ReadOnly = true;
            this.txtBoxBrakeHandle.Size = new System.Drawing.Size(100, 21);
            this.txtBoxBrakeHandle.TabIndex = 12;
            this.txtBoxBrakeHandle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFor
            // 
            this.btnFor.BackColor = System.Drawing.Color.DimGray;
            this.btnFor.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFor.ForeColor = System.Drawing.Color.White;
            this.btnFor.Location = new System.Drawing.Point(9, 152);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(100, 50);
            this.btnFor.TabIndex = 11;
            this.btnFor.Text = "FORWARD";
            this.btnFor.UseVisualStyleBackColor = false;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.DimGray;
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(115, 181);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 63);
            this.btnUp.TabIndex = 10;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.DimGray;
            this.btnDown.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(115, 248);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 63);
            this.btnDown.TabIndex = 9;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(9, 261);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 50);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "REVERSE";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtBoxSpdLimit
            // 
            this.txtBoxSpdLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSpdLimit.ForeColor = System.Drawing.Color.White;
            this.txtBoxSpdLimit.Location = new System.Drawing.Point(115, 123);
            this.txtBoxSpdLimit.Name = "txtBoxSpdLimit";
            this.txtBoxSpdLimit.ReadOnly = true;
            this.txtBoxSpdLimit.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSpdLimit.TabIndex = 7;
            this.txtBoxSpdLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxSpdLimit.TextChanged += new System.EventHandler(this.txtBoxSpdLimit_TextChanged);
            // 
            // txtBoxSpeed
            // 
            this.txtBoxSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSpeed.ForeColor = System.Drawing.Color.White;
            this.txtBoxSpeed.Location = new System.Drawing.Point(9, 123);
            this.txtBoxSpeed.Name = "txtBoxSpeed";
            this.txtBoxSpeed.ReadOnly = true;
            this.txtBoxSpeed.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSpeed.TabIndex = 6;
            this.txtBoxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxSpeed.TextChanged += new System.EventHandler(this.txtBoxSpeed_TextChanged);
            // 
            // txtBoxSignalDis
            // 
            this.txtBoxSignalDis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSignalDis.ForeColor = System.Drawing.Color.White;
            this.txtBoxSignalDis.Location = new System.Drawing.Point(221, 152);
            this.txtBoxSignalDis.Name = "txtBoxSignalDis";
            this.txtBoxSignalDis.ReadOnly = true;
            this.txtBoxSignalDis.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSignalDis.TabIndex = 5;
            this.txtBoxSignalDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxSignalDis.TextChanged += new System.EventHandler(this.txtBoxSignalDis_TextChanged);
            // 
            // txtBoxSignal
            // 
            this.txtBoxSignal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSignal.ForeColor = System.Drawing.Color.White;
            this.txtBoxSignal.Location = new System.Drawing.Point(221, 123);
            this.txtBoxSignal.Name = "txtBoxSignal";
            this.txtBoxSignal.ReadOnly = true;
            this.txtBoxSignal.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSignal.TabIndex = 4;
            this.txtBoxSignal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxSignal.TextChanged += new System.EventHandler(this.txtBoxSignal_TextChanged);
            // 
            // txtBoxReserver
            // 
            this.txtBoxReserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxReserver.ForeColor = System.Drawing.Color.White;
            this.txtBoxReserver.Location = new System.Drawing.Point(9, 317);
            this.txtBoxReserver.Name = "txtBoxReserver";
            this.txtBoxReserver.ReadOnly = true;
            this.txtBoxReserver.Size = new System.Drawing.Size(100, 21);
            this.txtBoxReserver.TabIndex = 3;
            this.txtBoxReserver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 200;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 483);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(439, 25);
            this.toolStrip.TabIndex = 41;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel.Text = "Ready.";
            // 
            // txtBoxCurrentStation
            // 
            this.txtBoxCurrentStation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxCurrentStation.ForeColor = System.Drawing.Color.White;
            this.txtBoxCurrentStation.Location = new System.Drawing.Point(9, 344);
            this.txtBoxCurrentStation.Name = "txtBoxCurrentStation";
            this.txtBoxCurrentStation.ReadOnly = true;
            this.txtBoxCurrentStation.Size = new System.Drawing.Size(206, 21);
            this.txtBoxCurrentStation.TabIndex = 42;
            this.txtBoxCurrentStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxNextStation
            // 
            this.txtBoxNextStation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxNextStation.ForeColor = System.Drawing.Color.White;
            this.txtBoxNextStation.Location = new System.Drawing.Point(221, 344);
            this.txtBoxNextStation.Name = "txtBoxNextStation";
            this.txtBoxNextStation.ReadOnly = true;
            this.txtBoxNextStation.Size = new System.Drawing.Size(206, 21);
            this.txtBoxNextStation.TabIndex = 43;
            this.txtBoxNextStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxArrivalTime
            // 
            this.txtBoxArrivalTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxArrivalTime.ForeColor = System.Drawing.Color.White;
            this.txtBoxArrivalTime.Location = new System.Drawing.Point(327, 370);
            this.txtBoxArrivalTime.Name = "txtBoxArrivalTime";
            this.txtBoxArrivalTime.ReadOnly = true;
            this.txtBoxArrivalTime.Size = new System.Drawing.Size(100, 21);
            this.txtBoxArrivalTime.TabIndex = 44;
            this.txtBoxArrivalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxNextStationDis
            // 
            this.txtBoxNextStationDis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxNextStationDis.ForeColor = System.Drawing.Color.White;
            this.txtBoxNextStationDis.Location = new System.Drawing.Point(9, 371);
            this.txtBoxNextStationDis.Name = "txtBoxNextStationDis";
            this.txtBoxNextStationDis.ReadOnly = true;
            this.txtBoxNextStationDis.Size = new System.Drawing.Size(206, 21);
            this.txtBoxNextStationDis.TabIndex = 45;
            this.txtBoxNextStationDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxDepartureTime
            // 
            this.txtBoxDepartureTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxDepartureTime.ForeColor = System.Drawing.Color.White;
            this.txtBoxDepartureTime.Location = new System.Drawing.Point(221, 370);
            this.txtBoxDepartureTime.Name = "txtBoxDepartureTime";
            this.txtBoxDepartureTime.ReadOnly = true;
            this.txtBoxDepartureTime.Size = new System.Drawing.Size(100, 21);
            this.txtBoxDepartureTime.TabIndex = 46;
            this.txtBoxDepartureTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxCurrentTime
            // 
            this.txtBoxCurrentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtBoxCurrentTime.Location = new System.Drawing.Point(9, 397);
            this.txtBoxCurrentTime.Name = "txtBoxCurrentTime";
            this.txtBoxCurrentTime.ReadOnly = true;
            this.txtBoxCurrentTime.Size = new System.Drawing.Size(418, 21);
            this.txtBoxCurrentTime.TabIndex = 47;
            this.txtBoxCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxRouteName
            // 
            this.txtBoxRouteName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxRouteName.ForeColor = System.Drawing.Color.White;
            this.txtBoxRouteName.Location = new System.Drawing.Point(9, 96);
            this.txtBoxRouteName.Name = "txtBoxRouteName";
            this.txtBoxRouteName.ReadOnly = true;
            this.txtBoxRouteName.Size = new System.Drawing.Size(170, 21);
            this.txtBoxRouteName.TabIndex = 48;
            this.txtBoxRouteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txBoxTrainName
            // 
            this.txBoxTrainName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txBoxTrainName.ForeColor = System.Drawing.Color.White;
            this.txBoxTrainName.Location = new System.Drawing.Point(184, 96);
            this.txBoxTrainName.Name = "txBoxTrainName";
            this.txBoxTrainName.ReadOnly = true;
            this.txBoxTrainName.Size = new System.Drawing.Size(170, 21);
            this.txBoxTrainName.TabIndex = 49;
            this.txBoxTrainName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRestartGame
            // 
            this.btnRestartGame.BackColor = System.Drawing.Color.Silver;
            this.btnRestartGame.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRestartGame.Location = new System.Drawing.Point(360, 94);
            this.btnRestartGame.Name = "btnRestartGame";
            this.btnRestartGame.Size = new System.Drawing.Size(67, 23);
            this.btnRestartGame.TabIndex = 50;
            this.btnRestartGame.Text = "Change";
            this.btnRestartGame.UseVisualStyleBackColor = false;
            this.btnRestartGame.Click += new System.EventHandler(this.btnRestartGame_Click);
            // 
            // btnLeftDoorOpen
            // 
            this.btnLeftDoorOpen.BackColor = System.Drawing.Color.DimGray;
            this.btnLeftDoorOpen.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDoorOpen.ForeColor = System.Drawing.Color.White;
            this.btnLeftDoorOpen.Location = new System.Drawing.Point(221, 233);
            this.btnLeftDoorOpen.Name = "btnLeftDoorOpen";
            this.btnLeftDoorOpen.Size = new System.Drawing.Size(100, 23);
            this.btnLeftDoorOpen.TabIndex = 51;
            this.btnLeftDoorOpen.Text = "LDOOR UNLOCK";
            this.btnLeftDoorOpen.UseVisualStyleBackColor = false;
            this.btnLeftDoorOpen.Click += new System.EventHandler(this.btnLeftDoorOpen_Click);
            // 
            // btnLeftDoorClose
            // 
            this.btnLeftDoorClose.BackColor = System.Drawing.Color.DimGray;
            this.btnLeftDoorClose.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDoorClose.ForeColor = System.Drawing.Color.White;
            this.btnLeftDoorClose.Location = new System.Drawing.Point(221, 260);
            this.btnLeftDoorClose.Name = "btnLeftDoorClose";
            this.btnLeftDoorClose.Size = new System.Drawing.Size(100, 23);
            this.btnLeftDoorClose.TabIndex = 52;
            this.btnLeftDoorClose.Text = "LDOOR LOCK";
            this.btnLeftDoorClose.UseVisualStyleBackColor = false;
            this.btnLeftDoorClose.Click += new System.EventHandler(this.btnLeftDoorClose_Click);
            // 
            // btnRightDoorOpen
            // 
            this.btnRightDoorOpen.BackColor = System.Drawing.Color.DimGray;
            this.btnRightDoorOpen.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDoorOpen.ForeColor = System.Drawing.Color.White;
            this.btnRightDoorOpen.Location = new System.Drawing.Point(221, 287);
            this.btnRightDoorOpen.Name = "btnRightDoorOpen";
            this.btnRightDoorOpen.Size = new System.Drawing.Size(100, 23);
            this.btnRightDoorOpen.TabIndex = 53;
            this.btnRightDoorOpen.Text = "RDOOR UNLOCK";
            this.btnRightDoorOpen.UseVisualStyleBackColor = false;
            this.btnRightDoorOpen.Click += new System.EventHandler(this.btnRightDoorOpen_Click);
            // 
            // btnRightDoorClose
            // 
            this.btnRightDoorClose.BackColor = System.Drawing.Color.DimGray;
            this.btnRightDoorClose.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDoorClose.ForeColor = System.Drawing.Color.White;
            this.btnRightDoorClose.Location = new System.Drawing.Point(220, 315);
            this.btnRightDoorClose.Name = "btnRightDoorClose";
            this.btnRightDoorClose.Size = new System.Drawing.Size(100, 23);
            this.btnRightDoorClose.TabIndex = 54;
            this.btnRightDoorClose.Text = "RDOOR LOCK";
            this.btnRightDoorClose.UseVisualStyleBackColor = false;
            this.btnRightDoorClose.Click += new System.EventHandler(this.btnRightDoorClose_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Image = global::OpenBve.Properties.Resources.CPBackground;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(439, 56);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // formMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(439, 508);
            this.Controls.Add(this.btnRightDoorClose);
            this.Controls.Add(this.btnRightDoorOpen);
            this.Controls.Add(this.btnLeftDoorClose);
            this.Controls.Add(this.btnLeftDoorOpen);
            this.Controls.Add(this.btnRestartGame);
            this.Controls.Add(this.txBoxTrainName);
            this.Controls.Add(this.txtBoxRouteName);
            this.Controls.Add(this.txtBoxCurrentTime);
            this.Controls.Add(this.txtBoxDepartureTime);
            this.Controls.Add(this.txtBoxNextStationDis);
            this.Controls.Add(this.txtBoxArrivalTime);
            this.Controls.Add(this.txtBoxNextStation);
            this.Controls.Add(this.txtBoxCurrentStation);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtBoxConstSpeed);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnAPOFF);
            this.Controls.Add(this.btnKeyLock);
            this.Controls.Add(this.toolScripMain);
            this.Controls.Add(this.btnEmeOff);
            this.Controls.Add(this.txtBoxSpeed);
            this.Controls.Add(this.btnAPON);
            this.Controls.Add(this.txtBoxReserver);
            this.Controls.Add(this.btnKeyUnlock);
            this.Controls.Add(this.txtBoxSignal);
            this.Controls.Add(this.btnEmeOn);
            this.Controls.Add(this.txtBoxSignalDis);
            this.Controls.Add(this.txtBoxSend);
            this.Controls.Add(this.txtBoxSpdLimit);
            this.Controls.Add(this.txtBoxRecieve);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHornSt);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnNeu);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.txtBoxPowerHandle);
            this.Controls.Add(this.btnFor);
            this.Controls.Add(this.txtBoxBrakeHandle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Control Panel V3.1 [SWJTUVersion]";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCM_FormClosed);
            this.Load += new System.EventHandler(this.formCM_Load);
            this.Move += new System.EventHandler(this.formMonitor_Move);
            this.toolScripMain.ResumeLayout(false);
            this.toolScripMain.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolScripMain;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox cmbSerials;
		private System.Windows.Forms.ToolStripButton btnRead;
		private System.Windows.Forms.ToolStripButton btnStopRead;
		private System.Windows.Forms.ToolStripLabel lblMainSwitch;
		private System.Windows.Forms.TextBox txtBoxReserver;
		private System.Windows.Forms.TextBox txtBoxSpdLimit;
		private System.Windows.Forms.TextBox txtBoxSpeed;
		private System.Windows.Forms.TextBox txtBoxSignalDis;
		private System.Windows.Forms.TextBox txtBoxSignal;
		private System.Windows.Forms.Timer tmrUpdate;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnFor;
		private System.Windows.Forms.TextBox txtBoxPowerHandle;
		private System.Windows.Forms.TextBox txtBoxBrakeHandle;
		private System.Windows.Forms.Button btnHornSt;
		private System.Windows.Forms.Button btnNeu;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.TextBox txtBoxSend;
		private System.Windows.Forms.TextBox txtBoxRecieve;
		private System.Windows.Forms.Button btnEmeOn;
		private System.Windows.Forms.Button btnAPOFF;
		private System.Windows.Forms.Button btnKeyLock;
		private System.Windows.Forms.Button btnEmeOff;
		private System.Windows.Forms.Button btnAPON;
		private System.Windows.Forms.Button btnKeyUnlock;
		private System.Windows.Forms.TextBox txtBoxConstSpeed;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabel;
		private System.Windows.Forms.TextBox txtBoxCurrentStation;
		private System.Windows.Forms.TextBox txtBoxNextStation;
		private System.Windows.Forms.TextBox txtBoxArrivalTime;
		private System.Windows.Forms.TextBox txtBoxNextStationDis;
		private System.Windows.Forms.TextBox txtBoxDepartureTime;
		private System.Windows.Forms.TextBox txtBoxCurrentTime;
		private System.Windows.Forms.TextBox txtBoxRouteName;
		private System.Windows.Forms.TextBox txBoxTrainName;
		private System.Windows.Forms.Button btnRestartGame;
		private System.Windows.Forms.Button btnLeftDoorOpen;
		private System.Windows.Forms.Button btnLeftDoorClose;
		private System.Windows.Forms.Button btnRightDoorOpen;
		private System.Windows.Forms.Button btnRightDoorClose;
	}
}

