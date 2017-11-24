using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI;
using Lab3.UI.Input;

namespace Lab3.UI
{

    public class Form : UINode, IEnumerable<UINode>, IEnumerator<UINode>
    {
        protected int index = -1;
        public virtual bool Add(string name, UINode node)
        {
            if (node != null && node != this)
            {
                this.children[name] = node;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<UINode> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("      form~ draw form: '{0}' ", name);

        }

        UINode IEnumerator<UINode>.Current
        {
            get
            {
                var values = this.children.Values;                
                return (index<values.Count && index>=0)?values.ElementAt(index):null;
            }
        }

        public object Current
        {
            get
            {
                var values = this.children.Values;
                return (index < values.Count && index >= 0) ? values.ElementAt(index) : null;
            }
        }

        public bool MoveNext()
        {
            if (index < children.Values.Count-1)
            {
                index++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
        }

        public UINode this[string name]
        {
            get
            {
                return this.getChild(name);
            }
            set
            {
                this.Add(name, value);
            }
        }

        public Form(string name) : base(null, name)
        {
        }
    }
}
