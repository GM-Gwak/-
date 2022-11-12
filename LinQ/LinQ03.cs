using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ04_near
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random r = new Random();
            bool flag = false;
            int tmp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                flag = false;
                tmp = r.Next(1, 101);
                for(int j = 0; j <=i; j++)
                {
                    if(tmp == arr[j])
                    {
                        i--;
                        flag= true;
                        break;
                    }
                }
                if (flag == false)
                    arr[i] = tmp;
            }
            IEnumerable<int> arr2 = from i in arr
                                    where i >=75 && i<=95
                                            && i%5==0
                                    orderby i
                                    select i;
            foreach(int i in arr2)
            {
                Console.WriteLine(i);
            }
            
            
            

        }
    }
}
