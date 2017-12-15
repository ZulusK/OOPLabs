using Lab5.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab5.UI.Containers
{
    public class Form : UINode, IEnumerable<UINode>, IEnumerator<UINode>
    {
        protected int enumeratorPointer = -1;
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
            Console.WriteLine("....From[{0}]: draw ", Name);

        }
        UINode IEnumerator<UINode>.Current
        {
            get
            {
                var childrenValues = this.children.Values;
                return (enumeratorPointer < childrenValues.Count && enumeratorPointer >= 0) ? childrenValues.ElementAt(enumeratorPointer) : null;
            }
        }

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (enumeratorPointer < children.Values.Count - 1)
            {
                enumeratorPointer++;
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
            enumeratorPointer = -1;
        }
        public void Dispose()
        {
        }

        public Form(string name, Rectangle frame = null, string css = null) : base(name, frame, css)
        {
            Console.WriteLine("....Form[{0}]: created", Name);
        }
        public override string ToString()
        {
            return String.Format("From[{0}]: ", Name);
        }
        
    }
}
