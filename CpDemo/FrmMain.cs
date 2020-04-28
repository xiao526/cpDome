using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpDemo
{
    public partial class FrmMain : Form
    {
        private xhq objselector = new xhq();//创建选号器对象
        #region 初始化
        public FrmMain()
        {
            InitializeComponent();
            this.button3.Enabled = false;//禁用按钮
            this.button4.Enabled = false;
            this.button5.Enabled = false;
            this.button7.Enabled = false;
        }
        #endregion
        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗口
        }

        private void btmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗口
        }
        #region 窗体拖动事件
        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion
        //定时生成随机号码
        private void RandomTimer_Tick(object sender, EventArgs e)
        {
            string[] numList = objselector.sjs();
            this.label1.Text = numList[0].ToString();
            this.label2.Text = numList[1].ToString();
            this.label3.Text = numList[2].ToString();
            this.label4.Text = numList[3].ToString();
            this.label5.Text = numList[4].ToString();
            this.label6.Text = numList[5].ToString();
            this.label7.Text = numList[6].ToString();
        }
        //随机选号
        private void button6_Click(object sender, EventArgs e)
        {
            this.RandomTimer.Start();
            this.button6.Enabled = false;
            this.button3.Enabled = true;
        }
        //确认选号
        private void button3_Click(object sender, EventArgs e)
        {
            this.RandomTimer.Stop();
            string[] haoma =
            {
                this.label1.Text,
                this.label2.Text,
                this.label3.Text,
                this.label4.Text,
                this.label5.Text,
                this.label6.Text,
                this.label7.Text
            };
            objselector.haoma.Add(haoma);//保存当前选中的号码
            ShowSeletedNums();
        }
        private void ShowSeletedNums()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(this.objselector.GetprintedNumbs().ToArray());
            this.button6.Enabled = true;
            this.button7.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;


        }
        //手写号码
        private void button2_Click(object sender, EventArgs e)
        {
            string[] haoma =
{
                this.textBox1.Text,
                this.textBox2.Text,
                this.textBox3.Text,
                this.textBox4.Text,
                this.textBox5.Text,
                this.textBox6.Text,
                this.textBox7.Text
            };
            objselector.haoma.Add(haoma);//保存当前选中的号码
            ShowSeletedNums();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RandomTimer.Stop();//定时器停止
            this.objselector.CreaGroupNums(Convert.ToInt32(this.textBox8.Text.Trim()));
            ShowSeletedNums();
        }
        //删除选号
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count == 0 || this.listBox1.SelectedItem == null) return;
            int index = this.listBox1.SelectedIndex;//获取选中的索引
            objselector.haoma.RemoveAt(index);
            if(objselector.haoma.Count==0)//如果一个一个全部删掉
            {
                this.button7.Enabled = false;
                this.button4.Enabled = false;
                this.button5.Enabled = false;
            }
            ShowSeletedNums();
        }
        //清空号码
        private void button5_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();//从界面中清除显示
            this.objselector.haoma.Clear();
            //号码复位
            this.label1.Text = "0";
            this.label2.Text = "0";
            this.label3.Text = "0";
            this.label4.Text = "0";
            this.label5.Text = "0";
            this.label6.Text = "0";
            this.label7.Text = "0";

            this.textBox1.Text = "0";
            this.textBox2.Text = "0";
            this.textBox3.Text = "0";
            this.textBox4.Text = "0";
            this.textBox5.Text = "0";
            this.textBox6.Text = "0";
            this.textBox7.Text = "0";
            //禁用相关按钮
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;
            this.button7.Enabled = false;
        }
    }
}
