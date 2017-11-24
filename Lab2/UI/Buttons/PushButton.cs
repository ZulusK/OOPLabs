using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI.Activities;

namespace Lab2.UI.Buttons
{

    public class PushButton : Button, IReleasable
    {
        public event MouseEventHandler OnRelease;
        public bool IsReleased
        {
            get;
            protected set;
        }


        public virtual void Release(object sender = null, MouseEventArgs args = null)
        {
            if (!IsReleased)
            {
                this.IsReleased = true;
                Console.WriteLine("    button~ released '{0}'", this.name);
                Update();
                if (OnRelease != null)
                {
                    OnRelease(sender, args != null ? args : new MouseEventArgs());
                }
            }
        }

        public override void Click(object sender = null, MouseEventArgs args = null)
        {
            this.IsReleased = false;
            base.Click(sender, args);
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("     pushButton~ draw pushButton: '{0}'", name);
        }

        public PushButton(string caption = "New PushButton", string css = null, string name = null) : base(caption, css, name)
        {
            Console.WriteLine("     pushButton~ created '{0}'", this.name);
            this.IsReleased = true;
        }
    }
}
