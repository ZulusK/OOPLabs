using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Buttons
{

    class PushButton : Button, IHoverable
    {
        public bool IsHovered
        {
            get;
            protected set;
        }

        public Action OnHover { get; set; }

        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("     pushButton~ draw pushButton: '{0}'", name);
        }

        public void Hover()
        {
            if (!IsHovered)
            {
                IsHovered = true;
            }
            Update();

            if (OnHover != null)
            {
                OnHover();
            }
        }

        public void Unhover()
        {
            if (!IsHovered)
            {
                IsHovered = true;
            }
        }

        public PushButton(string caption = "New PushButton", Action onClicked = null, string css = null, string name = null) : base(caption, css, name, onClicked)
        {
            Console.WriteLine("     pushButton~ created '{0}'", this.name);
            this.IsHovered = false;
        }
    }
}
