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

namespace WindowsFormApp_TcpServer
{
    public partial class Form1 : Form
    {
        private Thread serverThread;
        private Thread receiveThread;
        private Socket clnSocket;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(textBox2.Text);
            clnSocket.Send(sendBytes);
            textBox1.AppendText("Me : " + textBox2.Text);
            textBox1.AppendText("\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();
           
        }
        private void serverFunc(object obj)
        {
           
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);

            clnSocket = serverSocket.Accept();   //Block I/O, 클라이언트로부터 데이터 오기전까지 대기.
            textBox1.Text = "서버 시작...\r\n";
            receiveThread = new Thread(Receive);
            receiveThread.IsBackground = true;
            receiveThread.Start();
            
            //clnSocket.Close();
  
        }
        private void Receive()
        {
            while (true)
            {
                byte[] recvBytes = new byte[1024];
                clnSocket.Receive(recvBytes);   //클라이언트
                string txt = Encoding.UTF8.GetString(recvBytes, 0, recvBytes.Length);
                
                textBox1.AppendText("Client : " + txt);
                textBox1.AppendText("\r\n");
            }
            
        }
    }
}
