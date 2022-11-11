using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class LOGIN : Form
    {
        OracleCommand cmd = new OracleCommand();
        OracleDataReader rdr;
        OracleConnection conn = new OracleConnection(strConn);
        static string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr ;Password=hr;";
        OracleDataAdapter adapt = new OracleDataAdapter();

        public LOGIN()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            try
            {
                cmd.CommandText = $"SELECT id,passward,grade FROM Member WHERE id = '{textBox1.Text}' and passward = '{textBox2.Text}'";
                cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                string grade = rdr["grade"].ToString();

                if (grade == "A")
                {
                    this.Visible = false;
                    Admin showForm2 = new Admin();
                    showForm2.ShowDialog();
                }
                else
                {
                    this.Visible = false;
                    Form3 showForm3 = new Form3();
                    showForm3.ShowDialog();
                }
            }
            catch 
            {
                MessageBox.Show("아이디와 패스워드를 확인하세요.", "알림");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
