using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Containers
{
    public enum Align { VERTICAL, CENTER, HORIZONTAL, NONE };

    class Layer<T> : UINode where T : UINode
    {
        public Align Align
        {
            get;
            set;
        }
        public virtual void Add(T[] nodes)
        {
            this.Add(nodes.ToList());
        }
        public virtual void Add(List<T> nodes)
        {
            nodes.ForEach(child => base.AddChild(child));
        }
        public virtual bool AppendChild(T node)
        {
            return base.AddChild(node);
        }
        public override bool AddChild(UINode node)
        {
            throw new NotSupportedException("this method has been overrided");
        }
        public Layer(Align align = Align.NONE, params T[] nodes) : base(null,null, null)
        {
            this.Align = Align;
            Add(nodes);
            Console.WriteLine("....Layer[{0}]: created", Name);
        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("....Layer[{0}]: draw: align:{1}", Name, Align);
        }
    }
}
