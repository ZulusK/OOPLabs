using Lab5.UI.Entities;
using Lab5.UI.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Buttons
{
    public class CheckButton: Button
    {
        public event Action<object, MouseEventArgs> OnClick;
        public bool IsChecked
        {
            get;
            set;
        }
        public override void Click( MouseEventArgs args = null)
        {
            this.IsChecked = !this.IsChecked;
            base.Click(args);
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("...CheckButton[{0}]: draw: '{1}' state:{1}", Name, Text,IsChecked ? "checked" : "unchecked");

        }
        public CheckButton(string text = null,bool isCecked=false, string name = null, Rectangle frame=null,string css=null) : base(text, name,frame, css)
        {
            IsChecked = isCecked;
            Console.WriteLine("...CheckButton[{0}]: created", Name, IsChecked ? "checked" : "unchecked");
        }
        public override string ToString()
        {
            return String.Format("CheckButton[{0}]: '{1}' state:{2}", Name, Text,IsChecked ? "checked" : "unchecked");
        }
    
}
}
