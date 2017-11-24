using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI;
using Lab2.UI.Buttons;
using Lab2.UI.Widgets;
using Lab2.UI.Activities;
using Lab2.UI.Layers;
using Lab2.UI.Exceptions;
namespace Lab2
{
    class Program
    {

        static void Separate()
        {
            Console.WriteLine("===========================================================================================");
        }
       
        static void Foo(object sender, MouseEventArgs args)
        {
            Console.WriteLine("Foo: sender {0}, args: {1}", sender != null ? sender : "null", args);
        }

        static void Bar(object sender, MouseEventArgs args)
        {
            Console.WriteLine("Bar: sender {0}, args: {1}", sender != null ? sender : "null", args);

        }
        static void testPushButton()
        {
            Separate();
            Console.WriteLine("                  Test PushButton class");
            Separate();
            UINode.UIRoot.Clear();
            Console.WriteLine("\n                Create new button and add it to root\n");
            PushButton b1 = new PushButton("Button caption", null, "b1");
            UINode.UIRoot.Add(b1);
            Console.WriteLine("\n                Click the button\n");
            b1.Click();

            Console.WriteLine("\n                Add action to the button and release it\n");
            b1.OnClick += Foo;
            b1.Release();
            b1.Click(null, new MouseEventArgs(10, 14, MouseButton.LEFT,KeyboardKey.LCTRL|KeyboardKey.RSHIFT));


            b1.OnRelease += Bar;
            b1.Release();

            Console.WriteLine("\n                Click the (Button)PushButton\n");
            ((Button)b1).Click();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }
        static void testLayer()
        {
            Separate();
            Console.WriteLine("                  Test Layer class");
            Separate();
            
            Console.WriteLine("\n                Create new layer and add it to root\n");
            Layer<Button> l1 = new Layer<Button>(Align.HORIZONTAL, new PushButton("b1"),new PushButton("b2"));
            UINode.UIRoot.Add(l1);
           

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void testExceptions()
        {
            Separate();
            Console.WriteLine("                      Test Exceptions");
            Separate();

            Console.WriteLine("\n                Create new node and don't add it to root\n");
            UINode node1 = new UINode(10, 20, 0, 4, "Metalic", "node1");

            //UINode.UIRoot.Add(node1);
            Console.WriteLine("\n                 Create new node and render it\n");
            try
            {
                UINode node2 = new UINode(null, "node2");
                Console.WriteLine("\n                 Add node to another node\n");

                node1.Add(node2);
                node1.Update();
            }catch(NodeNotAddedToRootException e)
            {
                Console.WriteLine(e);
                if (e.CurrRoot != null && e.CurrNode!=null)
                {
                    e.CurrRoot.Add(e.CurrNode);
                    e.CurrNode.Update();
                }
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void Main(string[] args)
        {
            testPushButton();
            testLayer();
            testExceptions();
            //testWidget();
            Console.ReadLine();
        }
    }
}
