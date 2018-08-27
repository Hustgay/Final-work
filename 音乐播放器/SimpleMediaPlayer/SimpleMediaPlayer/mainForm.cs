using AxWMPLib;
using SimpleMediaPlayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Text.RegularExpressions;


namespace SimpleMediaPlayer
{
    public partial class mainForm : Form
    {
        AxWindowsMediaPlayer testAWM = new AxWMPLib.AxWindowsMediaPlayer();
        SongsInfo currPlaySong = new SongsInfo(null);
        SongsInfo currSelectedSong = new SongsInfo(null);      
        private List<SongsInfo> oringinListSong;          
        public enum PlayMode { Shuffle = 0, SingleLoop, ListLoop };
        public PlayMode currPlayMode = PlayMode.Shuffle;
        private int[] randomList;           
        private int randomListIndex = 0;  
        private int jumpSongIndex;      

        private ThumbnailToolbarButton ttbbtnPlayPause;
        private ThumbnailToolbarButton ttbbtnPre;
        private ThumbnailToolbarButton ttbbtnNext;
        private ToolTip tooltip1 = new ToolTip();
        private int preIndex = -1;      //用于lstSongList的气泡提示


        public mainForm()
        {
            InitializeComponent();
            //检测MediaPlayer控件是否有安装
            //if (testAWM == null)
            //{
            //    throw new Exception();
            //}
            //else
            //{
            //    testAWM.Dispose();
            //}
            testAWM.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(AxWmp_PlayStateChange);
        }


        #region 窗体操作
        private void Form1_Load(object sender, EventArgs e)
        {
            this.odlgFile.Multiselect = true;
            lstSongList.DisplayMember = "fileName";
            lstSongList.ValueMember = "filePath";
            ReloadStatus();
            ReadHistory();

            //CreateTooltip(0);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ttbbtnPlayPause = new ThumbnailToolbarButton(Properties.Resources.ttbbtnPlay, "播放");
            ttbbtnPlayPause.Enabled = true;
            ttbbtnPlayPause.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnPlay_Click);

            ttbbtnPre = new ThumbnailToolbarButton(Properties.Resources.ttbbtnPre, "上一首");
            ttbbtnPre.Enabled = true;
            ttbbtnPre.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnBack_Click);

