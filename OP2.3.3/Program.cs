using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP2._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] instance = { "Sonia", "Kyril", "Oleg", "Andrii", "Dima" };
            string result = null;
            instance.Aggregate(result,(x,y)=>result+=y.First());
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
