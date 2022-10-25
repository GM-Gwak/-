using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNode
{
    internal class Program
    {
        delegate double GetAreaPointer(int r);

        static double Result(int r) => r * r * 3.14;  

        static void Main(string[] args)
        {
            GetAreaPointer g = new GetAreaPointer(Result);
            Console.WriteLine(g.Invoke(10));
        }
    }
}
