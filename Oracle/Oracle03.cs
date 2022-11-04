using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleTest03
{
    class Student
    {
        private int id;
        private string name;
        private string num;
        //private Student st;
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Num { get;  set;  }

        public Student(int id, string name, string num)
        {
            ID = id;
            Name = name;
            Num = num;
        }    
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int id;
            string name;
            string num;

            List<Student> students = new List<Student>();
            Student st;



            while (true)
            {
                Console.WriteLine("1.데이터 삽입 \r\n2.데이터 삭제\r\n3.데이터 조회\r\n4.데이터 수정");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("ID를 입력하세요.");
                    id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("이름을 입력하세요.");
                    name = Console.ReadLine();
                    Console.WriteLine("번호를 입력하세요.");
                    num = Console.ReadLine();
                    st = new Student(id, name, num);
                    students.Add(st);
                    Console.WriteLine($"{"순번",-10} {"이름",-15} {"번호",-15}");
                    foreach (Student s in students)
                    {
                        Console.WriteLine($"{s.ID,-10} {s.Name,-10} {s.Num,-10}");
                    }
                    Console.WriteLine();
                }
               else if (input == "2")
                {
                    Console.WriteLine("삭제할 아이디를 입력 해주세요.");
                    int input2 = Int32.Parse(Console.ReadLine());
                    students.RemoveAt(input2 - 1);
                    Console.WriteLine();
                }
                
                else if (input == "3")
                {
                    Console.WriteLine($"{"순번",-10} {"이름",-15} {"번호",-15}");
                    foreach (Student s in students)
                    {
                        Console.WriteLine($"{s.ID,-10} {s.Name,-15} {s.Num,-15}");
                    }
                    Console.WriteLine();
                }

                else if(input == "4")
                {
                    Console.WriteLine("아이디를 입력하세요.");
                    int input3 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("수정할 이름을 입력하세요.");
                    name=Console.ReadLine();
                    students[input3 - 1].Name = name;
                    Console.WriteLine("수정할 번호을 입력하세요.");
                    num = Console.ReadLine();
                    students[input3 - 1].Num = num;
                    Console.WriteLine($"{"순번",-10} {"이름",-15} {"번호",-15}");
                    foreach (Student s in students)
                    {
                        Console.WriteLine($"{s.ID,-10} {s.Name,-15} {s.Num,-15}");
                    }
                    Console.WriteLine();

                }
            }    

        }
    }
}
