using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 2, 1, 4, 5 };

            //1. 메서드 구문
            IEnumerable<int> methodSyntax =
                numbers.Where(n => n % 2 == 1).OrderBy(n=>n);

            foreach(int i in methodSyntax)
            {
                Console.WriteLine(i);
            }

            //2.linq 구문
            IEnumerable<int> querySyntax =
                from num in numbers
                where num % 2 == 1
                orderby num
                select num;

            foreach(var n in methodSyntax)
                Console.WriteLine(n);
        }
    }
}
