using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.UI.Entities.Activities
{
    public class InputEventArgs
    {
        public string Text
        {
            get;
            protected set;
        }
        public KeyboardKey KeyModificators
        {
            get;
            protected set;
        }
        public InputEventArgs(string text, KeyboardKey modificators = 0)
        {
            this.Text = text;
            this.KeyModificators = modificators;
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
            return String.Format("InputEventArgs: [{0}, [{1}] ", Text, String.Join(",", UsedKeys.ToArray()));
        }
    }
}
