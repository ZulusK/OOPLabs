using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Widgets
{
    class Widget : UINode
    {
        protected List<string> shapes;
        public void addShape(string shape)
        {
            shapes.Add(shape);
            Update();
        }
        public void addShape(params string[] shape)
        {
            foreach(var s in shape)
            {
                shapes.Add(s);
            }
            Update();
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("      widget~ draw widget: '{0}'", name);
            foreach (var s in shapes)
            {
                Console.WriteLine("       widget~ draw '{0}'", s);
            }
        }

        public void ClearArea()
        {
            shapes.Clear();
            Update();
        }
        public Widget(uint width=0, uint heigth=0, int left=0, int top=0,string style=null, string name=null, params string[] shapes):base(width,heigth,left, top,style,name)
        {
            this.shapes = new List<string>(shapes);
            Console.WriteLine("     widget~ created '{0}'", this.name);
        }
    }
}
