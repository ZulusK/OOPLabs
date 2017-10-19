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
            Console.WriteLine("====================================================");
        }

        static void Main(string[] args)
        {
            testNode();
            Console.ReadLine();

        }
    }
}
