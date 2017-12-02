using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI
{
    [DataContract]
    [Serializable]
    public class CSSLoader
    {

        public CSSLoader()
        {
            Console.WriteLine("css~ CSSLoader created");
        }
        public void apply(string css)
        {
            Console.WriteLine("css~ theme applied: '{0}'", css);
        }
    }
}
