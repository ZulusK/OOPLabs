using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Entities.Activities
{

    public enum MouseButton { LEFT, MIDDLE, RIGHT, NONE };
    [Flags]
    public enum KeyboardKey { LSHIFT = 1, LCTRL = 2, LALT = 4, SPACE = 8, RSHIFT = 16, RCTRL = 32, RALT = 64, NONE = 128 };

    public delegate void MouseEventHandler(object sender, MouseEventArgs args);
}
