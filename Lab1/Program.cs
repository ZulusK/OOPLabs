using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.UI;
using Lab1.UI.Buttons;
using Lab1.UI.Widgets;
namespace Lab1
{
    class Program
    {

        static void Separate()
        {
            Console.WriteLine("===========================================================================================");
        }
        static void testUINode()
        {
            Separate();
            Console.WriteLine("                  Test UINode class");
            Separate();
            
            UINode node1 = new UINode(10, 20, 0, 4, "Metalic", "node1");
            Console.WriteLine("\n                Create new node and add it to root\n");
            UINode.UIRoot.Add(node1);
            Console.WriteLine("\n                 Create new node and render it\n");
            UINode node2 = new UINode(null, "node2");
            Console.WriteLine("\n                 Add node to another node\n");
            node1.Add(node2);
            Console.WriteLine("\n                 Add node to child\n");
            node2.Add(node1);
            Console.WriteLine("\n                 Add node to root\n");
            UINode.UIRoot.Add(node2);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void testLabel()
        {
            Separate();
            Console.WriteLine("                  Test Label class");
            Separate();
            UINode.UIRoot.Clear();
            Label label1 = new Label("1234","Label style","label1");
            Console.WriteLine("\n                Create new label and add it to root\n");
            UINode.UIRoot.Add(label1);
            Console.WriteLine("\n                Try to add child to label\n");
            Console.WriteLine("add node: {0}",label1.Add(new UINode()));
            Console.WriteLine("add label: {0}", label1.Add(new Label()));
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void Foo()
        {
            Console.WriteLine("Foo");
        }

        static void Bar()
        {
            Console.WriteLine("Bar");
        }
        static void testPushButton()
        {
            Separate();
                        Console.WriteLine("                  Test PushButton class");
            Separate();
            UINode.UIRoot.Clear();
            Console.WriteLine("\n                Create new button and add it to root\n");
            PushButton b1 = new PushButton("Button caption",null,null,null,"b1");
            UINode.UIRoot.Add(b1);
            Console.WriteLine("\n                Click the button\n");
            b1.Click();
            Console.WriteLine("\n                Add action to the button and release it\n");
            b1.OnClicked = Foo;
            b1.OnReleased = Bar;
            b1.Release();
            Console.WriteLine("\n                Click the (Button)PushButton\n");
            ((Button)b1).Click();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

        }
        
        static void testWidget()
        {
            Separate();
            Console.WriteLine("                  Test PushButton class");
            Separate();
            var root = UINode.CreateRootNode(1000, 600, null, "WINDOW");
            Console.WriteLine("\n                Create new widget and add it to root\n");
            Widget widget = new Widget(200,300,0,0,null,"w1","red circle","orange square","yellow triangle");
            root.Add(widget);
            Console.WriteLine("\n                Add new shape to widget\n");
            widget.addShape("green dot");
            
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        static void Main(string[] args)
        {
            testUINode();
            testLabel();
            testPushButton();
            testWidget();
            Console.ReadLine();
        }
    }
}
