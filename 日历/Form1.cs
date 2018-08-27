using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
  
        private void Judge (int a, int b, int c,string j)
        {
            DateTime dt = new DateTime(a,b ,c );
            if (dt == monthCalendar1.SelectionStart)
                label1.Text = j;
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            int year;
          label1.Text = "无节日";
            for (year = 1900; year < 3000; year++)
            {
                Judge(year, 1, 1, "元旦");
                Judge(year, 2, 2, "世界湿地日");
                Judge(year, 2, 10, "国际气象节");
                Judge(year, 2, 14, "情人节");
                Judge(year, 3, 1, "国际海豹日");
                Judge(year, 3, 5, "学雷锋纪念日");
                Judge(year, 3, 8, "妇女节");
                Judge(year, 3, 12, "植树节 孙中山逝世纪念日");
                Judge(year, 3, 14, "国际警察日");
                Judge(year, 3, 15, "消费者权益日");
                Judge(year, 3, 17, "中国国医节 国际航海日");
                Judge(year, 3, 21, "世界森林日 消除种族歧视国际日 世界儿歌日");
                Judge(year, 3, 22, "世界水日");
                Judge(year, 3, 24, "世界防治结核病日");
                Judge(year, 4, 1, "愚人节");
                Judge(year, 4, 7, "世界卫生日");
                Judge(year, 4, 22, "世界地球日");
                Judge(year, 5, 1, "劳动节");
                Judge(year, 5, 2, "劳动节假日");
                Judge(year, 5, 3, "劳动节假日");
                Judge(year, 5, 4, "青年节");
                Judge(year, 5, 8, "世界红十字日");
                Judge(year, 5, 12, "国际护士节");
                Judge(year, 5, 31, "世界无烟日");
                Judge(year, 6, 1, "国际儿童节");
                Judge(year, 6, 5, "世界环境保护日");
                Judge(year, 6, 26, "国际禁毒日");
                Judge(year, 7, 1, "建党节 香港回归纪念 世界建筑日");
                Judge(year, 7, 11, "世界人口日");
                Judge(year, 8, 1, "建军节");
                Judge(year, 8, 8, "中国男子节 父亲节");
                Judge(year, 8, 15, "抗日战争胜利纪念");
                Judge(year, 9, 9, "maozedong逝世纪念");
                Judge(year, 9, 10, "教师节");
                Judge(year, 9, 18, "九·一八事变纪念日");
                Judge(year, 9, 20, "国际爱牙日");
                Judge(year, 9, 27, "世界旅游日");
                Judge(year, 9, 28, "孔子诞辰");
                Judge(year, 10, 1, "国庆节 国际音乐日");
                Judge(year, 10, 2, "国庆节假日");
                Judge(year, 10, 3, "国庆节假日");
                Judge(year, 10, 6, "老人节");
                Judge(year, 10, 24, "联合国日");
                Judge(year, 11, 10, "世界青年节");
                Judge(year, 11, 12, "孙中山诞辰纪念");
                Judge(year, 12, 1, "世界艾滋病日");
                Judge(year, 12, 3, "世界残疾人日");
                Judge(year, 12, 20, "澳门回归纪念");
                Judge(year, 12, 24, "平安夜");
                Judge(year, 12, 25, "圣诞节");
            }
         
    

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
