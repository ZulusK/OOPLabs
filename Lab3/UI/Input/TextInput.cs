using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI.Input
{
    public class TextInput:Lab2.UI.Label
    {
        public event Action<object, InputEventArgs> onInput;
        public Func<InputEventArgs,bool> Validator
        {
            get;
            set;
        }

        public void input(InputEventArgs args)
        {
            if(Validator!=null && Validator(args))
            {
                this.text = args.Text;
                onInput(this,args);
            }
        }

        
        

        public TextInput(string name=null):base(null,null,name)
        {
            Console.WriteLine("     inputText~ created '{0}'", this.name);
        }
    }
}
