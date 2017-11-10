using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2.UI.Activities
{
    interface IClickable
    {
        bool IsClicked
        {
            get;
        }

        event MouseEventHandler OnClick;

        void Click(object sender = null, MouseEventArgs args = null);
    }
}
