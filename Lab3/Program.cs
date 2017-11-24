using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI;
using Lab2.UI.Buttons;
using Lab2.UI.Activities;
using Lab3.UI.Buttons;
using Lab3.UI.Input;
using Lab3.UI;

namespace Lab3
{
    class Program
    {
        static void Separate()
        {
            Console.WriteLine("===========================================================================================");
        }
        static void testAnonimous()
        {
            Separate();
            Console.WriteLine("                      Test Anonimous methods");
            Separate();

            var root=UINode.CreateRootNode(1000, 1000,"default style", "root");
            var button = new PushButton("pushButton1");
            root.Add(button);
            var counter = 0;
            button.OnClick += delegate (object sender, MouseEventArgs args)
              {
                  Console.WriteLine("Pushed {0}", counter++);
              };
            button.OnRelease += delegate (object sender, MouseEventArgs args)
            {
                Console.WriteLine("Released {0}", counter++);
            };
            for(int i=0; i<3; i++)
            {
                button.Click();
                button.Release();
            }
        }

        static void testLambdaAction()
        {
            Separate();
            Console.WriteLine("                      Test Lambda conditions");
            Separate();

            var root = UINode.CreateRootNode(1000, 1000, "default style", "root");
            var button = new CheckButton("checkButton1");
            root.Add(button);
            var counter = 0;
            button.OnClick +=(object sender, MouseEventArgs args)=>
            {
                Console.WriteLine("Pushed {0}", counter++);
            };
            for (int i = 0; i < 3; i++)
            {
                button.Click();
            }
        }

        static void testFunc()
        {
            Separate();
            Console.WriteLine("                      Test Func conditions");
            Separate();

            var root = UINode.CreateRootNode(1000, 1000, "default style", "root");
            var input = new TextInput("input");
            root.Add(input);
            input.Validator = (args) => { return args.Text[0] != '$'; };
            input.onInput += (object sender, InputEventArgs args) => { Console.WriteLine("Input: {0}",args); };
            input.input(new InputEventArgs("test_1"));
            input.input(new InputEventArgs("$test_2"));
        }

        static void testForm()
        {
            Separate();
            Console.WriteLine("                      Test From");
            Separate();
            var root = UINode.CreateRootNode(1000, 1000, "default style", "root");
            var form = new Form("form");
            root.Add(form);
            form.Add(new CheckButton());
            form.Add(new TextInput());
            form.Add(new TextInput());
            form.Add(new TextInput());
            form.Add(new CheckButton());

            foreach(UINode node in form)
            {
                Console.WriteLine(node);
            }
        }

        static void Main(string[] args)
        {
            testAnonimous();
            testLambdaAction();
            testFunc();
            testForm();
            Console.ReadLine();
        }
    }
}
