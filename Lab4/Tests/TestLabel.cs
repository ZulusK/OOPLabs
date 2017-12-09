using Lab4.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Tests
{
    class TestLabel
    {
        static void TestCreate()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root1 = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());
            var label = new Label("label text");


            root1.AddChild(label);
            root1.Update();
        }
        public static void execute()
        {
            Console.WriteLine("#");
            Console.WriteLine(new StackFrame().GetMethod().DeclaringType);
            Console.WriteLine("#");
            TestCreate();
        }
    }
}
