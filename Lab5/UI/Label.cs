using Lab5.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI
{
   public class Label : UINode
    {
        public override bool CanHaveChild()
        {
            return false;
        }

        public string Text
        {
            get;
            set;
        }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine(String.Format("...Label['{0}']: draw '{1}'", Name, Text));
        }


        public Label(string text = null, string name = null, Rectangle frame = null, string css = null) : base(name, frame, css)
        {
            Text = text;
            Console.WriteLine("...Label[{0}]: created", Name);
        }
        public override string ToString()
        {
            return String.Format("Label[{0}]: '{1}'", Name, Text);
        }
    }
}
