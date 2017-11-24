using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI
{
    public class Label : UINode
    {
        
        protected string text;
        public override bool CanHaveChild()
        {
            return false;
        }
        static Label(){
            Console.WriteLine("    label~ class loaded");
            
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
        public Label(string text = "", string css = null,string name = null) : this(0,0,0,0,text,css,name)
        {
            
        }
        public Label(uint width, uint heigth, int left, int top,string text = "", string css = null, string name = null) : base(width, heigth, left,top,css, name)
        {
            this.text = text;
            Console.WriteLine("    label~ created '{0}'", this.name);
        }
    }
}
