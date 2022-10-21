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
        private Thread clientThread;
        private Thread receiveThread;
        private Socket socket;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            clientThread = new Thread(clientFunc);
            clientThread.IsBackground = true;
            clientThread.Start();    
        }
        private void clientFunc(object obj)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);
            socket.Connect(serverEP);    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string order = $"{comboBox1.Text}/{comboBox2.Text}/{comboBox3.Text}/{comboBox4.Text}/{textBox1.Text}";
            byte[] buf = Encoding.UTF8.GetBytes(order);
            socket.Send(buf);
            MessageBox.Show("주문을 완료하였습니다.","알림");
        }
    }
}
