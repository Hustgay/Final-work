using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 娱乐大厅
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = Application.StartupPath + "/Skins/MidsummerColor1.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/snake.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/见缝插针.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/小说阅读器/小说阅读器.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/音乐播放器/SimpleMediaPlayer.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/俄罗斯方块/俄罗斯方块.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/工具/计算器.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/娱乐平台/工具/日历.exe");
        }

        private void 软件简介ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本软件为断网时代-综合娱乐平台，旨在为用户提供断网时最贴心最方便的娱乐活动！");
        }

        private void 帮助信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start(Application.StartupPath + "/帮助文档.txt");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本软件由软件工程营三班第六组共同研发" + "\n" + "开发人员名单：向朝阳，张俊，彭圣钧，彭杰科，肖凯");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
