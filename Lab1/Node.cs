using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Node
    {
        string name;
        bool isVisible=true;
        bool isEnable=true;
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
                    Parent.updateChild(oldName, name);
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
                    this.draw();
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
                    this.draw();
                }
            }
        }

        public virtual void Draw()
        {
            if (isVisible)
            {
                foreach (var kort in children)
                {
                    kort.Value.draw();
                }
            }
        }
        //remove node from parent by reference
        public bool Remove(Node node)
        {
            return remove(node.name);
        }
        //remove node from parent by it's name
        public bool Remove(string node)
        {
            if (children.Remove(node))
            {
                draw();
                return true;
            }
            else
            {
                return false;
            }
        }
        // set childs' name in children map
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
        
        // add child to node
        public bool Add(Node child)
        {
            if (!children.ContainsKey(child.name))
            {
                children[child.name] = child;
                child.Parent = this;
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
            
        }
        
    }
}