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
        int width;
        int heigth;

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
                style = value;
                Update();
            }
        }
    }
}