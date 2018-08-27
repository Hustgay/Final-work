using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace 小说阅读器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath +"/Skins"+ "//WaveColor2.ssk";
        }
        string SaveNovelRecord, SaveRecordString;
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory + "/小说";//初始路径
            string[] dirs = Directory.GetDirectories(path);
            for (int i = 0; i < dirs.Length; i++)
            {
                int count = 0;
                if (HasSubfile(dirs[i], count))
                {
                    TreeNode nod = treeView1.Nodes.Add(Path.GetFileName(dirs[i]));
                    Addnodes(dirs[i], nod);
                }
            }
            string[] files = Directory.GetFiles(path, "*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                TreeNode nod = treeView1.Nodes.Add(Path.GetFileNameWithoutExtension(files[i]));
                nod.Tag = files[i];

            }
        }
    

public void Addnodes(string path, TreeNode node)//使用递归，查找文件夹并添加txt文件到treewiew中！
        {
            string[] dir = Directory.GetDirectories(path);
            for (int i = 0; i < dir.Length; i++)
            {
                int count = 0;
                if (HasSubfile(dir[i], count))
                {
                    TreeNode nod = node.Nodes.Add(Path.GetFileNameWithoutExtension(dir[i]));
                    Addnodes(dir[i], nod);
                   
                }
                
            }
            string[] file = Directory.GetFiles(path, "*.txt");
            for (int i = 0; i < file.Length; i++)
            {
                TreeNode nod = node.Nodes.Add(Path.GetFileNameWithoutExtension(file[i]));
                nod.Tag = file[i];
                SaveNovelRecord+= Path.GetFileNameWithoutExtension(file[i])+",";
            }         
        }
        private bool HasSubfile(string path, int count)//判断文件夹以及其子文件夹是否包含txt文件，使用递归调用；
        {

            string[] files = Directory.GetFiles(path, "*.txt");
            if (files.Length != 0)
            {
                count += files.Length;
            }
            string[] dirs = Directory.GetDirectories(path);
            for (int i = 0; i < dirs.Length; i++)
            {
                HasSubfile(dirs[i], count);
            }
            if (count != 0)
            {
                return true;
            }
            else return false;
        }
        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                textBox1.Text = File.ReadAllText(e.Node.Tag.ToString(), System.Text.Encoding.Default);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();     //显示选择文件对话框
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|pdf files|*.pdf";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = File.ReadAllText(openFileDialog1.FileName, System.Text.Encoding.Default);          //显示文件路径
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = System.Environment.CurrentDirectory;
            dialog.Filter = "文本文件|*.txt|*.pdf";
            // 显示对话框
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 文件名
                string fileName = dialog.FileName;
                // 创建文件，准备写入
                FileStream fs = File.Open(fileName,
                        FileMode.Create,
                        FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);

                // 逐行将textBox1的内容写入到文件中
                foreach (string line in textBox1.Lines)
                {
                    wr.WriteLine(line);
                }
                // 关闭文件
                wr.Flush();
                wr.Close();
                fs.Close();
            }
        }
        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                 textBox1.Font = fontDialog1.Font;
            }
        }
        TreeNode node1=new TreeNode();
        int count = 0;
        void ErgodicTreeView(TreeNode tn,string strValue)
        {
            
            if (tn == null) return;
            //查找到某节点时
            if (tn.Text == strValue)
            {
                //遍历递归获取父节点，将父节点全部展开
                Prenode(tn);
                //选中某节点，并加背景颜色
                treeView1.SelectedNode = tn;
                treeView1.SelectedNode.BackColor = System.Drawing.Color.Gray;
                count++;
                node1 = tn;
            }
            foreach (TreeNode n in tn.Nodes)
            {
                ErgodicTreeView(n,strValue);
            }
        }
        void Prenode(TreeNode m)
        {
            if (m.Parent.Text != null)
            {
                m.Parent.Expand();
                //当为项级节点时
                if (m.Parent.Level == 0)
                {
                    m.Parent.Expand();
                }
                //不是项级节点时
                else
                {
                    Prenode(m.Parent);
                }
            }

        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            node1.BackColor= System.Drawing.Color.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            count = 0;           
            string strValue = textBox2.Text.ToString();
            foreach (TreeNode n in treeView1.Nodes)
            {
                ErgodicTreeView(n,strValue);
            }
            if (count >= 2)//同名搜索结果大于2的时候进行提示
            {
                MessageBox.Show("搜索到" + count.ToString() + "个结果，自动为您打开第" + count.ToString() + "个结果");
            }
        }
        private void button3_Click(object sender, EventArgs e)//夜间模式
        {
            textBox1.BackColor = System.Drawing.Color.Black;
            textBox1.ForeColor = Color.White;
        }
        private void button4_Click(object sender, EventArgs e)//日间模式
        {
            textBox1.BackColor = System.Drawing.Color.White;
            textBox1.ForeColor = Color.Black;
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            string[] SaveRecord = SaveNovelRecord.Split(',');
            string[] lines = ReadAllText().Split(':');
            string[] SaveNovelName = new string[100];
            string[] SaveCursorPosition = new string[100];
            
            for (int j = 1; j < lines.Length; j++)
            {
                if (j % 2 != 0 && lines[j] !=null)
                {
                    SaveNovelName[(j - 1) / 2] += lines[j - 1];
                    SaveCursorPosition[(j - 1) / 2] += lines[j];
                }
            }
            for (int i = 0; i < SaveRecord.Length - 1; i++)
            {
                int CountIsNotFindRecord = 0;
                int CountFindRecord = 0;
                if (SaveRecord[i] == null)
                    break;
                else if (SaveRecord[i] == treeView1.SelectedNode.Text)
                {
                    SaveRecord[i] = SaveRecord[i] + ":" + textBox1.SelectionStart.ToString();
                    CountFindRecord++;
                }
                for (int k = 0; k < SaveNovelName.Length; k++)
                {

                    if (SaveRecord[i] == SaveNovelName[k])
                    {
                        SaveRecord[i] += ":" + SaveCursorPosition[k];
                        CountFindRecord++;
                        break;
                    }
                    else
                        CountIsNotFindRecord++;
                }
                if (CountIsNotFindRecord == SaveNovelName.Length&& CountFindRecord == 0)
                    SaveRecord[i] += ":" + "0";
                SaveRecordString += SaveRecord[i] + "\r\n";              
            }           
            System.IO.File.WriteAllText(System.Environment.CurrentDirectory + "/1.txt", SaveRecordString, Encoding.Default);
            MessageBox.Show("进度已保存");
            
        }       
        private string ReadAllText()
        {
            string ReadAllText = File.ReadAllText(System.Environment.CurrentDirectory + "/1.txt", Encoding.Default);
            string line = ReadAllText.Replace("\r\n", ":");
            return line; ;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button5_Click(sender, e);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int CursorPosition;            
            string[] lines = ReadAllText().Split(':');
            for (int i = 0; i < lines.Length; i++)
            {               
                if (lines[i] == null)           
                    break;
                else if(i%2==0&&treeView1.SelectedNode.Text==lines[i])
                {
                   CursorPosition = Convert.ToInt32(lines[i+1]);
                    textBox1.Select(CursorPosition,0);
                    textBox1.ScrollToCaret();
                    textBox1.Focus();
                }
            }
        }
    }
}
    
    

    

