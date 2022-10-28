using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = 121;
            long answer = 0;

            double num = (Math.Sqrt(n));
            if(num%1 == 0)
            {
                answer = (long)((num + 1) * (num + 1));
            }
            else
            {
                answer = -1;
            }
            Console.WriteLine(answer);


        }
    }
}
