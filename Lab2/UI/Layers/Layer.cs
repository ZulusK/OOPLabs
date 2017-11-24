using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Layers
{
    public enum Align { VERTICAL, CENTER, HORIZONTAL, NONE };
    public class Layer<T> : UINode where T : UINode
    {
        public Align Align
        {
            get;
            set;
        }
        public virtual void Add(T[] nodes)
        {
            foreach (T item in nodes)
            {
                base.Add(item);
            }
        }
        public virtual bool Add(T node)
        {
            return base.Add(node);
        }
        public override bool Add(UINode node, bool update=false)
        {
            throw new NotSupportedException("this method has been overrided");
        }


        public Layer(Align align = Align.NONE, params T[] nodes) : base(null, null)
        {
            this.Align = Align;
            Add(nodes);
        }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("      layer~ draw layer: '{0}' /align: {1}", name, Align);

        }
    }
}
