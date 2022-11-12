using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i]=i+1;
            }
            //SELECT [컬럼] FROM [테이블] WHERE[조건] ORDER BY [컬럼]
            var evenNumber = from   num in arr
                             where  num%3==0
                             select num;

            foreach(var i in evenNumber)
            {
                Console.Write(i +" ");
            }
            Console.WriteLine();
        }
    }
}
