using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI.Buttons
{
    abstract class Button : UINode
    {

        public override bool CanHaveChild()
        {
            return true;
        }
        public Action OnClicked { get; set; }
        
        protected bool state;
        public bool State
        {
            get => state;
        }
        public string Text {
            get {
                return ((Label)base.getChild("caption")).Text;
            }
            set{
                ((Label)base.getChild("caption")).Text = value;
            }
        }

        public virtual void Click()
        {
            Update();
            if (OnClicked != null && !state)
            {
                this.state = true;
                OnClicked();
            }
        }


        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine("    button~ draw button: '{0}'", name);
            
        }
        protected Button(string text = null,string css= null, string name = null, Action onClicked=null) : base(css,name)
        {
            Console.WriteLine("    button~ created '{0}'", this.name);
            this.state = false;
            this.OnClicked = onClicked;
            Add(new Label(text!=null?text:"New button", this.CSS,"caption"));
        }
    }
}


