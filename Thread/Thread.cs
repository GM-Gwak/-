using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTes003
{
    internal class Program
    {
        static void threadFunc()
        {
            Console.WriteLine("5초 후에 프로그램 종료");
            Thread.Sleep(10000);
            Console.WriteLine("스레드 종료");
        }
        static void Main(string[] args)
        {
            
            Thread t = new Thread(threadFunc);
            //t.IsBackground = true;
            t.Start();
            t.Join();
            
            Console.WriteLine("메인 스레드 종료");
        }
    }
}
