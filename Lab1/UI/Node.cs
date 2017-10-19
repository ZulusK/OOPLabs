using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Node
    {
        static ulong id;
        static Node root;
        public static Node Root { get => root; }

        static string Environment { get; }

        static Node()
        {
            id = 0;
            Environment = System.DateTime.Today.ToLongDateString();
            root = new Node("#Root");
        }

        protected string name;
        bool isVisible = true;


        Node parent;
        Dictionary<string, Node> children;
        public Dictionary<string, Node> Children
        {
            get
            {
                return new Dictionary<string, Node>(children);
            }
        }

        public Node Parent
        {
            protected set
            {

                if (this.parent != null)
                {
                    parent.Remove(this);
                }
                this.parent = value;

            }
            get
            {
                return parent;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                string oldName = name;
                this.name = value;
                if (Parent != null)
                {
                    Parent.UpdateChild(oldName, name);
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                if (this.isVisible != value)
                {
                    this.isVisible = value;
                    this.Update();
                }
            }
        }

        public virtual void Draw()
        {
            if (isVisible && parent != null)
            {
                Console.WriteLine("+node '{0}' had been drawed, [{1}]", name, Environment);
                foreach (var kort in children)
                {
                    kort.Value.Draw();
                }
            }
        }
        //remove node from parent by reference
        public virtual bool Remove(Node node)
        {
            return Remove(node.name);
        }
        //remove node from parent by it's name
        public virtual bool Remove(string nodeName)
        {
            var node = children[nodeName];
            if (children.Remove(nodeName))
            {
                Console.WriteLine("Remove '{0}' from '{1}'", nodeName, name);
                node.parent = null;
                Update();
                return true;
            }
            else
            {
                return false;
            }
        }
        // set child's name in children map
        protected bool UpdateChild(string oldName, string newName)
        {
            if (children.ContainsKey(oldName))
            {
                Node value = children[oldName];
                children.Remove(oldName);
                children[newName] = value;
                return true;
            }
            else
            {
                return false;
            }

        }
        //update parent, or if it's is epsent, draw this node and draw it's children
        protected void Update()
        {
            if (parent != null)
            {
                parent.Update();
            }
            else
            {
                Draw();
            }
        }
        // add child to node
        public virtual bool Add(Node child)
        {
            if (child != parent && !children.ContainsKey(child.name))
            {
                Console.WriteLine("Add '{0}' to '{1}'", child.name, name);
                children[child.name] = child;
                child.Parent = this;
                Update();
                return true;
            }
            else
            {
                return false;
            }
        }
        //get child by name
        public Node Child(string name)
        {
            return children[name];
        }
        public Node(string name = null)
        {
            this.children = new Dictionary<string, Node>();
            this.name = name != null ? name : ("#" + id++);
            Console.WriteLine("$ '{0}' node created", this.name);
        }

        public override string ToString()
        {
            return String.Format("'{0}': parent '{1}': childrens:{2}", name, parent != null ? parent.name : null, children.Count);
        }

    }
}