using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Exceptions
{
    class ChildIsRootException : Exception
    {
        public UINode Child
        {
            get;
            protected set;
        }
        public UINode Sender
        {
            get;
            protected set;
        }
        public string Message
        {
            get;
            protected set;
        }

        public ChildIsRootException(string message, UINode sender, UINode child)
        {
            Child = child;
            Sender = sender;
            Message = message;
        }
        public override string ToString()
        {
            return String.Format("{0}, sender: {1}, child: {2}", Message, Sender, Child);
        }
    }
}
