using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp_TcpClient
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private Thread receiveThread;
        private Thread waitThread;



        public Form1()
        {
            InitializeComponent();
        }

        private void Receive()
        {
            while (true)
            {
                byte[] recvBytes = new byte[1024];
                socket.Receive(recvBytes);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, recvBytes.Length);

                listBox1.Items.Add("서버: " + txt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(textBox2.Text);
            socket.Send(sendBytes);
            listBox1.Items.Add("클라이언트: " + textBox2.Text);
            textBox2.Text = "";



        }
        private void wait()
        {
            //1.소켓만들기
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2.연결
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10000);
            socket.Connect(serverEP);
            MessageBox.Show("연결됨");

            receiveThread = new Thread(Receive);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            waitThread = new Thread(wait);
            waitThread.IsBackground = true;
            waitThread.Start();

        }
    }
}

