using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{
    enum MouseButton { LEFT, MIDDLE, RIGHT, NONE };
    enum KeyboardKey { LSHIFT, LCTRL, LALT, SPACE, RSHIFT, RCTRL, RALT };

    delegate void MouseEventHandler(object sender, MouseEventArgs args);
}
