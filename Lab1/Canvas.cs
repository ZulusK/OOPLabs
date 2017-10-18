using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    class Canvas : Node
    {
        List<string> content;
        string style;
        int width = 0;
        int heigth = 0;

        public int Width
        {
            get => width;
            set
            {
                if (value >= 0)
                {
                    width = value;
                }
            }
        }
        public int Heigth
        {
            get => heigth;
            set
            {
                if (value >= 0)
                {
                    heigth = value;
                }
            }
        }
        public string Style
        {
            get => style;
            set
            {
                style = value != null ? value : "{}";
                Update();
            }
        }
        public override void Draw()
        {
            base.Draw();
            foreach (var element in content)
            {
                Console.WriteLine(element);
            }
        }

        public Canvas(int width = 0, int heigth = 0, string name = null, Node parent = null) : base(name, parent)
        {
            this.Width = width;
            this.Heigth = heigth;
            content = new List<string>();
        }

        public Canvas(string name, Node parent) : this(0, 0, name, parent) { }

    }
}