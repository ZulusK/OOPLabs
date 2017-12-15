using Lab5.UI.Entities;
using Lab5.UI.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Buttons
{
    public abstract class Button : UINode, IClickable
    {
        public event MouseEventHandler OnClick;
        public override bool CanHaveChild()
        {
            return false;
        }
        public string Text
        {
            get;
            set;
        }
        public virtual void Click(MouseEventArgs args = null)
        {
            Console.WriteLine("...Button[{0}]: clicked", Name);
            if (OnClick != null)
            {
                OnClick(this, args != null ? args : new MouseEventArgs());
            }
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("...Button[{0}]: draw '{1}'", Name, Text);
        }

        public Button(string text, string name = null, Rectangle frame = null, string css = null) : base(name, frame, css)
        {
            Text = text;
            Console.WriteLine("...Button[{0}]: created", Name);
        }
        public override string ToString()
        {
            return String.Format("Button[{0}]: '{1}'", Name, Text);
        }
    }
}
