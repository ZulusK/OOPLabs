using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    class Canvas : Node
    {
        public static string Font { get; set; }

        static Canvas()
        {
            Font = "Times New Roman";
            Console.WriteLine("Font loaded {0}", Font);
        }

        string style;
        int width = 0;
        int heigth = 0;
        int left = 0;
        int top = 0;

        public int Width
        {
            get => width;
            set
            {
                if (value >= 0)
                {
                    width = value;
                    Update();
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
                    Update();
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

        public int Left
        {
            get => left;
            set
            {
                left = value;
                Update();
            }
        }
        public int Top
        {
            get => top; set
            {
                top = value;
                Update();
            }
        }

        public override void Draw()
        {
            Console.WriteLine("!apply style '{0}' in frame [{1},{2}],[{3},{4}] to '{5}'", style, Left, Top, width, heigth, name);
            base.Draw();
        }
        public Canvas(int width = 0, int heigth = 0, int left = 0, int top = 0, string name = null) : base(name)
        {
            this.width = width >= 0 ? width : 0;
            this.heigth = heigth >= 0 ? heigth : 0;
            this.left = left;
            this.top = top;
        }

        public Canvas(string name) : this(0, 0, 0, 0, name) { }

        //copy canvas
        public Canvas(Canvas original) : this(original.width, original.heigth, original.left, original.top, original.name)
        {
        }
        
    }
}