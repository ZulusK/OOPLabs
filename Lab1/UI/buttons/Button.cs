using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI.Button
{
    abstract class Button : Canvas
    {
        //public Action OnClicked { get; set; }
        //public Action OnReleased { get; set; }
        //protected bool state;
        //public bool State
        //{
        //    get => state;
        //}
        //public Label Text { get; set; }
        //public virtual void Click()
        //{
        //    Update();

        //    if (OnClicked != null && !state)
        //    {
        //        this.state = true;
        //        OnClicked();
        //    }
        //}
        //public virtual void Release()
        //{
        //    Update();

        //    if (OnReleased != null && state)
        //    {
        //        this.state = false;
        //        OnReleased();
        //    }
        //}
        //protected Button(string text = "New button",string name=null) : base(name!=null?name:"button"+ID)
        //{
        //    this.state = false;
        //    OnClicked = null;
        //    OnReleased = null;
        //    Text = new Label(text, "description");
        //    base.Add(Text);
        //}
        //public override bool Add(UINode node)
        //{
        //    return false;
        //}
        //public override bool Remove(UINode node)
        //{
        //    return false;
        //}
        //public override bool Remove(string name)
        //{
        //    return false;
        //}
    }
}
