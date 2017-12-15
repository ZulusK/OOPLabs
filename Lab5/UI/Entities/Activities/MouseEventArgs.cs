using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.UI.Entities.Activities
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

        public MouseEventArgs(int x, int y, MouseButton pressedButton, KeyboardKey keyModificators)
        {
            PressedButton = pressedButton;
            KeyModificators = keyModificators;
            X = x;
            Y = y;
        }

        public MouseEventArgs() : this(0, 0, MouseButton.NONE, KeyboardKey.NONE)
        {
        }
        public List<KeyboardKey> UsedKeys
        {
            get
            {
                var allDeclaredKeys = Enum.GetValues(typeof(KeyboardKey));
                var usedKeys = new List<KeyboardKey>();
                if (KeyModificators.Equals(KeyboardKey.NONE))
                {
                    usedKeys.Add(KeyboardKey.NONE);
                }
                else
                {
                    foreach (KeyboardKey key in allDeclaredKeys)
                    {
                        if (KeyModificators.HasFlag(key))
                        {
                            usedKeys.Add(key);
                        }
                    }
                }
                return usedKeys;
            }
        }
        public override String ToString()
        {
            return String.Format("MouseEventArgs: [{0},{1}], {2}, [{3}] ", X, Y, PressedButton.ToString(), String.Join(",", UsedKeys.ToArray()));
        }
    }
}
