using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI.Activities;


namespace Lab2.UI.Buttons
{
    abstract class Button : UINode, IClickable, IReleasable
    {
        public event MouseEventHandler OnClick;

        public override bool CanHaveChild()
        {
            return true;
        }
        public Action OnReleased { get; set; }

        public bool IsClicked
        {
            get;
            protected set;
        }
        public bool IsReleased
        {
            get;
            protected set;
        }

        public string Text
        {
            get
            {
                return ((Label)base.getChild("caption")).Text;
            }
            set
            {
                ((Label)base.getChild("caption")).Text = value;
            }
        }

        public virtual void Click(object sender = null, MouseEventArgs args = null)
        {
            if (!IsClicked)
            {
                this.IsClicked = true;
                this.IsReleased = false;
                Console.WriteLine("    button~ clicked '{0}'", this.name);
                Update();

                if (OnClick != null)
                {
                    OnClick(sender, args != null ? args : new MouseEventArgs());
                }
            }

        }
        public virtual void Release()
        {
            if (!IsReleased)
            {
                this.IsReleased = true;
                this.IsClicked = false;
                Console.WriteLine("    button~ released '{0}'", this.name);
                Update();
                if (OnReleased != null)
                {
                    OnReleased();
                }
            }

        }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("    button~ draw button: '{0}'", name);

        }
        protected Button(string text = null, string css = null, string name = null) : base(css, name)
        {
            Console.WriteLine("    button~ created '{0}'", this.name);
            this.IsClicked = false;
            this.IsReleased = true;
            Add(new Label(text != null ? text : "New button", this.CSS, "caption"));
        }
    }
}


