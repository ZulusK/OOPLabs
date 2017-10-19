using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Button : Canvas
    {
        public Action OnClicked { get; set; }
        public Action OnReleased { get; set; }

        protected bool state;
        public bool State
        {
            get => state;
        }

        public Label Text { get; set; }


        public virtual void Click()
        {
            if (OnClicked != null && !state)
            {
                this.state = true;
                OnClicked();
            }
            Update();
        }
        public virtual void Release()
        {
            if (OnReleased != null && state)
            {
                this.state = false;
                OnReleased();
            }
            Update();
        }


        protected Button(string text = "New button") : base()
        {
            this.state = false;
            OnClicked = null;
            OnReleased = null;
            Text = new Label(text, "description");
            base.Add(Text);
        }

        public override bool Add(Node node)
        {
            return false;
        }
        public override bool Remove(Node node)
        {
            return false;
        }
        public override bool Remove(string name)
        {
            return false;
        }
    }
}
