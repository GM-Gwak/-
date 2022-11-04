using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleTest_02
{
    
    class Func
    {
        string num1;
        string num2;
        string num3;
        OracleCommand cmd = new OracleCommand();
        OracleDataReader rdr;
        OracleConnection conn;
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";

        public void Create()
        {
            try
            {
                conn = new OracleConnection(strConn);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "create table ADDR_TABLE(" +
               "ADDR_ID NUMBER(4) PRIMARY KEY," +
               "NAME VARCHAR2(20)," +
               "HP VARCHAR2(20))";
                 
                cmd.ExecuteNonQuery();
                Console.WriteLine($"{"ID"} : {"이름"} : {"HP"}");
                Console.WriteLine("생성되었습니다.");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Select()
        {
            try
            {
                conn = new OracleConnection(strConn);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from ADDR_TABLE";
                rdr = cmd.ExecuteReader();
                Console.WriteLine($"{"ID"} : {"이름"} : {"HP"}");
                while (rdr.Read())
                {
                    string ADDR_ID = rdr["ADDR_ID"].ToString();
                    string NAME = rdr["NAME"] as string;
                    string HP = rdr["HP"].ToString();

                    Console.WriteLine($"{ADDR_ID} : {NAME} : {HP}");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void Insert()
        {
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd.Connection = conn;

            Console.WriteLine("아이디를 입력하세요.");
            num1 = Console.ReadLine();
            Console.WriteLine("이름을 입력하세요.");
            num2 = Console.ReadLine();
            Console.WriteLine("전화번호를 입력하세요.");
            num3 = Console.ReadLine();
            
            cmd.CommandText = $"INSERT INTO ADDR_TABLE(ADDR_ID,NAME,HP) VALUES('{num1}','{num2}','{num3}')";
            cmd.ExecuteNonQuery();
            Console.WriteLine("삽입되었습니다.");

        }
        public void Update()
        {
            Console.WriteLine("아이디를 입력하세요.");
            num1 = Console.ReadLine();
            Console.WriteLine("수정할 이름을 입력하세요.");
            num2 = Console.ReadLine();
            Console.WriteLine("수정할 전화번호를 입력하세요.");
            num3 = Console.ReadLine();

            cmd.CommandText = $"UPDATE ADDR_TABLE SET NAME='{num2}',HP = '{num3}' WHERE ADDR_ID = '{num1}'";
            cmd.ExecuteNonQuery();
            Console.WriteLine("수정 되었습니다.");
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Func func = new Func();
           
            while (true)
            {
                Console.WriteLine("1.테이블 생성 \r\n2.테이블 삽입\r\n3.테이블 조회\r\n4.테이블 수정");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    func.Create();
                }
                else if (input == "2")
                {
                    func.Insert();
                }
                else if (input == "3")
                {
                    func.Select();

                }
                else if(input == "4")
                {
                    func.Update();
                }

            }

        }
    }
}
