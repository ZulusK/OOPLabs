﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI.Activities;


namespace Lab2.UI.Buttons
{
    public abstract class Button : UINode, IClickable
    {
        public event MouseEventHandler OnClick;

        public override bool CanHaveChild()
        {
            return false;
        }

        protected Label label;
        public string Text
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        public virtual void Click(object sender = null, MouseEventArgs args = null)
        {
            Console.WriteLine("    button~ clicked '{0}'", this.name);
            Update();

            if (OnClick != null)
            {
                OnClick(sender, args != null ? args : new MouseEventArgs());
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

            this.label=new Label(text != null ? text : "New button", this.CSS, "caption");
        }
    }
}


