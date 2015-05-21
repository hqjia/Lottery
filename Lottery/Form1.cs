using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Lottery
{
    public partial class Form1 : Form
    {
        static int STATUS;
        static int FLAG = 0;
        static Thread t;

        public Form1()
        {
            InitializeComponent();
            init();
            
            t = new Thread(listen);
            t.IsBackground = true;
            t.Start();
        }


        static void listen()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 26379);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(ipep);
            //sock.Listen(3);
            while(true){
                try {
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint Remote = (EndPoint)(sender);
                byte[] bytes = new byte[32];
                int bytenum = sock.ReceiveFrom(bytes, ref Remote);
                //MessageBox.Show(bytenum.ToString() + " receivd.");
                FLAG = bytes[0];
                sock.SendTo(bytes, bytenum, SocketFlags.None, Remote);
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void init(){
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            STATUS = 0;
            buttonStart.Text = "开始";
            button1.Text = "";
            button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            button2.Text = "";
            button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            button3.Text = "";
            button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            button4.Text = "";
            button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            button5.Text = "";
            button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            button6.Text = "";
            button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            button7.Text = "";
            button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            button8.Text = "";
            button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
        }

        private void buttonPrint(int i, string text)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1.BackgroundImage = null;
            button2.BackgroundImage = null;
            button3.BackgroundImage = null;
            button4.BackgroundImage = null;
            button5.BackgroundImage = null;
            button6.BackgroundImage = null;
            button7.BackgroundImage = null;
            button8.BackgroundImage = null;

            switch (i)
            {
                case 1:
                    button1.Text = text;
                    button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
                    break;
                case 2:
                    button2.Text = text;
                    button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
                    break;
                case 3:
                    button3.Text = text;
                    button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
                    break;
                case 4:
                    button4.Text = text;
                    button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
                    break;
                case 5:
                    button5.Text = text;
                    button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
                    break;
                case 6:
                    button6.Text = text;
                    button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
                    break;
                case 7:
                    button7.Text = text;
                    button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
                    break;
                case 8:
                    button8.Text = text;
                    button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
                    break;
                default:
                    break;
            }
        }

        private void buttonFlash(int i, int time)
        {
            switch (i)
            {
                case 1:
                    button1.FlatStyle = FlatStyle.Standard;
                    button1.Update();
                    Thread.Sleep(time);
                    button1.FlatStyle = FlatStyle.Flat;
                    button1.Update();
                    break;
                case 2:
                    button2.FlatStyle = FlatStyle.Standard;
                    button2.Update();
                    Thread.Sleep(time);
                    button2.FlatStyle = FlatStyle.Flat;
                    button2.Update();
                    break;
                case 3:
                    button3.FlatStyle = FlatStyle.Standard;
                    button3.Update();
                    Thread.Sleep(time);
                    button3.FlatStyle = FlatStyle.Flat;
                    button3.Update();
                    break;
                case 4:
                    button4.FlatStyle = FlatStyle.Standard;
                    button4.Update();
                    Thread.Sleep(time);
                    button4.FlatStyle = FlatStyle.Flat;
                    button4.Update();
                    break;
                case 5:
                    button5.FlatStyle = FlatStyle.Standard;
                    button5.Update();
                    Thread.Sleep(time);
                    button5.FlatStyle = FlatStyle.Flat;
                    button5.Update();
                    break;
                case 6:
                    button6.FlatStyle = FlatStyle.Standard;
                    button6.Update();
                    Thread.Sleep(time);
                    button6.FlatStyle = FlatStyle.Flat;
                    button6.Update();
                    break;
                case 7:
                    button7.FlatStyle = FlatStyle.Standard;
                    button7.Update();
                    Thread.Sleep(time);
                    button7.FlatStyle = FlatStyle.Flat;
                    button7.Update();
                    break;
                case 8:
                    button8.FlatStyle = FlatStyle.Standard;
                    button8.Update();
                    Thread.Sleep(time);
                    button8.FlatStyle = FlatStyle.Flat;
                    button8.Update();
                    break;
                default:
                    break;
            }
                 
        }

        private void randomlot()
        {
            Random rd = new Random();

            int n = rd.Next(1, 9);

            for (int i = 0; i < 24 + n; i++)
            {
                     int num = i % 8 + 1;
                     int time = 10 * ((i / 2 )+ 1);
                     buttonFlash(num, time);
            }
            if (n == 1 || n == 6)
            {
                buttonPrint(n, "");
            }
            else
            {
                buttonPrint(n, "");
            }
            
        }

        private void buzhong(){
            Random rd = new Random();

            int n = rd.Next(1, 9);
            if (n == 1 || n == 6){
                n++;
            }

            for (int i = 0; i < 24 + n; i++)
            {
                     int num = i % 8 + 1;
                     int time = 10 * ((i / 2 )+ 1);
                     buttonFlash(num, time);
            }
            if (n == 1 || n == 6)
            {
                buttonPrint(n, "");
            }
            else
            {
                buttonPrint(n, "");
            }
        }

        private void bizhong()
        {
            Random rd = new Random();

            int n = rd.Next(1, 3);
            if (n > 1)
            {
                n = 6;
            }

            for (int i = 0; i < 24 + n; i++)
            {
                int num = i % 8 + 1;
                int time = 10 * ((i / 2) + 1);
                buttonFlash(num, time);
            }
            if (n == 1 || n == 6)
            {
                buttonPrint(n, "");
            }
            else
            {
                buttonPrint(n, "");
            }
        }

        private void doLottery()
        {
            switch (FLAG)
            {
                case 0:
                    randomlot();
                    break;
                case 1:
                    bizhong();
                    break;
                case 2:
                    buzhong();
                    break;
                default:
                    return;
                      
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (STATUS == 0)
            {
                doLottery();
                STATUS = 1;
                buttonStart.Text = "再来";
            }
            else
            {
                init();
            }
        }

    }
}
