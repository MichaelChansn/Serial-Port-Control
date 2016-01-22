using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.CodeDom;


namespace 串口通信
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private bool isopen = false;
        //private bool got = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 4;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 1;
            comboBox5.SelectedIndex = 0;
            //textBox2.Text = "HELLO";
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "打开串口")
            {
                button2.Text = "关闭串口";
                serialPort1.PortName = comboBox3.Text.Trim().ToString();
                serialPort1.BaudRate = Convert.ToInt32(comboBox1.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBox5.Text);
                if (comboBox4.Text == "0")
                    serialPort1.StopBits = StopBits.None;
                if (comboBox4.Text == "1")
                    serialPort1.StopBits = StopBits.One;
                if (comboBox4.Text == "1.5")
                    serialPort1.StopBits = StopBits.OnePointFive;
                if (comboBox4.Text == "2")
                    serialPort1.StopBits = StopBits.Two;
                if (comboBox2.Text == "无")
                    serialPort1.Parity = Parity.None;
                if (comboBox2.Text == "奇校验")
                    serialPort1.Parity = Parity.Odd;
                if (comboBox2.Text == "偶校验")
                    serialPort1.Parity = Parity.Even;
                serialPort1.ReadTimeout = 100;
                try
                {
                    serialPort1.Open();
                    
                    isopen = true;
                    textBox1.Clear();

                    textBox1.Text += serialPort1.PortName + "打开成功\r\n" + "已打开串口信息：" + "\r\n" + "串口号：" + serialPort1.PortName + "\r\n" + "波特率：" + serialPort1.BaudRate.ToString() + "\r\n" + "数据位：" + serialPort1.DataBits.ToString() + "\r\n" + "停止位：" + serialPort1.StopBits.ToString() + "\r\n" + "校验位：" + serialPort1.Parity.ToString() + "\r\n";
                }
                catch
                {
                    textBox1.Clear();
                    textBox1.Text += serialPort1.PortName + "打开失败" + "\r\n";
                    textBox1.Text += "希望打开串口信息：" + "\r\n" + "串口号：" + serialPort1.PortName + "\r\n" + "波特率：" + serialPort1.BaudRate.ToString() + "\r\n" + "数据位：" + serialPort1.DataBits.ToString() + "\r\n" + "停止位：" + serialPort1.StopBits.ToString() + "\r\n" + "校验位：" + serialPort1.Parity.ToString() + "\r\n";


                }
            }
            else
            {
                button2.Text = "打开串口";
                serialPort1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    serialPort1.PortName = "COM" + (i+1).ToString();
                    serialPort1.Open();
                    textBox1.Text += serialPort1.PortName + "可用"+"\r\n";
                    serialPort1.Close();
                    
                }
                catch
                {
                    textBox1.Text += "COM" + (i+1).ToString() + "不可用"+"\r\n";
                    serialPort1.Close();
                    
 
                }
 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("l");
                textBox2.Clear();
                textBox2.Text += "当前状态：向左";
            }
            catch
            {
                //MessageBox.Show("向左控制失败");
                textBox2.Clear();
                textBox2.Text += "向左控制失败";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("u");
                textBox2.Clear();
                textBox2.Text += "当前状态：向上";
            }
            catch
            {
               // MessageBox.Show("向上控制失败");
                textBox2.Clear();
                textBox2.Text += "向上控制失败";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("d");
                textBox2.Clear();
                textBox2.Text += "当前状态：向下";
            }
            catch
            {
              //  MessageBox.Show("向下控制失败");
                textBox2.Clear();
                textBox2.Text += "向下控制失败";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("r");
                textBox2.Clear();
                textBox2.Text += "当前状态：向右";
            }
            catch
            {
               // MessageBox.Show("向右控制失败");
                textBox2.Clear();
                textBox2.Text += "向右控制失败";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("s");
                textBox2.Clear();
                textBox2.Text += "当前状态：停止";
            }
            catch
            {
                // MessageBox.Show("停止控制失败");
                textBox2.Clear();
                textBox2.Text += "停止控制失败";
            }
        }

       

        /*
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==System.Windows.Forms.Keys.Left)
            {
                button4.Focus();//=true; ;
                button4_Click(null, null);
                
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                button5.Focus();//=true; ;
                button5_Click(null, null);

            }
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                button3.Focus();//=true; ;
                button3_Click(null, null);

            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                button6.Focus();//=true; ;
                button6_Click(null, null);

            }
        }
        */

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Left)
            {
                button4.Focus();//=true; ;
                button4_Click(null, null);
               // button4.Focus();

            }
            if (e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                button5.Focus();//=true; ;
                button5_Click(null, null);
                //button5.Focus();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                button3.Focus();//=true; ;
                button3_Click(null, null);
                //button3.Focus();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                button6.Focus();//=true; ;
                button6_Click(null, null);
               // button6.Focus();
             
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            { 
                button7.Focus();//=true; ;
                button7_Click(null, null);
                //button7.Focus();

            }
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(textBox2.Text);
            textBox2.Clear();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            //textBox2.Text = serialPort1.ReadExisting();// ReadLine() + "\r\n";
                //if (button9.Text == "接收数据")
                //{
                //    button9.Text = "停止接收";
                //    timer1.Enabled = true;
                //    try
                //    {
                //        textBox2.Clear();
                //        textBox2.Text += serialPort1.ReadLine() + "\r\n";
                //    }
                //    catch
                //    {
                //        timer1.Enabled = false;
                        
                //    }
                //}
                //else
                //{
                //    button9.Text = "接收数据";
                //    timer1.Enabled = false;
                //}
        }
        private string tempstr;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isopen == true)//&&got==true)
            {
                timer1.Enabled = false;
                //got = false;
                try
                {
                    tempstr = serialPort1.ReadExisting();//ReadExisting();//ReadLine() + "\r\n";
                    textBox2.Text += tempstr.Substring(tempstr.Length - 4, 4);
                }
                catch
                {
                    timer1.Enabled = false;
                }
            }
            
            timer1.Enabled = true;
           // got = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "开始接收")
            {
                button10.Text = "关闭接收";
                timer1.Enabled = true;
            }
            else
            {

                button10.Text = "开始接收";
                timer1.Enabled = false;
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //textBox2.Text += serialPort1.ReadLine() + "\r\n";
           // got = true;
            
        }

        

     
        
        

        


        
    }
}
