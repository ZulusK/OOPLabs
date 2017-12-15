using Lab5.UI.Entities;
using Lab5.UI.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Inputs
{
    public class TextInput : Label
    {
        public event Action<object, InputEventArgs> OnInput;
        public Func<InputEventArgs, bool> Validator;
        public void Input(InputEventArgs args)
        {
            if (Validator != null && Validator(args))
            {
                this.Text = args.Text;
                OnInput(this, args);
            }
        }
        public TextInput(string name = null, Rectangle frame = null, string css = null) : base("", name, frame, css)
        {
            Console.WriteLine(".....InputText[{0}]: created", Name);
        }
        public override string ToString()
        {
            return String.Format("InputText[{0}]: text:'{1}'", Name, Text);
        }
    }
}
