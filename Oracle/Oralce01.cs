using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleTest_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.오라클 모듈 받기
            // 오라클 연결 문자열        

            //string strConn = "Data Source=orcl;User Id=scott;Password=TIGER;";

            // 네트워크 연결 정보 직접 대입

            string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";



            // 오라클 연결

            OracleConnection conn = new OracleConnection(strConn);

            conn.Open();
            Console.WriteLine("연결 됨.");
            //...

            conn.Close();
            Console.WriteLine("종료.");
        }
    }
}
