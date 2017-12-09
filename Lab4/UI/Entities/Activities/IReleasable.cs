using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Entities.Activities
{
    public interface IReleasable
    {
        bool IsReleased
        {
            get;
        }

        event MouseEventHandler OnRelease;

        void Release(MouseEventArgs args = null);
    }
}
