using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate int GetResult();

    class Target
    {
        public void Do(GetResult getResult)
        {
            Console.WriteLine(getResult());
        }
    }
    class Source
    {
        public int GetResult_1()
        {
            return 10;
        }
        public int GetResult_2()
        {
            return 500;
        }
        public void Test()
        {
            Target target = new Target();
            target.Do(new GetResult(this.GetResult_1));
            target.Do(new GetResult(this.GetResult_2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Source src =new Source();
            src.Test();
        }
    }
}
