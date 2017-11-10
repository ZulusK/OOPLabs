using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI
{
     class UINode:Canvas
    {

        //static constructor to load and initialize static data
        //when class had been loaded

        static uint id;
        protected static uint ID { get => id++; }
        
        public virtual bool CanHaveChild() {
            return true;
        }
        static UINode uiRoot;
        protected UINode parent;
        protected Dictionary<string, UINode> children;
        protected string name;
        
        static UINode()
        {
            Console.WriteLine("   node~ class loaded");
            id = 0;
            uiRoot = new UINode("AppWindow", "Default Window theme", 800, 600);
            
        }
        public static UINode UIRoot { get => uiRoot; }
        public UINode Parent
        {
            get => parent;
        }
        public Dictionary<string, UINode> Children
        {
            get
            {
                if (CanHaveChild())
                {
                    return new Dictionary<string, UINode>(children);
                }
                else
                {
                    return new Dictionary<string, UINode>();
                }
            }
        }


        public virtual UINode getChild(string name)
        {
            return children[name];
        }


        public string Name
        {
            get => name;
        }
        
        public virtual bool Remove(UINode child)
        {
            return Remove(child.name);
        }
        public virtual bool Remove(string childName)
        {
            if (CanHaveChild() && children.ContainsKey(childName))
            {
                children[childName].parent = null;
                children.Remove(childName);
                Console.WriteLine("   node~ remove child '{0}' from '{1}'", childName, this.name);
                Update();
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual bool Add(UINode child)
        {
            if (child == this)
            {
                return false;
            }
            else
            {
                if (CanHaveChild() && !children.ContainsKey(child.name))
                {
                    if (child == parent)
                    {
                        child.children.Remove(this.name);
                        this.parent = null;
                    }
                    if (child.parent != null)
                    {
                        child.parent.children.Remove(child.name);
                    }
                    children[child.name] = child;
                    child.parent = this;
                    Console.WriteLine("   node~ add child '{0}' to '{1}'", child.name, name);
                    Update();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual void Clear()
        {
            if (CanHaveChild())
            {
                Console.WriteLine("   node~ clear '{0}'", name);
                children.Clear();
                Update();
            }
        }
        /// <summary>
        /// update all ui tree
        /// </summary>
        public override void Update()
        {
            Console.WriteLine("   node~ update '{0}'", name);
            if (this.parent != null)
            {
                //goto to top
                parent.Update();
            }
            else if (this.isRoot==true)
            {
                Render();
            }
            
        }

        protected override sealed void Render()
        {
            base.Render();
            if (CanHaveChild())
            {
                foreach (var k in children)
                {
                    k.Value.Render();
                }
            }
        }

        /// <summary>
        /// draw current node
        /// </summary>
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("   node~ draw {0}", name);
        }

        bool isRoot;

        public UINode(uint width, uint heigth, int left, int top, string css = null,string name = null) : base(width, heigth, left, top,css) { 
            this.name = name!=null?name: string.Format("{0}_{1}",this.GetType().Name, ID);
            this.parent = null;
            isRoot = false;
            if (CanHaveChild())
            {
                this.children = new Dictionary<string, UINode>();
                Console.WriteLine("   node~ create dictionary '{0}'",this.name);
            }
            Console.WriteLine("   node~ created '{0}'", this.name);
        }
        public UINode(string css = null,string name=null) : this(0,0,0,0,css,name)
        {

        }
        public override string ToString()
        {
            return this.GetType().Name +":"+ name;
        }

        private UINode(string name, string css,uint width, uint heigth):this(width,heigth,0,0,css,name)
        {
            this.isRoot = true;
            
        }
        public static UINode CreateRootNode(uint width, uint height, string style, string name)
        {
            return new UINode(name ,style, width, height);
        }
    }
}