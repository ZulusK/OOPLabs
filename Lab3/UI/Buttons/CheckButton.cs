using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI.Activities;

namespace Lab3.UI.Buttons
{
    public class CheckButton : Lab2.UI.Buttons.Button
    {
        public event Action<object, MouseEventArgs> OnClick;

        public bool State
        {
            get;
            set;
        }
        public override void Click(object sender = null, MouseEventArgs args = null)
        {
            this.State = !this.State;
            base.Click(sender, args);
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("     checkButton~ draw button: '{0}', state:{1}", name, State ? "checked" : "unchecked");

        }
        public CheckButton(string text = null, string name = null) : base(text, null, name)
        {
            Console.WriteLine("     checkButton~ created '{0}'", this.name);
        }
    }
}
