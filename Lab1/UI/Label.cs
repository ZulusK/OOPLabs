using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI
{
    class Label : UINode
    {
        protected string text;

        static Label(){
            Console.WriteLine("    label~ class loaded");
            canHaveChild = false;
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                Update();
            }
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("    label~ draw label '{0}': {1}", name, text);
        }
        public Label(string text = "", string css = "Default label css", string name = null) : base(name != null ? name : "label" + ID, css)
        {
            this.text = text;
            Console.WriteLine("    label~ created '{0}'",this.name);
        }
        
    }
}
