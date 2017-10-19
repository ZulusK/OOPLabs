using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RadioButton : Button
    {

        bool selected;
        public Action OnStateChange { get; set; }
        public bool isSelected { get => selected; }

        public override void Click()
        {
            Console.WriteLine("- radioButton '{0}' clicked", name);
            selected = !selected;
            if (OnStateChange != null)
            {
                OnStateChange();
            }
            base.Click();
        }
        public override void Draw()
        {
            Console.WriteLine("+RadioButton draw");
            base.Draw();
        }
        public override void Release()
        {
            Console.WriteLine("- radioButton '{0}' released", name);
            base.Release();
        }
        public RadioButton(string text = "") : base(text)
        {
            Style = "Default Radio button style";
            selected = false;
        }
        public override string ToString()
        {
            return String.Format("RadioButton:'{0}', state: '{1}',{2}", Text, state, base.ToString());
        }
    }
}
