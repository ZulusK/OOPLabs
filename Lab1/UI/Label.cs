using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Label : Canvas
    {

        public string Text { get; set; }
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Label '{0}' drawed with font[{2}], \"{1}\" ", name, Text, Font);
        }
        public Label(string text = "", string name = null) : base(name != null ? name : "label" + ID)
        {
            this.Text = text;
        }

        public override bool Add(Node child)
        {
            return false;
        }
        public override bool Remove(Node node)
        {
            return false;
        }
        public override bool Remove(string nodeName)
        {
            return false;
        }
        public override string ToString()
        {
            return String.Format("Label:'{0}',{1}", Text, base.ToString());
        }
    }
}
