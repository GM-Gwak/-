using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace AsynDelegate
{
    class Calculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public int Minus(int num1, int num2)
        {
            return num1 - num2;
        }
        public int Multiple(int num1, int num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

    }

    internal class Program
    {
        static void Main(string[] args)

        {

            Calculator cal = new Calculator();
            Func<int, int, int> work1 = cal.Add;
            Func<int, int, int> work2 = cal.Minus;
            Func<int, int, int> work3 = cal.Multiple;
            Func<double, double, double> work4 = cal.Divide;





            IAsyncResult async1 = work1.BeginInvoke(10, 20, null, null);
            IAsyncResult async2 = work2.BeginInvoke(10, 20, null, null);
            IAsyncResult async3 = work3.BeginInvoke(10, 20, null, null);
            IAsyncResult async4 = work4.BeginInvoke(10, 20, null, null);


            int result1 = work1.EndInvoke(async1);
            int result2 = work2.EndInvoke(async2);
            int result3 = work3.EndInvoke(async3);
            double result4 = work4.EndInvoke(async4);



            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);

        }

    }

}

