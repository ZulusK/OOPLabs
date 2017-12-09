using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Entities.Activities
{
    public interface IClickable
    {
        event MouseEventHandler OnClick;
        void Click(MouseEventArgs args = null);
    }
}
