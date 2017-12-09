using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Lab4.UI.Entities;
using System.Diagnostics;
using Lab4.UI.Exceptions;

namespace Lab4.UI
{
    [Serializable]
    [DataContract]
    public class UINode : Canvas, IComparable
    {
        [DataMember]
        protected static ObjectID ObjectIDGenerator { get; } = new ObjectID();


        [DataMember]
        public static UINode Window
        {
            get;
            private set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }
        [DataMember]
        public uint ID
        {
            get;
            private set;
        }
        [DataMember]
        UINode parent;
        public UINode Parent
        {
            get => parent;
            protected set
            {
                if (this.parent != null)
                {
                    parent.RemoveChildByID(this.ID);
                }
                this.parent = value;
            }
        }
        public bool IsRoot
        {
            get;
            private set;
        }
        [DataMember]
        protected Dictionary<uint, UINode> children;

        public Dictionary<uint, UINode> Children
        {
            get => new Dictionary<uint, UINode>(children);
            protected set => children = value;
        }

        static UINode()
        {
            Window = CreateRoot("MainWindow", new Rectangle(800, 600));
        }
        protected string NextUniqName
        {
            get => String.Format("{0}{1}", this.GetType().Name, ObjectIDGenerator.nextID);
        }

        public virtual bool CanHaveChild()
        {
            return true;
        }
        private UINode(string name, Rectangle frame, string css, bool isRoot) : base(frame, css)
        {
            this.Name = name != null ? name : NextUniqName;
            this.IsRoot = isRoot;
            this.children = CanHaveChild() ? new Dictionary<uint, UINode>() : null;
            this.ID = ObjectIDGenerator.nextID;
            Console.WriteLine("..UINode[{0}]: created", Name);
        }
        public static UINode CreateRoot(string name, Rectangle frame, string css = null)
        {
            return new UINode(name, frame, css, true);
        }

        public UINode(string name, Rectangle frame, string css) : this(name, frame, css, false)
        {

        }
        public UINode(string name) : this(name, new Rectangle(), null)
        {

        }
        public UINode() : this(null, new Rectangle(), null)
        {

        }

        public virtual List<UINode> this[string name]
        {
            get => getChildByName(name);
        }
        public virtual UINode this[uint id]
        {
            get => getChildByID(id);
        }

        public virtual List<UINode> getChildByName(string name)
        {
            if (name == null) throw new NullReferenceException("'name' should be a name of child node");
            return new List<UINode>(
                this.children
                    .Values
                    .Where(child => child.Name.Equals(name))
                    .ToList());
        }
        public virtual UINode getChildByID(uint id)
        {
            return children[id];
        }
        protected virtual void AppendChild(UINode child)
        {
            if (!CanHaveChild()) return;
            child.Parent = this;
            this.children[child.ID] = child;
        }

        protected virtual bool RemoveChildByID(uint id)
        {
            if (!CanHaveChild()) return false;
            var child = children[id];
            if (children.Remove(id))
            {
                child.parent = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool RemoveChild(UINode child)
        {
            if (!CanHaveChild()) return false;
            if (child == null) throw new NullReferenceException("'child' must be an object");
            if (Contains(child) && children[child.ID] == child)
            {
                return RemoveChildByID(child.ID);
            }
            else
            {
                return false;
            }
        }
        public virtual bool Contains(UINode child)
        {
            if (!CanHaveChild()) return false;
            if (child == null) throw new NullReferenceException("'child' must be an object");
            return child.Parent == this;
        }
        public virtual bool Containt(uint id)
        {
            return children[id] != null;
        }

        public virtual bool AddChild(UINode child)
        {
            if (!CanHaveChild()) return false;
            if (child == null) throw new NullReferenceException("'child' must be an object");
            if (child.IsRoot) throw new ChildIsRootException("'child' is a root node, it cannot be a child", this, child);
            if (!this.Contains(child))
            {
                this.AppendChild(child);
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Clear()
        {
            if (!CanHaveChild()) return;
            this.children.ToList()
                .ForEach(pair => this.RemoveChildByID(pair.Value.ID));
        }
        protected sealed override void Render()
        {
            base.Render();
            if (CanHaveChild())
            {
                children.Values.ToList()
                    .ForEach(child => child.Render());
            }
        }
        protected override void Draw()
        {
            Console.WriteLine(String.Format("..NodeUI: ('{0}':{1})", Name, ID));
        }

        public override void Update()
        {
            if (this.Parent != null)
            {
                parent.Update();
            }
            else if (this.IsRoot)
            {
                Render();
            }

        }
        public override string ToString()
        {
            return String.Format("NodeUI: ('{0}':{1})", Name, ID);
        }
        public virtual int CompareTo(object obj)
        {
            if (obj == null) return 1;
            UINode nobj = obj as UINode;
            return this.ID.CompareTo(nobj.ID);
        }
    }
}
