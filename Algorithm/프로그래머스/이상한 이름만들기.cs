using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string s = "try hello world";
            string answer = "";
            int cnt = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i]==' ')
                {
                    answer += s[i];
                    cnt = 0;
                }
                else if (cnt % 2 == 0)
                {
                    answer += char.ToUpper(s[i]);
                    
                    cnt++;
                }
                else if (cnt % 2 == 1)
                {
                    answer += char.ToLower(s[i]);
                    cnt++;
                }

            }
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }
            
        }
    }
}
