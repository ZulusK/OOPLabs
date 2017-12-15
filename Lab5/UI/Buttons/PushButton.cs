using Lab5.UI.Entities;
using Lab5.UI.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Buttons
{
    public class PushButton : Button, IReleasable
    {
        public bool IsReleased
        {
            get;
            protected set;
        }

        public event MouseEventHandler OnRelease;

        public void Release(MouseEventArgs args = null)
        {
            this.IsReleased = true;
            Console.WriteLine("....PushButton[{0}]: released", Name);
            if (OnRelease != null)
            {
                OnRelease(this, args != null ? args : new MouseEventArgs());
            }
        }
        public override void Click(MouseEventArgs args = null)
        {
            this.IsReleased = false;
            base.Click(args);
        }


        public PushButton(string text, string name = null, Rectangle frame = null, string css = null) : base(text, name, frame, css)
        {
            Console.WriteLine("....PushButton[{0}]: created", Name);
            this.IsReleased = true;
        }
        public override string ToString()
        {
            return String.Format("PushButton[{0}]: '{1}'", Name, Text);
        }
    }
}
