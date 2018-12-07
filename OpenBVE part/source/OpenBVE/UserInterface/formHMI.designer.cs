namespace OpenBve
{
	partial class formHMI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHMI));
            this.toolScripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSerials = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.lblMainSwitch = new System.Windows.Forms.ToolStripLabel();
            this.btnRead = new System.Windows.Forms.ToolStripButton();
            this.btnStopRead = new System.Windows.Forms.ToolStripButton();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.tmrSend = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHMI1 = new System.Windows.Forms.PictureBox();
            this.tmrSerial = new System.Windows.Forms.Timer(this.components);
            this.txtBoxRecieved = new System.Windows.Forms.TextBox();
            this.toolScripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHMI1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolScripMain
            // 
            this.toolScripMain.AutoSize = false;
            this.toolScripMain.BackColor = System.Drawing.Color.Black;
            this.toolScripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbSerials,
            this.btnRefresh,
            this.lblMainSwitch,
            this.btnRead,
            this.btnStopRead});
            this.toolScripMain.Location = new System.Drawing.Point(0, 0);
            this.toolScripMain.Name = "toolScripMain";
            this.toolScripMain.Size = new System.Drawing.Size(439, 25);
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
            this.cmbSerials.BackColor = System.Drawing.Color.Gray;
            this.cmbSerials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerials.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSerials.ForeColor = System.Drawing.Color.White;
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
            this.btnRead.ToolTipText = "Connect to HMI.";
            this.btnRead.Click += new System.EventHandler(this.btnStartRead_Click);
            // 
            // btnStopRead
            // 
            this.btnStopRead.ForeColor = System.Drawing.Color.White;
            this.btnStopRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopRead.Name = "btnStopRead";
            this.btnStopRead.Size = new System.Drawing.Size(59, 22);
            this.btnStopRead.Text = "Dispose";
            this.btnStopRead.ToolTipText = "Disconnect to HMI.";
            this.btnStopRead.Click += new System.EventHandler(this.btnStopRead_Click);
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxSend.ForeColor = System.Drawing.Color.White;
            this.txtBoxSend.Location = new System.Drawing.Point(222, 165);
            this.txtBoxSend.Multiline = true;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.ReadOnly = true;
            this.txtBoxSend.Size = new System.Drawing.Size(212, 22);
            this.txtBoxSend.TabIndex = 32;
            // 
            // tmrSend
            // 
            this.tmrSend.Interval = 40;
            this.tmrSend.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenBve.Properties.Resources.HMI2;
            this.pictureBox1.Location = new System.Drawing.Point(222, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxHMI1
            // 
            this.pictureBoxHMI1.Image = global::OpenBve.Properties.Resources.HMI1;
            this.pictureBoxHMI1.Location = new System.Drawing.Point(6, 29);
            this.pictureBoxHMI1.Name = "pictureBoxHMI1";
            this.pictureBoxHMI1.Size = new System.Drawing.Size(209, 130);
            this.pictureBoxHMI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHMI1.TabIndex = 42;
            this.pictureBoxHMI1.TabStop = false;
            // 
            // tmrSerial
            // 
            this.tmrSerial.Enabled = true;
            this.tmrSerial.Interval = 200;
            this.tmrSerial.Tick += new System.EventHandler(this.tmrSerial_Tick);
            // 
            // txtBoxRecieved
            // 
            this.txtBoxRecieved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxRecieved.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxRecieved.ForeColor = System.Drawing.Color.White;
            this.txtBoxRecieved.Location = new System.Drawing.Point(6, 165);
            this.txtBoxRecieved.Multiline = true;
            this.txtBoxRecieved.Name = "txtBoxRecieved";
            this.txtBoxRecieved.ReadOnly = true;
            this.txtBoxRecieved.Size = new System.Drawing.Size(212, 22);
            this.txtBoxRecieved.TabIndex = 44;
            // 
            // formHMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(439, 195);
            this.Controls.Add(this.txtBoxRecieved);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxHMI1);
            this.Controls.Add(this.toolScripMain);
            this.Controls.Add(this.txtBoxSend);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 540);
            this.MaximizeBox = false;
            this.Name = "formHMI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HMI Panel";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCM_FormClosed);
            this.Load += new System.EventHandler(this.formCM_Load);
            this.toolScripMain.ResumeLayout(false);
            this.toolScripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHMI1)).EndInit();
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
		private System.Windows.Forms.Timer tmrSend;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.TextBox txtBoxSend;
		private System.Windows.Forms.PictureBox pictureBoxHMI1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer tmrSerial;
		private System.Windows.Forms.TextBox txtBoxRecieved;
	}
}

