using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Node
    {
        static ulong id = 0;
        string name;
        bool isVisible = true;

        bool isEnable = true;
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
        public bool IsEnable
        {
            get
            {
                return this.isEnable;
            }
            set
            {
                if (this.isEnable != value)
                {
                    this.isEnable = value;
                    this.Update();
                }
            }
        }

        public virtual void Draw()
        {
            if (isVisible)
            {
                foreach (var kort in children)
                {
                    kort.Value.Draw();
                }
            }
        }
        //remove node from parent by reference
        public bool Remove(Node node)
        {
            return Remove(node.name);
        }
        //remove node from parent by it's name
        public bool Remove(string node)
        {
            if (children.Remove(node))
            {
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
        public bool Add(Node child)
        {
            if (!children.ContainsKey(child.name))
            {
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
        public Node(string name, Node parent)
        {
            this.name = name;
            this.parent = parent;
            Console.WriteLine("Node created {1}", this.name);
        }
        public Node() : this("#" + id, null)
        {

        }
        public override string ToString()
        {
            return String.Format("node {1}: parent {2}: childrens:{3}", name, parent != null ? parent.name : null, children.Count);
        }
    }
}