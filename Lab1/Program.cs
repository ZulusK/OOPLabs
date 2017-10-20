using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.UI;
namespace Lab1
{
    class Program
    {
        //static void testNode()
        //{

        //    Console.WriteLine("====================================================");
        //    Console.WriteLine("                  Test Node class");
        //    Console.WriteLine("====================================================");
        //    UINode root = new UINode("root");
        //    UINode.Root.Add(root);

        //    UINode n0 = new UINode();
        //    UINode n1 = new UINode();
        //    UINode n2 = new UINode();
        //    UINode n3 = new UINode();
        //    Console.WriteLine("Add n0 to root");
        //    root.Add(n0);
        //    root.Add(n1);
        //    n0.Add(n2);
        //    n1.Add(n2);
        //    n1.Add(n3);
        //    n3.Add(n0);
        //    n3.Name = "node 3";

        //    Console.WriteLine("Draw all nodes");
        //    root.Draw();
        //    Console.WriteLine("Draw parent of n0");
        //    n0.Parent.Draw();
        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        //}
        static void testUINode()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("                  Test UINode class");
            Console.WriteLine("====================================================");
            //UINode.UIRoot.Clear();
            UINode node1 = new UINode(10, 20, 0, 4, "Metalic", "node1");
            UINode.UIRoot.Add(node1);
            
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void testLabel()
        {
            //Canvas.UIRoot.Clear();
            //Console.WriteLine("====================================================");
            //Console.WriteLine("                  Test Label class");
            //Console.WriteLine("====================================================");
            //Label label = new Label("1234567890");
            //Canvas.UIRoot.Add(label);
            //label.Update();
            //Console.WriteLine("Try to add new child to label, result: {0}", label.Add(new Label()));
            //Console.WriteLine("Try to remove  child from label, result: {0}", label.Remove(new Label()));
            //Console.WriteLine("Try to add new child to (Node) label, result: {0}", ((UINode)label).Add(new Label()));
            //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }
        static void Foo()
        {
            Console.WriteLine("Foo");
        }

        static void Bar()
        {
            Console.WriteLine("Bar");
        }
        //static void testPushButton()
        //{
        //    UINode.Root.Clear();
        //    Console.WriteLine("====================================================");
        //    Console.WriteLine("                  Test PushButton class");
        //    Console.WriteLine("====================================================");
        //    PushButton b1 = new PushButton("b1");
        //    UINode.Root.Add(b1);
        //    b1.Click();
        //    b1.OnClicked = Foo;
        //    b1.OnReleased = Bar;
        //    b1.Release();
        //    ((Button)b1).Click();
        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        //}
        //static void testRadioButton()
        //{
        //    UINode.Root.Clear();
        //    Console.WriteLine("====================================================");
        //    Console.WriteLine("                  Test RadioButton class");
        //    Console.WriteLine("====================================================");
        //    RadioButton b1 = new RadioButton("b1");
        //    UINode.Root.Add(b1);
        //    b1.Click();
        //    b1.OnClicked = Foo;
        //    b1.OnStateChange = Bar;
        //    b1.Release();

        //    ((Button)b1).Click();
        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        //}
        //static void testTextArea()
        //{
        //    UINode.Root.Clear();
        //    Console.WriteLine("====================================================");
        //    Console.WriteLine("                  Test TextArea class");
        //    Console.WriteLine("====================================================");
        //    TextArea t1 = new TextArea("0123456789012345678901234567890",3,5);
        //    UINode.Root.Add(t1);

        //    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        //}
        static void Main(string[] args)
        {
            //testNode();
            testUINode();
            testLabel();
            //testPushButton();
            //testRadioButton();
            //testTextArea();
            Console.ReadLine();
        }
    }
}
