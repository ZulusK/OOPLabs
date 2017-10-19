using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void testNode()
        {

            Console.WriteLine("====================================================");
            Console.WriteLine("                  Test Node class");
            Console.WriteLine("====================================================");
            Node root = new Node("root");
            Node.Root.Add(root);

            Node n0 = new Node();
            Node n1 = new Node();
            Node n2 = new Node();
            Node n3 = new Node();
            Console.WriteLine("Add n0 to root");
            root.Add(n0);
            root.Add(n1);
            n0.Add(n2);
            n1.Add(n2);
            n1.Add(n3);
            n3.Add(n0);
            n3.Name = "node 3";

            Console.WriteLine("Draw all nodes");
            root.Draw();
            Console.WriteLine("Draw parent of n0");
            n0.Parent.Draw();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void testCanvas()
        {

            Console.WriteLine("====================================================");
            Console.WriteLine("                  Test Canvas class");
            Console.WriteLine("====================================================");
            Canvas root = new Canvas("root");
            Canvas c1 = new Canvas();

            Canvas c2 = new Canvas();
            Canvas c3 = new Canvas(10, -12, 3, -4);
            root.Add(c1);
            root.Add(c2);

            //add base class to child class
            c2.Add((Node)c3);
            Console.WriteLine("Draw all nodes");
            ((Node)root).Draw();

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
        static void testLabel()
        {

            Console.WriteLine("====================================================");
            Console.WriteLine("                  Test Label class");
            Console.WriteLine("====================================================");
            Label l1 = new Label("some label's text");
            l1.Draw();
            Console.WriteLine("Try to add new child to label, result: {0}", l1.Add(new Node()));
            Console.WriteLine("Try to remove  child from label, result: {0}", l1.Remove(new Node()));
            Console.WriteLine("Try to add new child to (Node) label, result: {0}", ((Node)l1).Add(new Node()));
        }
        static void Main(string[] args)
        {
            testNode();
            testCanvas();
            testLabel();
            Console.ReadLine();

        }
    }
}
