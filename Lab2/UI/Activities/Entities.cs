using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{
    public   enum MouseButton { LEFT, MIDDLE, RIGHT, NONE };
    public enum KeyboardKey { LSHIFT, LCTRL, LALT, SPACE, RSHIFT, RCTRL, RALT };

    public delegate void MouseEventHandler(object sender, MouseEventArgs args);
}
