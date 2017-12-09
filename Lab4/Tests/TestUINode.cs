using Lab4.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Tests
{
    class TestUINode
    {
        static void TestCreate()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");
            var node = new UINode();
            Console.WriteLine(node);
        }
        static void TestAddToRoot()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());
            var node = new UINode();
            var node1 = new UINode();

            root.AddChild(node);
            root.AddChild(node1);
            root.AddChild(node);

            Console.WriteLine("Contains: {0}", root.Contains(node));
        }

        static void TestRemoveFromRoot()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());
            var node = new UINode();
            var node1 = new UINode();

            root.AddChild(node);
            root.AddChild(node1);

            Console.WriteLine("Remove: {0}", root.RemoveChild(node));
            Console.WriteLine("Contains: {0}", root.Contains(node));
            Console.WriteLine("Remove again: {0}", root.RemoveChild(node));
        }
        static void TestUpdate()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());
            var node = new UINode();
            var node1 = new UINode();
            var node2 = new UINode();

            root.AddChild(node);
            root.AddChild(node1);
            node1.AddChild(node2);
            node2.Update();
        }
        static void TestSetParent()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root1 = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());
            var root2 = UINode.CreateRoot("TestWindow2", new UI.Entities.Rectangle());

            var node = new UINode();
            var node1 = new UINode();
            var node2 = new UINode();

            root1.AddChild(node);
            root1.AddChild(node1);

            node1.AddChild(node2);

            root2.AddChild(node1);
            node2.Update();
            Console.WriteLine("Root 1 contains: {0}", root1.Contains(node1));
            Console.WriteLine("Root 2 contains: {0}", root2.Contains(node1));
        }
        static void TestNameConflicts()
        {
            Console.WriteLine("-");
            Console.WriteLine(new StackFrame().GetMethod().Name);
            Console.WriteLine("-");

            var root1 = UINode.CreateRoot("TestWindow", new UI.Entities.Rectangle());

            var node = new UINode("n1");
            var node1 = new UINode("n1");
            var node2 = new UINode("n2");


            root1.AddChild(node);
            root1.AddChild(node1);
            root1.AddChild(node2);


            Console.WriteLine("Nodes 'n1': {0}", String.Join(", ", root1["n1"]));
            Console.WriteLine("Nodes 'n2': {0}", String.Join(", ", root1["n2"]));
        }
        public static void execute()
        {
            Console.WriteLine("#");
            Console.WriteLine(new StackFrame().GetMethod().DeclaringType);
            Console.WriteLine("#");
            TestCreate();
            TestAddToRoot();
            TestRemoveFromRoot();
            TestUpdate();
            TestSetParent();
            TestNameConflicts();
        }
    }
}
