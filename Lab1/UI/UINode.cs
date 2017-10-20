using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI
{
     class UINode:Canvas
    {

        //static constructor to load and initialize static data
        //when class had been loaded

        static uint id;
        protected static uint ID { get => id++; }
        protected static bool canHaveChild;
        static UINode uiRoot;
        protected UINode parent;
        protected Dictionary<string, UINode> children;
        protected string name;


        static UINode()
        {
            Console.WriteLine("   node~ class loaded");
            id = 0;
            canHaveChild = true;
            uiRoot = new UINode(800, 600, 0, 0, "Default Window theme","AppWindow");
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
                if (canHaveChild)
                {
                    return new Dictionary<string, UINode>(children);
                }
                else
                {
                    return new Dictionary<string, UINode>();
                }
            }
        }

        public string Name
        {
            get => name;
        }
        public static bool CanHaveChild { get => canHaveChild; }
        public virtual bool Remove(UINode child)
        {
            return Remove(child.name);
        }
        public virtual bool Remove(string childName)
        {
            if (canHaveChild && children.ContainsKey(childName))
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
            if (canHaveChild &&  !children.ContainsKey(child.name))
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
        public virtual void Clear()
        {
            if (canHaveChild)
            {
                Console.WriteLine("   node~ clear '{0}'", name);
                children.Clear();
                Update();
            }
        }

        //update all ui tree
        public override void Update()
        {
            Console.WriteLine("   node~ update '{0}'", name);
            if (this.parent != null)
            {
                //goto to top
                parent.Update();
            }
            else if (this == uiRoot)
            {
                Render();
            }
        }

        protected override sealed void Render()
        {
            base.Render();
            if (canHaveChild)
            {
                foreach (var k in children)
                {
                    k.Value.Render();
                }
            }
        }
        //draw current node
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("   node~ draw {0}", name);
        }
        public UINode(uint width, uint heigth, int left, int top, string css = null,string name = null) : base(width, heigth, left, top,css) { 
            this.name = name!=null?name: "UINode" + ID;
            this.parent = null;
            if (canHaveChild)
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
    }
}