            ttbbtnNext = new ThumbnailToolbarButton(Properties.Resources.ttbbtnNext, "下一首");
            ttbbtnNext.Enabled = true;
            ttbbtnNext.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnNext_Click);

            TaskbarManager.Instance.ThumbnailToolbars.AddButtons(this.Handle, ttbbtnPre, ttbbtnPlayPause, ttbbtnNext);
            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(pbAlbumImage.Location, pbAlbumImage.Size));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveHistory();
            Application.Exit();
            this.Dispose();
        }
        #endregion

        
        #region 添加音乐
        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            this.odlgFile.InitialDirectory = @"音乐播放器/music";
            this.odlgFile.Filter = "媒体文件|*.mp3;*.wav;*.wma;*.avi;*.mpg;*.asf;*.wmv";
            if (odlgFile.ShowDialog() == DialogResult.OK)
            {
                lstSongList.BeginUpdate();
                for (int i = 0; i < odlgFile.FileNames.Length; i++)
                {
                    string path = odlgFile.FileNames[i];
                    AddSongsToList(path);
                }
                lstSongList.EndUpdate();
            }

            UpdataOringinSongList();
            SaveHistory();
        }

        private void AddSongsToList(string path)
        {
            if (!IsExistInList(path))
            {
                SongsInfo songsInfo = new SongsInfo(path);
                lstSongList.Items.Add(songsInfo);
                WMPLib.IWMPMedia media = AxWmp.newMedia(path);
                AxWmp.currentPlaylist.appendItem(media);
            }
        }

        private bool IsExistInList(string path)
        {
            for (int i = 0; i < lstSongList.Items.Count; i++)
            {
                if (path == ((SongsInfo)lstSongList.Items[i]).FilePath)
                    return true;
            }
            return false;
        }
        #endregion
        

        #region 控制按钮单击事件
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->暂停
            {
                AxWmp.Ctlcontrols.pause();
                btnPlay.BackgroundImage = Resources.播放Hover;
                ttbbtnPlayPause.Icon = Resources.ttbbtnPlay;
                return;
            }
            else if(AxWmp.playState.ToString() == "wmppsPaused")    //暂停->播放
            {
                AxWmp.Ctlcontrols.play();
                btnPlay.BackgroundImage = Resources.暂停Hover;
                ttbbtnPlayPause.Icon = Resources.ttbbtnPause;
                return;
            }

            if (lstSongList.SelectedIndex >= 0)         //双击播放列表控制
            {
                Play(lstSongList.SelectedIndex);
            }
            else
                MessageBox.Show("请选择要播放的曲目");
        }
        
        private void btnStop_Click(object sender, EventArgs e)
        {
            AxWmp.Ctlcontrols.stop();
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lstSongList.SelectedIndex == -1)
                MessageBox.Show("请先添加曲目至目录");
            else if(lstSongList.SelectedIndex > 0)
            {
                AxWmp.Ctlcontrols.stop();
                lstSongList.SelectedIndex -= 1;
                Play(lstSongList.SelectedIndex);
            }
            else
            {
                AxWmp.Ctlcontrols.stop();
                lstSongList.SelectedIndex = lstSongList.Items.Count - 1;
                Play(lstSongList.SelectedIndex);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lstSongList.SelectedIndex == -1)
                MessageBox.Show("请先添加曲目至目录");
            else if (lstSongList.SelectedIndex < lstSongList.Items.Count-1)
            {
                AxWmp.Ctlcontrols.stop();
                lstSongList.SelectedIndex += 1;
                Play(lstSongList.SelectedIndex);
            }
            else
            {
                AxWmp.Ctlcontrols.stop();
                lstSongList.SelectedIndex = 0;
                Play(lstSongList.SelectedIndex);
            }
        }

        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            if (currPlayMode == PlayMode.ListLoop)
                currPlayMode = PlayMode.Shuffle;  
            else
                currPlayMode += 1;
            
            if (currPlayMode == PlayMode.SingleLoop)
                btnPlayMode.BackgroundImage = Properties.Resources.循环播放;
            else if (currPlayMode == PlayMode.ListLoop)
                btnPlayMode.BackgroundImage = Properties.Resources.顺序播放;
            else
                btnPlayMode.BackgroundImage = Properties.Resources.随机播放;
        }
        #endregion


        #region 播放状态
        private void Play(int index)
        {
            lstSongList.SelectedIndex = index;
            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
            {
                AxWmp.Ctlcontrols.pause();
                btnPlay.BackgroundImage = Resources.播放Hover;
                ttbbtnPlayPause.Icon = Resources.ttbbtnPlay;
                return;
            }
            if (AxWmp.playState.ToString() != "wmppsPaused")      //更改播放路径并播放
            {
                BuildRandomList(lstSongList.Items.Count);
                jumpSongIndex = index;
                currPlaySong = (SongsInfo)lstSongList.Items[index];
                AxWmp.URL = currPlaySong.FilePath;
                AxWmp.Ctlcontrols.play();
            }
            else                            //暂停->播放
                AxWmp.Ctlcontrols.play();

            btnPlay.BackgroundImage = Resources.暂停Hover;
            ttbbtnPlayPause.Icon = Resources.ttbbtnPause;
            ttbbtnPlayPause.Tooltip = "暂停";
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            string currPlayTime = null;
            currPlayTime = AxWmp.Ctlcontrols.currentPositionString;
            txtTime.Text = currPlayTime + "/" + currPlaySong.Duration.Remove(0, 3);
            tkbMove.Value = (int)AxWmp.Ctlcontrols.currentPosition;
        }

        private void AxWmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:    // Stopped
                    tsslCurrentPlayState.Text = "未知状态";
                    break;
                case 1:    // Stopped
                    tsslCurrentPlayState.Text = "停止";

                    timerPlay.Stop();
                    ReloadStatus();
                    break;

                case 2:    // Paused
                    tsslCurrentPlayState.Text = "暂停";

                    timerPlay.Stop();
                    break;

                case 3:    // Playing
                    tsslCurrentPlayState.Text = "正在播放";

                    timerPlay.Start();
               
                    pbAlbumImage.Image = currPlaySong.AlbumImage;
                    //txtTime.Text = "00:00/" + currPlaySong.Duration.Remove(0, 3);
                    tkbMove.Maximum = (int)AxWmp.currentMedia.duration;
                    break;
                case 4:    // ScanForward
                    tsslCurrentPlayState.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    tsslCurrentPlayState.Text = "ScanReverse";
                    break;
                case 6:    // Buffering
                    tsslCurrentPlayState.Text = "正在缓冲";
                    break;

                case 7:    // Waiting
                    tsslCurrentPlayState.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    tsslCurrentPlayState.Text = "MediaEnded";

                    break;

                case 9:    // Transitioning
                    tsslCurrentPlayState.Text = "正在连接";
                    break;

                case 10:   // Ready
                    tsslCurrentPlayState.Text = "准备就绪";
                    break;

                case 11:   // Reconnecting
                    tsslCurrentPlayState.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    tsslCurrentPlayState.Text = "Last";
                    break;
                default:
                    tsslCurrentPlayState.Text = ("Unknown State: " + e.newState.ToString());
                    break;
            }
            Console.WriteLine(tsslCurrentPlayState.Text);

            if (AxWmp.playState.ToString() == "wmppsMediaEnded")
            {
                Console.WriteLine(lstSongList.SelectedIndex + ":播放完毕");
                string path = GetPath();
                WMPLib.IWMPMedia media = AxWmp.newMedia(path);
                AxWmp.currentPlaylist.appendItem(media);
            }
        }

        private void ReloadStatus()
        {
            pbAlbumImage.Image = Properties.Resources.DefaultAlbum;
        
            txtTime.Text = "00:00/00:00";
            tsslCurrentPlayState.Text = "就绪";
            tkbVol.Value = tkbVol.Maximum / 2;
            lbVolumeVal.Text = "音量：";
            tkbMove.Value = 0;
            if (lstSongList.Items.Count > 0 && lstSongList.SelectedIndex == -1)
            {
                lstSongList.SelectedIndex = 0;
            }
        }
        #endregion


        #region 播放模式
        private string GetPath()
        {
        int currIndex = lstSongList.SelectedIndex;
        if (currPlayMode == PlayMode.ListLoop)       //列表循环
        {
            if (currIndex != lstSongList.Items.Count - 1)
            {
                currIndex += 1;
            }
            else
                currIndex = 0;
        }
        else if (currPlayMode == PlayMode.SingleLoop)  //单曲循环
        {
            //do nothing
        }
        else                    //随机播放
        {
            if (randomListIndex > randomList.Length - 1)
            {
                //当局结束
                StarNewRound();
            }

            //匹配到需要跳过的歌曲
            if (randomList[randomListIndex] == jumpSongIndex)
            {
                if (randomListIndex == randomList.Length - 1)
                {
                    //当局结束
                    StarNewRound();
                }
                else
                    randomListIndex++;
            }

            currIndex = randomList[randomListIndex++];
        }

        lstSongList.SelectedIndex = currIndex;
        currPlaySong = (SongsInfo)lstSongList.Items[currIndex];
        return ((SongsInfo)lstSongList.Items[currIndex]).FilePath;
        }

        private void StarNewRound()
        {
        //重新生成随机序列
        BuildRandomList(lstSongList.Items.Count);
        //第二轮开始 播放所有歌曲 不跳过
        jumpSongIndex = -1;
        }

        private void BuildRandomList(int songListCount)
        {
        randomListIndex = 0;
        randomList = new int[songListCount];

        //初始化序列
        for (int i = 0; i < songListCount; i++)
        {
            randomList[i] = i;
        }

        //随机序列
        for (int i = songListCount - 1; i >= 0; i--)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int j = r.Next(0, songListCount - 1);
            swap(randomList, i, j);
        }

        //输出序列
        //for (int i = 0; i < songListCount; i++)
        //{
        //    Console.Write(randomList[i] + " ");
        //}
        //Console.WriteLine(" ");
        }

        private void swap(int[] arr, int a, int b)
        {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
        }
        #endregion


        #region 音量与进度条事件
        private void tkbVol_ValueChanged(object sender, EventArgs e)
        {
            AxWmp.settings.volume = tkbVol.Value;
            lbVolumeVal.Text = tkbVol.Value.ToString() + "%";
        }

        private void tkbVol_MouseHover(object sender, EventArgs e)
        {
            lbVolumeVal.Text = tkbVol.Value.ToString() + "%";
        }

        private void tkbVol_MouseLeave(object sender, EventArgs e)
        {
            lbVolumeVal.Text = "音量：";
        }

        private void tkbMove_Scroll(object sender, EventArgs e)
        {
            AxWmp.Ctlcontrols.currentPosition = (double)this.tkbMove.Value;
        }
        #endregion


        #region 系统托盘
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void tsmiOpenForm_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            this.Close();
        }
        #endregion


        #region 播放列表双击&&右键菜单(详情、从列表中删除)&&气泡提示
        private void lstSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstSongList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (currPlaySong.FilePath == ((SongsInfo)lstSongList.Items[index]).FilePath)
                {
                    //选中歌曲为正在播放的歌曲
                    if (AxWmp.playState.ToString() == "wmppsPlaying")
                    {
                        AxWmp.Ctlcontrols.pause();
                        btnPlay.BackgroundImage = Resources.播放;
                        ttbbtnPlayPause.Icon = Resources.ttbbtnPlay;
                    }
                    else if (AxWmp.playState.ToString() == "wmppsPaused")
                    {
                        AxWmp.Ctlcontrols.play();
                        btnPlay.BackgroundImage = Resources.暂停;
                        ttbbtnPlayPause.Icon = Resources.ttbbtnPause;
                    }
                }
                else
                {
                    //选中的为其他歌曲
                    BuildRandomList(lstSongList.Items.Count);
                    jumpSongIndex = index;
                    currPlaySong = (SongsInfo)lstSongList.Items[index];
                    AxWmp.URL = currPlaySong.FilePath;
                    AxWmp.Ctlcontrols.play();
                    btnPlay.BackgroundImage = Resources.暂停;
                    ttbbtnPlayPause.Icon = Resources.ttbbtnPause;
                }
                lstSongList.SelectedIndex = index;
            }
        }

        private void lstSongList_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int index = lstSongList.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    currSelectedSong = (SongsInfo)(lstSongList.Items[index]);
                    cmsSongListMenu.Show(Cursor.Position);
                }
                else
                    cmsSongListMenu.Close();
            }
        }

        private void tsmiSongInfoDetail_Click(object sender, EventArgs e)
        {
            SongInfoDetailForm songInfoDetailForm = new SongInfoDetailForm(currSelectedSong);
            songInfoDetailForm.Show();
        }

        private void tsmiRemoveSongFromList_Click(object sender, EventArgs e)
        {
            DeleteSongFormList deleteSongFormList = new DeleteSongFormList(currSelectedSong.FilePath);
            if(deleteSongFormList.ShowDialog() == DialogResult.OK)
            {
                lstSongList.Items.RemoveAt(lstSongList.SelectedIndex);
                SaveHistory();
                UpdataOringinSongList();
            }
        }

        private void tsmiOpenFilePath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe","/select,"+currSelectedSong.FilePath);
        }

        private void lstSongList_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstSongList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches && preIndex != index)
            {
                preIndex = index;
                CreateTooltip(index);
            }
        }

        private void CreateTooltip(int index)
        {
            //悬停显示持续时长
            tooltip1.AutoPopDelay = 5000;
            //悬停显示响应时间
            tooltip1.InitialDelay = 100;
            //是否一直显示
            tooltip1.ShowAlways = false;
            //重显间隔时间
            tooltip1.ReshowDelay = 100;
            //淡入淡出效果
            tooltip1.UseFading = true;
            tooltip1.SetToolTip(lstSongList, ((SongsInfo)lstSongList.Items[index]).FileName);
        }
        #endregion


        #region 列表搜索
        private void UpdataOringinSongList()
        {
            oringinListSong = new List<SongsInfo>();
            for (int i = 0; i < lstSongList.Items.Count; i++)
            {
                oringinListSong.Add((SongsInfo)lstSongList.Items[i]);
            }
        }

        private void txtSreachSongName_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(txtSreachSongName.Text);
            lbNotFoundSong.Visible = false;
            if (txtSreachSongName.Text == "")
            {
                ReadHistory();
                return;
            }
            else
            {
                List<SongsInfo> sreachList = new List<SongsInfo>();

                string strSreach = txtSreachSongName.Text;
                Regex r = new Regex(Regex.Escape(strSreach), RegexOptions.IgnoreCase);

                if (oringinListSong.Count > 0)
                {
                    lstSongList.BeginUpdate();
                    for (int i = 0; i < oringinListSong.Count; i++)
                    {
                        Match m = r.Match(((SongsInfo)oringinListSong[i]).FileName);
                        if (m.Success)
                        {
                            sreachList.Add(oringinListSong[i]);
                        }
                    }
                    lstSongList.EndUpdate();
                }

                if (sreachList.Count > 0)
                {
                    lstSongList.Items.Clear();

                    lstSongList.BeginUpdate();
                    for (int i = 0; i < sreachList.Count; i++)
                    {
                        lstSongList.Items.Add(sreachList[i]);
                    }
                    lstSongList.EndUpdate();
                }
                else
                {
                    lstSongList.Items.Clear();
                    lbNotFoundSong.Visible = true;
                }
            }
        }
        #endregion


        #region 读写播放列表历史记录
        private void SaveHistory()
        {
            string saveString = "";
            for (int i = 0; i < lstSongList.Items.Count; i++)
            {
                saveString += ((SongsInfo)lstSongList.Items[i]).FilePath + "};{";
            }
            File.WriteAllText(Application.StartupPath + "\\songListHistory.txt", saveString);
        }

        private void ReadHistory()
        {
            string readString = "";
            string historyFilePath = Application.StartupPath + "\\songListHistory.txt";
            if (File.Exists(historyFilePath))
            {
                readString = File.ReadAllText(historyFilePath);
                if (readString != "")
                {
                    string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                    lstSongList.BeginUpdate();
                    foreach (string path in arr)
                    {
                        //目录文件不存在
                        if (path != null && path != "")
                        {
                            if (File.Exists(path))
                            {
                                AddSongsToList(path);
                            }
                            else
                            {
                                //标记项
                            }
                        }
                    }
                    lstSongList.EndUpdate();
                }
            }
            else
                File.Create(historyFilePath);

            UpdataOringinSongList();
        }
        #endregion


        #region 按钮
        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
            {
                btnPlay.BackgroundImage = Resources.暂停;
            }
            else
            {
                btnPlay.BackgroundImage = Resources.播放;
            }
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {

            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
            {
                btnPlay.BackgroundImage = Resources.暂停Hover;
            }
            else
            {
                btnPlay.BackgroundImage = Resources.播放Hover;
            }
        }



        #endregion

        private void lbVolumeVal_Click(object sender, EventArgs e)
        {

        }

        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lstSongList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pbAlbumImage_Click(object sender, EventArgs e)
        {

        }
    }
}
