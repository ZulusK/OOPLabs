using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.UI.Input
{
    public class InputEventArgs
    {
        public string Text
        {
            get;
            private set;
        }
        public InputEventArgs(string text)
        {
            this.Text = text;
        }
        public override String ToString()
        {
            return String.Format("{0} ", Text);
        }
    }
}
