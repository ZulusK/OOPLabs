using Lab4.UI;
using Lab4.UI.Buttons;
using Lab4.UI.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Tests
{
    class TestButtons
    {
        static void TestCreate()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root1 = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());

            var button = new PushButton("click me");


            root1.AddChild(button);
            root1.Update();
        }
        static void Foo(object sender, MouseEventArgs args)
        {
            Console.WriteLine("Foo: {0}=>{1}", sender, args);
        }
        static void TestClick()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var button = new PushButton("click me");
            button.OnClick += (sender, args) =>
            {
                Console.WriteLine("Lambda: {0}=>{1}", sender, args);
            };
            button.OnClick += Foo;
            button.Click(new MouseEventArgs(1, 2, MouseButton.MIDDLE, KeyboardKey.LALT | KeyboardKey.LSHIFT));
        }
        static void TestRelease()
        {

        }
        public static void execute()
        {
            Console.WriteLine("#");
            Console.WriteLine(new StackFrame().GetMethod().DeclaringType);
            Console.WriteLine("#");
            TestCreate();
            TestClick();
            TestRelease();
        }
    }
}
