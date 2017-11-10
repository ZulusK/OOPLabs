using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI.Buttons
{
    class PushButton:Button
    {
        public Action OnReleased { get; set; }
        public virtual void Release()
        {
            Update();
            if (OnReleased != null && state)
            {
                this.state = false;
                OnReleased();
            }
        }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("     pushButton~ draw pushButton: '{0}'", name);

        }
        public PushButton(string caption="New PushButton", Action onClicked = null, Action onReleased = null,string css=null,string name = null):base(caption,css,name, onClicked)
        {
            this.OnReleased = onReleased;
            Console.WriteLine("     pushButton~ created '{0}'", this.name);
        }
    }
}
