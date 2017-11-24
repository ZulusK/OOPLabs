using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Exceptions
{
    public class NodeNotAddedToRootExceptionArgs
    {
        public UINode CurrNode
        {
            get;
        }
        public UINode CurrRoot
        {
            get;
        }

        public string Msg
        {
            get;
        }
        public NodeNotAddedToRootExceptionArgs(UINode currNode, UINode currRoot, string msg= "This node has been not added to root of Window System")
        {
            this.CurrNode = currNode;
            this.CurrRoot = CurrRoot;
            this.Msg = msg;
        }
    }
    public class NodeNotAddedToRootException :Exception
    {

        public NodeNotAddedToRootExceptionArgs Args
        {
            get;
        }
        public UINode CurrNode
        {
            get => Args.CurrNode;
        }
        public UINode CurrRoot
        {
            get => Args.CurrRoot;
        }
        public NodeNotAddedToRootException(NodeNotAddedToRootExceptionArgs args):base(args.Msg )
        {
            this.Args = args; 
        }
        
    }
}
