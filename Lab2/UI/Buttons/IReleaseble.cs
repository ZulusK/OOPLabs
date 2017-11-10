using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Buttons
{
    interface IReleaseble
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
