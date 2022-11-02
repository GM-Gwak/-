using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = 3;
            int money = 20;
            int count = 4;
            long answer = 0;
            long sum = 0;
            for (int i = 1; i <= count; i++)
                if (price <= 2500 && price >= 1 && count <= 2500 && count >= 1)
                {
                    sum = sum + (price * i);
                }

            if (sum == money || sum <= money)
            {
                answer = 0;
            }
            else if (sum >= money)
            {
                answer = sum - money;

            }
            Console.WriteLine(answer);

        }
    }
}
