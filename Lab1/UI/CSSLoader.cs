using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI
{
    class CSSLoader
    {

        public CSSLoader()
        {
            Console.WriteLine("  css~ CSSLoader created");
        }
        public void apply(string css)
        {
            Console.WriteLine("  css~ theme applied: '{0}'", css);
        }
    }
}
