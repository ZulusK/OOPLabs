using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Entities
{
    public class CSSLoader
    {
        public void Apply(string css)
        {
            Console.WriteLine("{0}: apply {1}", this.GetType().Name, css);
        }
        public CSSLoader()
        {
            Console.WriteLine("{0}: created", this.GetType().Name);
        }
    }
}
