using Oracle.ManagedDataAccess.Client;
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

namespace Project_Server
{
    public partial class Form1 : Form
    {
        
        OracleCommand cmd = new OracleCommand();
        OracleDataReader rdr;
        OracleConnection conn = new OracleConnection(strConn);
        static string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";
        //private Thread MakeClothThread;
        private Thread serverThread;
        private Thread receiveThread;
        private Socket clnSocket;
        string[] txt_1;
        int cnt = 1;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;

            serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();

            cmd.CommandText = $"DELETE FROM ODER";
            cmd.ExecuteNonQuery();
        }
        private void serverFunc(object obj)
        {

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);

            clnSocket = serverSocket.Accept();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            receiveThread = new Thread(Receive);
            receiveThread.IsBackground = true;
            receiveThread.Start();
            string A = "SELECT * FROM oder";
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(A, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            string A = "SELECT * FROM STOCK";
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(A, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Receive()
        {
            
            while (true)
            {

                byte[] recvBytes1 = new byte[1024];

                clnSocket.Receive(recvBytes1);   //클라이언트
                string txt = Encoding.UTF8.GetString(recvBytes1, 0, recvBytes1.Length);
                txt_1 = txt.Split('/');

                //textBox1.AppendText($"{cnt}번째 주문 - 종류 :{txt_1[0]}, 색상 :{txt_1[1]}, 사이즈 :{txt_1[2]}, 옷감 :{txt_1[3]}, 개수 :{txt_1[4]}개");
                //textBox1.AppendText("\r\n");

                cmd.CommandText = $"INSERT INTO ODER (ID,NAME,COLOR,CLOTH_SIZE,FABRIC,CNT)VALUES({cnt},'{txt_1[0]}','{txt_1[1]}','{txt_1[2]}','{txt_1[3]}',{txt_1[4]})";
                cmd.ExecuteNonQuery();
                cnt++;
            }

        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuy1_Click(object sender, EventArgs e)
        {

            //int num1 = Int32.Parse(textBox2)
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA = DROGBA + '{textBox2.Text}' WHERE ID = '도료' AND NAME = '검정'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"검정색 도료 {textBox2.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox1.SelectedIndex = 0;
                    textBox2.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("도료의 갯수를 입력하지 않았습니다.", "오류");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA = DROGBA + '{textBox2.Text}' WHERE ID = '도료' AND NAME = '빨강'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"도료의 빨강색 도료 {textBox2.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox1.SelectedIndex = 0;
                    textBox2.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("도료의 갯수를 입력하지 않았습니다.", "오류");
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA= DROGBA + '{textBox2.Text}'  WHERE ID = '도료' AND NAME = '흰색'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"흰색 도료 {textBox2.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox1.SelectedIndex = 0;
                    textBox2.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("도료의 갯수를 입력하지 않았습니다.", "오류");
                }
            }

            if (comboBox2.SelectedIndex == 0)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA = DROGBA + '{textBox3.Text}' WHERE ID = '재질' AND NAME = '면'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"면 옷감 {textBox3.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox2.SelectedIndex = 0;
                    textBox3.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("옷감의 갯수를 입력하지 않았습니다.", "오류");
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA = DROGBA + '{textBox3.Text}' WHERE ID = '재질' AND NAME = '청'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"청 옷감 {textBox3.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox2.SelectedIndex = 0;
                    textBox3.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("옷감의 갯수를 입력하지 않았습니다.", "오류");
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                try
                {
                    cmd.CommandText = $"UPDATE STOCK SET DROGBA = DROGBA + '{textBox3.Text}' WHERE ID = '재질' AND NAME = '폴리'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"폴리 옷감 {textBox3.Text}개를 구매하셨습니다.", "알림");
                    cmd.CommandText = "Commit";
                    cmd.ExecuteNonQuery();
                    comboBox2.SelectedIndex = 0;
                    textBox3.Clear();
                }
                catch (Exception x)
                {
                    MessageBox.Show("옷감의 갯수를 입력하지 않았습니다.", "오류");
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            
            
        }

    }
}
