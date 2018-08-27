namespace SimpleMediaPlayer
{
    partial class mainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.AxWmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.tkbMove = new System.Windows.Forms.TrackBar();
            this.stsInfo = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentPlayState = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lstSongList = new System.Windows.Forms.ListBox();
            this.ntiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.odlgFile = new System.Windows.Forms.OpenFileDialog();
            this.tkbVol = new System.Windows.Forms.TrackBar();
            this.lbVolumeVal = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.cmsSongListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSongInfoDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveSongFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayMode = new System.Windows.Forms.Button();
            this.pbAlbumImage = new System.Windows.Forms.PictureBox();
            this.txtSreachSongName = new System.Windows.Forms.TextBox();
            this.lbNotFoundSong = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AxWmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbMove)).BeginInit();
            this.stsInfo.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.ntiContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbVol)).BeginInit();
            this.cmsSongListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumImage)).BeginInit();
            this.SuspendLayout();
            // 
            // AxWmp
            // 
            this.AxWmp.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AxWmp.Enabled = true;
            this.AxWmp.Location = new System.Drawing.Point(12, 35);
            this.AxWmp.Margin = new System.Windows.Forms.Padding(4);
            this.AxWmp.Name = "AxWmp";
            this.AxWmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWmp.OcxState")));
            this.AxWmp.Size = new System.Drawing.Size(497, 237);
            this.AxWmp.TabIndex = 0;
            this.AxWmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.AxWmp_PlayStateChange);
            // 
            // tkbMove
            // 
            this.tkbMove.AutoSize = false;
            this.tkbMove.Location = new System.Drawing.Point(16, 392);
            this.tkbMove.Margin = new System.Windows.Forms.Padding(4);
            this.tkbMove.Maximum = 100;
            this.tkbMove.Name = "tkbMove";
            this.tkbMove.Size = new System.Drawing.Size(662, 40);
            this.tkbMove.TabIndex = 1;
            this.tkbMove.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbMove.Scroll += new System.EventHandler(this.tkbMove_Scroll);
            // 
            // stsInfo
            // 
            this.stsInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentPlayState});
            this.stsInfo.Location = new System.Drawing.Point(0, 537);
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stsInfo.Size = new System.Drawing.Size(992, 25);
            this.stsInfo.TabIndex = 3;
            this.stsInfo.Text = "statusStrip1";
            // 
            // tsslCurrentPlayState
            // 
            this.tsslCurrentPlayState.Name = "tsslCurrentPlayState";
            this.tsslCurrentPlayState.Size = new System.Drawing.Size(167, 20);
            this.tsslCurrentPlayState.Text = "toolStripStatusLabel1";
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(992, 28);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainMenu_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFile});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(136, 26);
            this.tsmiOpenFile.Text = "打开(&O)";
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTime.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTime.Location = new System.Drawing.Point(14, 352);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(485, 25);
            this.txtTime.TabIndex = 5;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstSongList
            // 
            this.lstSongList.BackColor = System.Drawing.SystemColors.MenuText;
            this.lstSongList.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstSongList.ForeColor = System.Drawing.Color.Silver;
            this.lstSongList.FormattingEnabled = true;
            this.lstSongList.ItemHeight = 15;
            this.lstSongList.Location = new System.Drawing.Point(687, 192);
            this.lstSongList.Margin = new System.Windows.Forms.Padding(4);
            this.lstSongList.Name = "lstSongList";
            this.lstSongList.Size = new System.Drawing.Size(288, 199);
            this.lstSongList.TabIndex = 6;
            this.lstSongList.SelectedIndexChanged += new System.EventHandler(this.lstSongList_SelectedIndexChanged);
            this.lstSongList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSong_MouseDoubleClick);
            this.lstSongList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstSongList_MouseDown);
            this.lstSongList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSongList_MouseMove);
            // 
            // ntiContextMenu
            // 
            this.ntiContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ntiContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenForm,
            this.tsmiQuit});
            this.ntiContextMenu.Name = "contextMenu";
            this.ntiContextMenu.Size = new System.Drawing.Size(176, 52);
            // 
            // tsmiOpenForm
            // 
            this.tsmiOpenForm.Name = "tsmiOpenForm";
            this.tsmiOpenForm.Size = new System.Drawing.Size(175, 24);
            this.tsmiOpenForm.Text = "显示主界面(&O)";
            this.tsmiOpenForm.Click += new System.EventHandler(this.tsmiOpenForm_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(175, 24);
            this.tsmiQuit.Text = "退出(&Q)";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // odlgFile
            // 
            this.odlgFile.FileName = "openFileDialog1";
            // 
            // tkbVol
            // 
            this.tkbVol.AutoSize = false;
            this.tkbVol.Location = new System.Drawing.Point(570, 454);
            this.tkbVol.Margin = new System.Windows.Forms.Padding(4);
            this.tkbVol.Maximum = 100;
            this.tkbVol.Name = "tkbVol";
            this.tkbVol.Size = new System.Drawing.Size(109, 30);
            this.tkbVol.TabIndex = 8;
            this.tkbVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbVol.ValueChanged += new System.EventHandler(this.tkbVol_ValueChanged);
            this.tkbVol.MouseLeave += new System.EventHandler(this.tkbVol_MouseLeave);
            this.tkbVol.MouseHover += new System.EventHandler(this.tkbVol_MouseHover);
            // 
            // lbVolumeVal
            // 
            this.lbVolumeVal.Location = new System.Drawing.Point(476, 456);
            this.lbVolumeVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVolumeVal.Name = "lbVolumeVal";
            this.lbVolumeVal.Size = new System.Drawing.Size(55, 24);
            this.lbVolumeVal.TabIndex = 9;
            this.lbVolumeVal.Text = "音量:";
            this.lbVolumeVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbVolumeVal.Click += new System.EventHandler(this.lbVolumeVal_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ntiContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.下一曲1;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(314, 440);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(43, 40);
            this.btnNext.TabIndex = 2;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.上一曲3;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(121, 444);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(43, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.停止1;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(220, 440);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(43, 40);
            this.btnStop.TabIndex = 2;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlay.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.播放;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(31, 440);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(43, 40);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.btnPlay_MouseLeave);
            // 
            // cmsSongListMenu
            // 
            this.cmsSongListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSongListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSongInfoDetail,
            this.tsmiRemoveSongFromList});
            this.cmsSongListMenu.Name = "cmsSongListMenu";
            this.cmsSongListMenu.Size = new System.Drawing.Size(190, 52);
            // 
            // tsmiSongInfoDetail
            // 
            this.tsmiSongInfoDetail.Name = "tsmiSongInfoDetail";
            this.tsmiSongInfoDetail.Size = new System.Drawing.Size(189, 24);
            this.tsmiSongInfoDetail.Text = "详情(&I)";
            this.tsmiSongInfoDetail.Click += new System.EventHandler(this.tsmiSongInfoDetail_Click);
            // 
            // tsmiRemoveSongFromList
            // 
            this.tsmiRemoveSongFromList.Name = "tsmiRemoveSongFromList";
            this.tsmiRemoveSongFromList.Size = new System.Drawing.Size(189, 24);
            this.tsmiRemoveSongFromList.Text = "从列表中删除(&D)";
            this.tsmiRemoveSongFromList.Click += new System.EventHandler(this.tsmiRemoveSongFromList_Click);
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.循环播放;
            this.btnPlayMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayMode.FlatAppearance.BorderSize = 0;
            this.btnPlayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMode.Location = new System.Drawing.Point(411, 440);
            this.btnPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(43, 40);
            this.btnPlayMode.TabIndex = 10;
            this.btnPlayMode.UseVisualStyleBackColor = true;
            this.btnPlayMode.Click += new System.EventHandler(this.btnPlayMode_Click);
            // 
            // pbAlbumImage
            // 
            this.pbAlbumImage.Image = global::SimpleMediaPlayer.Properties.Resources.music17;
            this.pbAlbumImage.Location = new System.Drawing.Point(769, 53);
            this.pbAlbumImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbAlbumImage.Name = "pbAlbumImage";
            this.pbAlbumImage.Size = new System.Drawing.Size(133, 121);
            this.pbAlbumImage.TabIndex = 11;
            this.pbAlbumImage.TabStop = false;
            this.pbAlbumImage.Click += new System.EventHandler(this.pbAlbumImage_Click);
            // 
            // txtSreachSongName
            // 
            this.txtSreachSongName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSreachSongName.Location = new System.Drawing.Point(687, 440);
            this.txtSreachSongName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSreachSongName.Name = "txtSreachSongName";
            this.txtSreachSongName.Size = new System.Drawing.Size(288, 25);
            this.txtSreachSongName.TabIndex = 12;
            this.txtSreachSongName.Text = "输入要搜索的歌曲名或歌手名";
            this.txtSreachSongName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSreachSongName.TextChanged += new System.EventHandler(this.txtSreachSongName_TextChanged);
            // 
            // lbNotFoundSong
            // 
            this.lbNotFoundSong.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNotFoundSong.ForeColor = System.Drawing.Color.Red;
            this.lbNotFoundSong.Location = new System.Drawing.Point(724, 473);
            this.lbNotFoundSong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNotFoundSong.Name = "lbNotFoundSong";
            this.lbNotFoundSong.Size = new System.Drawing.Size(217, 29);
            this.lbNotFoundSong.TabIndex = 14;
            this.lbNotFoundSong.Text = "没有找到相关歌曲";
            this.lbNotFoundSong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNotFoundSong.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 562);
            this.Controls.Add(this.lbNotFoundSong);
            this.Controls.Add(this.txtSreachSongName);
            this.Controls.Add(this.pbAlbumImage);
            this.Controls.Add(this.btnPlayMode);
            this.Controls.Add(this.lbVolumeVal);
            this.Controls.Add(this.tkbVol);
            this.Controls.Add(this.lstSongList);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.stsInfo);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tkbMove);
            this.Controls.Add(this.AxWmp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.Text = "Windows Media Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.AxWmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbMove)).EndInit();
            this.stsInfo.ResumeLayout(false);
            this.stsInfo.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ntiContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tkbVol)).EndInit();
            this.cmsSongListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer AxWmp;
        private System.Windows.Forms.TrackBar tkbMove;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.StatusStrip stsInfo;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.ContextMenuStrip ntiContextMenu;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.OpenFileDialog odlgFile;
        private System.Windows.Forms.TrackBar tkbVol;
        private System.Windows.Forms.Label lbVolumeVal;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentPlayState;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ContextMenuStrip cmsSongListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSongInfoDetail;
        private System.Windows.Forms.Button btnPlayMode;
        private System.Windows.Forms.PictureBox pbAlbumImage;
        private System.Windows.Forms.TextBox txtSreachSongName;
        private System.Windows.Forms.Label lbNotFoundSong;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveSongFromList;
        public System.Windows.Forms.ListBox lstSongList;
        private System.Windows.Forms.ToolTip tip;
    }
}

