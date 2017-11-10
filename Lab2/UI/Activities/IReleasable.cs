using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{
    interface IReleasable
    {
        bool IsReleased { get;}
        Action OnReleased
        {
            get;
            set;
        }

        void Release();
    }
}
