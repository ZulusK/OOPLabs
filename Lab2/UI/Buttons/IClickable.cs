using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Buttons
{
    interface IClickable
    {
        bool IsClicked
        {
            get;
        }
        Action OnClicked
        {
            get;
            set;
        }

        void Click();


    }
}
