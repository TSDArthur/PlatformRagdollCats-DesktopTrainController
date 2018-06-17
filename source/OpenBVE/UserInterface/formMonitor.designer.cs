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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblMainSwitch = new System.Windows.Forms.ToolStripLabel();
            this.btnRead = new System.Windows.Forms.ToolStripButton();
            this.btnStopRead = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupTsk = new System.Windows.Forms.GroupBox();
            this.txtBoxConstSpeed = new System.Windows.Forms.TextBox();
            this.btnAPOFF = new System.Windows.Forms.Button();
            this.btnKeyLock = new System.Windows.Forms.Button();
            this.btnEmeOff = new System.Windows.Forms.Button();
            this.btnAPON = new System.Windows.Forms.Button();
            this.btnKeyUnlock = new System.Windows.Forms.Button();
            this.btnEmeOn = new System.Windows.Forms.Button();
            this.listBoxTsk = new System.Windows.Forms.ListBox();
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
            this.txtBoxPwr = new System.Windows.Forms.TextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolScripMain.SuspendLayout();
            this.groupTsk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolScripMain
            // 
            this.toolScripMain.AutoSize = false;
            this.toolScripMain.BackColor = System.Drawing.Color.White;
            this.toolScripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolScripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbSerials,
            this.toolStripSeparator2,
            this.btnRefresh,
            this.toolStripSeparator4,
            this.lblMainSwitch,
            this.btnRead,
            this.btnStopRead,
            this.toolStripSeparator1});
            this.toolScripMain.Location = new System.Drawing.Point(6, 59);
            this.toolScripMain.Name = "toolScripMain";
            this.toolScripMain.Size = new System.Drawing.Size(630, 25);
            this.toolScripMain.TabIndex = 0;
            this.toolScripMain.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::OpenBve.Properties.Resources.Connected;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel1.Text = "Device :";
            // 
            // cmbSerials
            // 
            this.cmbSerials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerials.Name = "cmbSerials";
            this.cmbSerials.Size = new System.Drawing.Size(121, 25);
            this.cmbSerials.TextChanged += new System.EventHandler(this.cmbSerials_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::OpenBve.Properties.Resources.Refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblMainSwitch
            // 
            this.lblMainSwitch.Image = global::OpenBve.Properties.Resources.Switch;
            this.lblMainSwitch.Name = "lblMainSwitch";
            this.lblMainSwitch.Size = new System.Drawing.Size(70, 22);
            this.lblMainSwitch.Text = "Enable :";
            // 
            // btnRead
            // 
            this.btnRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(39, 22);
            this.btnRead.Text = "Start";
            this.btnRead.Click += new System.EventHandler(this.btnStartRead_Click);
            // 
            // btnStopRead
            // 
            this.btnStopRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopRead.Name = "btnStopRead";
            this.btnStopRead.Size = new System.Drawing.Size(39, 22);
            this.btnStopRead.Text = "Stop";
            this.btnStopRead.Click += new System.EventHandler(this.btnStopRead_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // groupTsk
            // 
            this.groupTsk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupTsk.Controls.Add(this.txtBoxConstSpeed);
            this.groupTsk.Controls.Add(this.btnAPOFF);
            this.groupTsk.Controls.Add(this.btnKeyLock);
            this.groupTsk.Controls.Add(this.btnEmeOff);
            this.groupTsk.Controls.Add(this.btnAPON);
            this.groupTsk.Controls.Add(this.btnKeyUnlock);
            this.groupTsk.Controls.Add(this.btnEmeOn);
            this.groupTsk.Controls.Add(this.listBoxTsk);
            this.groupTsk.Controls.Add(this.txtBoxSend);
            this.groupTsk.Controls.Add(this.txtBoxRecieve);
            this.groupTsk.Controls.Add(this.btnHornSt);
            this.groupTsk.Controls.Add(this.btnNeu);
            this.groupTsk.Controls.Add(this.txtBoxPowerHandle);
            this.groupTsk.Controls.Add(this.txtBoxBrakeHandle);
            this.groupTsk.Controls.Add(this.btnFor);
            this.groupTsk.Controls.Add(this.btnUp);
            this.groupTsk.Controls.Add(this.btnDown);
            this.groupTsk.Controls.Add(this.btnBack);
            this.groupTsk.Controls.Add(this.txtBoxSpdLimit);
            this.groupTsk.Controls.Add(this.txtBoxSpeed);
            this.groupTsk.Controls.Add(this.txtBoxSignalDis);
            this.groupTsk.Controls.Add(this.txtBoxSignal);
            this.groupTsk.Controls.Add(this.txtBoxReserver);
            this.groupTsk.Controls.Add(this.txtBoxPwr);
            this.groupTsk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupTsk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupTsk.Location = new System.Drawing.Point(0, 87);
            this.groupTsk.Name = "groupTsk";
            this.groupTsk.Size = new System.Drawing.Size(643, 535);
            this.groupTsk.TabIndex = 2;
            this.groupTsk.TabStop = false;
            this.groupTsk.Text = "Task Monitor";
            // 
            // txtBoxConstSpeed
            // 
            this.txtBoxConstSpeed.Location = new System.Drawing.Point(324, 422);
            this.txtBoxConstSpeed.Name = "txtBoxConstSpeed";
            this.txtBoxConstSpeed.ReadOnly = true;
            this.txtBoxConstSpeed.Size = new System.Drawing.Size(100, 23);
            this.txtBoxConstSpeed.TabIndex = 40;
            // 
            // btnAPOFF
            // 
            this.btnAPOFF.Location = new System.Drawing.Point(536, 509);
            this.btnAPOFF.Name = "btnAPOFF";
            this.btnAPOFF.Size = new System.Drawing.Size(100, 23);
            this.btnAPOFF.TabIndex = 39;
            this.btnAPOFF.Text = "AP OFF";
            this.btnAPOFF.UseVisualStyleBackColor = true;
            this.btnAPOFF.Click += new System.EventHandler(this.btnAPOFF_Click);
            // 
            // btnKeyLock
            // 
            this.btnKeyLock.Location = new System.Drawing.Point(324, 509);
            this.btnKeyLock.Name = "btnKeyLock";
            this.btnKeyLock.Size = new System.Drawing.Size(100, 23);
            this.btnKeyLock.TabIndex = 38;
            this.btnKeyLock.Text = "KEY LOCK";
            this.btnKeyLock.UseVisualStyleBackColor = true;
            this.btnKeyLock.Click += new System.EventHandler(this.btnKeyLock_Click);
            // 
            // btnEmeOff
            // 
            this.btnEmeOff.Location = new System.Drawing.Point(112, 509);
            this.btnEmeOff.Name = "btnEmeOff";
            this.btnEmeOff.Size = new System.Drawing.Size(100, 23);
            this.btnEmeOff.TabIndex = 37;
            this.btnEmeOff.Text = "Eme OFF";
            this.btnEmeOff.UseVisualStyleBackColor = true;
            this.btnEmeOff.Click += new System.EventHandler(this.btnEmeOff_Click);
            // 
            // btnAPON
            // 
            this.btnAPON.Location = new System.Drawing.Point(430, 509);
            this.btnAPON.Name = "btnAPON";
            this.btnAPON.Size = new System.Drawing.Size(100, 23);
            this.btnAPON.TabIndex = 36;
            this.btnAPON.Text = "AP ON";
            this.btnAPON.UseVisualStyleBackColor = true;
            this.btnAPON.Click += new System.EventHandler(this.btnAPON_Click);
            // 
            // btnKeyUnlock
            // 
            this.btnKeyUnlock.Location = new System.Drawing.Point(218, 509);
            this.btnKeyUnlock.Name = "btnKeyUnlock";
            this.btnKeyUnlock.Size = new System.Drawing.Size(100, 23);
            this.btnKeyUnlock.TabIndex = 35;
            this.btnKeyUnlock.Text = "KEY UNLOCK";
            this.btnKeyUnlock.UseVisualStyleBackColor = true;
            this.btnKeyUnlock.Click += new System.EventHandler(this.btnKeyUnlock_Click);
            // 
            // btnEmeOn
            // 
            this.btnEmeOn.Location = new System.Drawing.Point(6, 509);
            this.btnEmeOn.Name = "btnEmeOn";
            this.btnEmeOn.Size = new System.Drawing.Size(100, 23);
            this.btnEmeOn.TabIndex = 4;
            this.btnEmeOn.Text = "Eme ON";
            this.btnEmeOn.UseVisualStyleBackColor = true;
            this.btnEmeOn.Click += new System.EventHandler(this.btnEmeOn_Click);
            // 
            // listBoxTsk
            // 
            this.listBoxTsk.FormattingEnabled = true;
            this.listBoxTsk.ItemHeight = 17;
            this.listBoxTsk.Location = new System.Drawing.Point(6, 23);
            this.listBoxTsk.Name = "listBoxTsk";
            this.listBoxTsk.Size = new System.Drawing.Size(630, 395);
            this.listBoxTsk.TabIndex = 34;
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(162, 422);
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.ReadOnly = true;
            this.txtBoxSend.Size = new System.Drawing.Size(156, 23);
            this.txtBoxSend.TabIndex = 32;
            // 
            // txtBoxRecieve
            // 
            this.txtBoxRecieve.Location = new System.Drawing.Point(6, 422);
            this.txtBoxRecieve.Name = "txtBoxRecieve";
            this.txtBoxRecieve.ReadOnly = true;
            this.txtBoxRecieve.Size = new System.Drawing.Size(150, 23);
            this.txtBoxRecieve.TabIndex = 31;
            // 
            // btnHornSt
            // 
            this.btnHornSt.Location = new System.Drawing.Point(536, 480);
            this.btnHornSt.Name = "btnHornSt";
            this.btnHornSt.Size = new System.Drawing.Size(100, 23);
            this.btnHornSt.TabIndex = 15;
            this.btnHornSt.Text = "HORN";
            this.btnHornSt.UseVisualStyleBackColor = true;
            this.btnHornSt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHornSt_MouseDown);
            this.btnHornSt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnHornSt_MouseUp);
            // 
            // btnNeu
            // 
            this.btnNeu.Location = new System.Drawing.Point(112, 480);
            this.btnNeu.Name = "btnNeu";
            this.btnNeu.Size = new System.Drawing.Size(100, 23);
            this.btnNeu.TabIndex = 14;
            this.btnNeu.Text = "NEUTRAL";
            this.btnNeu.UseVisualStyleBackColor = true;
            this.btnNeu.Click += new System.EventHandler(this.btnNeu_Click);
            // 
            // txtBoxPowerHandle
            // 
            this.txtBoxPowerHandle.Location = new System.Drawing.Point(430, 422);
            this.txtBoxPowerHandle.Name = "txtBoxPowerHandle";
            this.txtBoxPowerHandle.ReadOnly = true;
            this.txtBoxPowerHandle.Size = new System.Drawing.Size(100, 23);
            this.txtBoxPowerHandle.TabIndex = 13;
            // 
            // txtBoxBrakeHandle
            // 
            this.txtBoxBrakeHandle.Location = new System.Drawing.Point(536, 422);
            this.txtBoxBrakeHandle.Name = "txtBoxBrakeHandle";
            this.txtBoxBrakeHandle.ReadOnly = true;
            this.txtBoxBrakeHandle.Size = new System.Drawing.Size(100, 23);
            this.txtBoxBrakeHandle.TabIndex = 12;
            // 
            // btnFor
            // 
            this.btnFor.Location = new System.Drawing.Point(6, 480);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(100, 23);
            this.btnFor.TabIndex = 11;
            this.btnFor.Text = "FORWARD";
            this.btnFor.UseVisualStyleBackColor = true;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(324, 480);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 23);
            this.btnUp.TabIndex = 10;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(430, 480);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 23);
            this.btnDown.TabIndex = 9;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(218, 480);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "BACKWARD";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtBoxSpdLimit
            // 
            this.txtBoxSpdLimit.Location = new System.Drawing.Point(536, 451);
            this.txtBoxSpdLimit.Name = "txtBoxSpdLimit";
            this.txtBoxSpdLimit.ReadOnly = true;
            this.txtBoxSpdLimit.Size = new System.Drawing.Size(100, 23);
            this.txtBoxSpdLimit.TabIndex = 7;
            // 
            // txtBoxSpeed
            // 
            this.txtBoxSpeed.Location = new System.Drawing.Point(430, 451);
            this.txtBoxSpeed.Name = "txtBoxSpeed";
            this.txtBoxSpeed.ReadOnly = true;
            this.txtBoxSpeed.Size = new System.Drawing.Size(100, 23);
            this.txtBoxSpeed.TabIndex = 6;
            // 
            // txtBoxSignalDis
            // 
            this.txtBoxSignalDis.Location = new System.Drawing.Point(324, 451);
            this.txtBoxSignalDis.Name = "txtBoxSignalDis";
            this.txtBoxSignalDis.ReadOnly = true;
            this.txtBoxSignalDis.Size = new System.Drawing.Size(100, 23);
            this.txtBoxSignalDis.TabIndex = 5;
            // 
            // txtBoxSignal
            // 
            this.txtBoxSignal.Location = new System.Drawing.Point(218, 451);
            this.txtBoxSignal.Name = "txtBoxSignal";
            this.txtBoxSignal.ReadOnly = true;
            this.txtBoxSignal.Size = new System.Drawing.Size(100, 23);
            this.txtBoxSignal.TabIndex = 4;
            // 
            // txtBoxReserver
            // 
            this.txtBoxReserver.Location = new System.Drawing.Point(112, 451);
            this.txtBoxReserver.Name = "txtBoxReserver";
            this.txtBoxReserver.ReadOnly = true;
            this.txtBoxReserver.Size = new System.Drawing.Size(100, 23);
            this.txtBoxReserver.TabIndex = 3;
            // 
            // txtBoxPwr
            // 
            this.txtBoxPwr.Location = new System.Drawing.Point(6, 451);
            this.txtBoxPwr.Name = "txtBoxPwr";
            this.txtBoxPwr.ReadOnly = true;
            this.txtBoxPwr.Size = new System.Drawing.Size(100, 23);
            this.txtBoxPwr.TabIndex = 2;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenBve.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(747, 56);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // formMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(643, 622);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupTsk);
            this.Controls.Add(this.toolScripMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller Monitor V2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCM_FormClosed);
            this.Load += new System.EventHandler(this.formCM_Load);
            this.toolScripMain.ResumeLayout(false);
            this.toolScripMain.PerformLayout();
            this.groupTsk.ResumeLayout(false);
            this.groupTsk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolScripMain;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox cmbSerials;
		private System.Windows.Forms.ToolStripButton btnRead;
		private System.Windows.Forms.ToolStripButton btnStopRead;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel lblMainSwitch;
		private System.Windows.Forms.GroupBox groupTsk;
		private System.Windows.Forms.TextBox txtBoxReserver;
		private System.Windows.Forms.TextBox txtBoxPwr;
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
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.TextBox txtBoxSend;
		private System.Windows.Forms.TextBox txtBoxRecieve;
		private System.Windows.Forms.ListBox listBoxTsk;
		private System.Windows.Forms.Button btnEmeOn;
		private System.Windows.Forms.Button btnAPOFF;
		private System.Windows.Forms.Button btnKeyLock;
		private System.Windows.Forms.Button btnEmeOff;
		private System.Windows.Forms.Button btnAPON;
		private System.Windows.Forms.Button btnKeyUnlock;
		private System.Windows.Forms.TextBox txtBoxConstSpeed;
	}
}

