using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.UI.Activities;
namespace Lab3.UI.Input
{

    public class InputEventArgs
    {
        public string Text
        {
            get;
            private set;
        }
        public KeyboardKey Modificators
        {
            get;
            set;
        }
        public InputEventArgs(string text, KeyboardKey modificators=0)
        {
            this.Text = text;
            this.Modificators = modificators;
        }

        public List<KeyboardKey> Keys
        {
            get
            {
                
                var allKeys = Enum.GetValues(typeof(KeyboardKey));
                var keys = new List<KeyboardKey>();
                if (Modificators.Equals(KeyboardKey.NONE))
                {
                    keys.Add(KeyboardKey.NONE);
                }
                else
                {
                    foreach (KeyboardKey key in allKeys)
                    {
                        if (Modificators.HasFlag(key))
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
            return String.Format("{0}, modificators: {1}", Text, string.Join(", ",Keys.ToArray()));
        }
    }
}
