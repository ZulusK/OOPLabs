using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.UI.Activities
{

    public class MouseEventArgs
    {
        public MouseButton PressedButton
        {
            get;
            protected set;
        }
        public KeyboardKey KeyModificators
        {
            get;
            protected set;
        }

        public int X
        {
            get;
            protected set;
        }
        public int Y
        {
            get;
            protected set;
        }

        public MouseEventArgs(int x, int y, MouseButton button,  KeyboardKey modificators)
        {
            X = x;
            Y = y;
            PressedButton = button;
            KeyModificators = modificators;           
        }
        public MouseEventArgs() : this(0, 0, MouseButton.NONE,KeyboardKey.NONE)
        {

        }

        public List<KeyboardKey> Keys
        {
            get
            {

                var allKeys = Enum.GetValues(typeof(KeyboardKey));
                var keys = new List<KeyboardKey>();
                if (KeyModificators.Equals(KeyboardKey.NONE))
                {
                    keys.Add(KeyboardKey.NONE);
                }
                else
                {
                    foreach (KeyboardKey key in allKeys)
                    {
                        if (KeyModificators.HasFlag(key))
                        {
                            keys.Add(key);
                        }
                    }
                }
                return keys;
            }
        }
        public override String ToString()
        {
            return String.Format("[{0},{1}], {2}, [{3}] ", X, Y, PressedButton.ToString(), String.Join(",", Keys.ToArray()));
        }
    }
}
