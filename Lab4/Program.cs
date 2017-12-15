using Lab4.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {

        static void Main(string[] args)
        {
            
            TestGarbageCollector.execute();

            //TestGarbageCollector.execute();
            //TestGarbageCollector.execute();
            //TestGarbageCollector.execute();
            TestUINode.execute();
            TestLabel.execute();
            TestButtons.execute();
            Console.ReadKey();
        }
    }
}
