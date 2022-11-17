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

namespace MES_UI
{
    public partial class Form2 : Form
    {

        OracleCommand cmd = new OracleCommand();
        OracleDataReader rdr;
        OracleConnection conn = new OracleConnection(strConn);
        static string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
                                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr ;Password=hr;";
        OracleDataAdapter adapt = new OracleDataAdapter();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;
            string A = "select S.StId as 재고아이디, PD.PMName as 재고명, S.StQty as 수량, PD.PMUnit as 단위, S.StDate as 입고날짜 from PdMaster PD join Stock S on PD.PMId = S.PMId group by S.StId, PD.PMName, S.StQty, PD.PMUnit, S.StDate order by S.StId";

            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(A, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string A = $"select S.StId as 재고아이디, PD.PMName as 재고명, S.StQty as 수량, PD.PMUnit as 단위 from PdMaster PD join Stock S on PD.PMId = S.PMId where S.StDate between '{dateTimePicker1.Text}' and '{dateTimePicker2.Text}' group by S.StId, PD.PMName, S.StQty, PD.PMUnit order by S.StId";

            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(A, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
