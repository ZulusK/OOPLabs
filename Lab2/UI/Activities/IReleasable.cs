using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{
    public interface IReleasable
    {
        bool IsReleased
        {
            get;
        }

        event MouseEventHandler OnRelease;

        void Release(object sender = null, MouseEventArgs args = null);
    }
}
