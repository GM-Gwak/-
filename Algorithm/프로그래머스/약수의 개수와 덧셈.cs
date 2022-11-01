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
            int left = 24;
            int right = 27;
            int cnt = 0;
            int answer = 0;
            for(int i = left; i <= right; i++)
            {
                for(int j = 1; j <= left; j++)
                {
                    if (left % j == 0)
                    {
                        cnt++;
                    }
                    
                }
                if(cnt%2 == 0)
                {
                    answer += left;
                    cnt = 0;
                    left++;
                }
                else
                {
                    answer -= left;
                    cnt = 0;
                    left++;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
left부터 right까지 약수의 개수가 짝수이면 left를 더하고 홀수이면 다
