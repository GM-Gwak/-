using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //확장 메소드 
            //SUM() 합
            //Count() 컬렉션 요소의 개수
            /*Average() 평균
             *Max() 최대값
             *Min() 최소값
             *
             */
            int[] numbers = {1,2,3};
            int sum =numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());

        }
    }
}
