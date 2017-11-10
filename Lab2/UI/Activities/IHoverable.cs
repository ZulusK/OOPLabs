using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{
    interface IHoverable
    {
        bool IsHovered
        {
            get;
        }
        Action OnHover
        {
            set;
            get;
        }
        void Hover();
        void Unhover();
    }
}
