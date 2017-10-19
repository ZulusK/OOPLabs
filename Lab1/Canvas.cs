using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    class Canvas : Node
    {
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
            Console.WriteLine("!apply with style: '{1}' in frame [{2},{3}],[{4},{5}]", name, style, Left, Top, width, heigth);
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
        public Canvas(Canvas original) : this(original.width,original.heigth,original.left,original.top, original.name)
        {

        }

    }
}