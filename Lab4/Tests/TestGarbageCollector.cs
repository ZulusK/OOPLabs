using Lab4.UI;
using Lab4.UI.Buttons;
using Lab4.UI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Tests
{
    class TestGarbageCollector
    {
        static void fillRoot()
        {
            
            //root.Update();
        }
        static void TestWithoutCallGC()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root = UINode.CreateRoot("New Root", new Rectangle(100, 100));
            for (int i = 0; i < 10; i++)
            {
                root.AddChild(new PushButton("button" + i));
            }
            root= UINode.CreateRoot("New Root 2", new Rectangle(100, 100));
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        static void TestWithCallGC()
        {
        }
        public static void execute()
        {
            Console.WriteLine("#");
            Console.WriteLine(new StackFrame().GetMethod().DeclaringType);
            Console.WriteLine("#");
            TestWithoutCallGC();
            TestWithCallGC();
        }
    }
}
