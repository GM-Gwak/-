using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest001
{
    internal class Program
    {
        static void threadFunc1()
        {
            char n1 = 'a';
            for(int i = 'A'; i <='Z'; i++)
            {
                Console.Write((char)(i) + " ");
                
            }
            Console.WriteLine();
            for (int i = 0; i <= 25; i++)
            {
                Console.Write(n1++ + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} : 프로그램 종료");
            Console.WriteLine();
        }
        static void threadFunc2()
        {
            for(int i = 1; i < 101; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} : 프로그램 종료");
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            Thread t = new Thread(threadFunc1);
            Thread t2 = new Thread(threadFunc2);
            t.Start();
            t2.Start();
            t.Join();
            t2.Join();
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} : 프로그램 종료");
            //Console.WriteLine("프로그램 종료");
            //threadFunc();
        }

        
    }
}
