using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class PushButton : Button
    {

        public override void Click()
        {
            Console.WriteLine("- pushButton '{0}' clicked", name);
            base.Click();
        }

        public override void Release()
        {
            Console.WriteLine("- pushButton '{0}' released", name);
            base.Release();
        }
        public override void Draw()
        {
            Console.WriteLine("+PushButton draw");
            base.Draw();
        }
        public PushButton(string text = "") : base(text)
        {
            Style = "Default Push button style";
        }

        public override string ToString()
        {
            return String.Format("PushButton:'{0}', state: '{1}',{2}", Text, state ? "clicked" : "released", base.ToString());
        }
    }
}
