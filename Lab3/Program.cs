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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Lab3
{   
    static class Extention
    {
        public static bool isValid(this InputEventArgs input)
        {
            return !input.Text.StartsWith("$");
        }
    }
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

            var root = UINode.CreateRootNode(1000, 1000, "default style", "root");
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
            for (int i = 0; i < 3; i++)
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
            button.OnClick += (object sender, MouseEventArgs args) =>
             {
                 Console.WriteLine("Pushed {0}, {1}", counter++, args);
             };
            for (int i = 0; i < 3; i++)
            {
                button.Click(new MouseEventArgs(0, 0, MouseButton.LEFT, KeyboardKey.LALT | KeyboardKey.RALT | KeyboardKey.SPACE));
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
            input.Validator = (args) => { return args.isValid(); };
            input.onInput += (object sender, InputEventArgs args) => { Console.WriteLine("Input: {0}", args); };
            input.input(new InputEventArgs("test_1", KeyboardKey.LALT | KeyboardKey.RALT | KeyboardKey.SPACE));
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

            foreach (UINode node in form)
            {
                Console.WriteLine(node);
            }
        }
        static void SerializeBin(UINode root)
        {
            BinaryFormatter serializer = new BinaryFormatter();

            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            try
            {
                serializer.Serialize(fs, root);
                Console.WriteLine("Serialized");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        static void DeserializeBin()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            UINode node;
            using (FileStream fs = new FileStream("DataFile.dat", FileMode.Open))
            {
                node = (UINode)formatter.Deserialize(fs);
                Console.WriteLine("Deserialized");
            }
            node.Update();

        }
        static void SerializeXML(UINode root)
        {
            var dcs = new DataContractSerializer(typeof(UINode), new List<Type>(),64,true,true, null);
            
            using (FileStream fs = new FileStream("DataFile.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, root);
                Console.WriteLine("Serialized");
            }
        }
        static void DeserializeXML()
        {
            UINode root;
            var dcs = new DataContractSerializer(typeof(UINode));
            using (FileStream fs = new FileStream("DataFile.xml", FileMode.Open))
            {
                using (var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {

                    root = (UINode)dcs.ReadObject(reader);
                    Console.WriteLine("Deserialized");
                }
            }

            root.Update();
        }
        static void testSerialize()
        {
            Separate();
            Console.WriteLine("                      Test Serialize");
            Separate();
            var root = UINode.CreateRootNode(1000, 1000, "default style", "root");
            var subroot = new UINode("form");
            root.Add(subroot);
            subroot.Add(new UINode("1"));
            subroot.Add(new UINode("2"));
            Separate();
            Console.WriteLine("                      Start bin");
            Separate();
            root.Update();
            Separate();

            SerializeBin(root);
            DeserializeBin();
            Separate();
            Console.WriteLine("                      Start xml");
            Separate();
            SerializeXML(root);
            DeserializeXML();
        }

        static void Main(string[] args)
        {
            testAnonimous();
            testLambdaAction();
            testFunc();
            testForm();
            testSerialize();
            Console.ReadLine();
        }
    }
}
