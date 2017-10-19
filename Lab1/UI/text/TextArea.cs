using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class TextArea : ScrollFrame
    {
        protected string text = "";
        public string Text
        {
            get => text;
            set
            {
                maxPointer = (uint)value.Length;
                text = value;
                Pointer = 0;
            }
        }
        public string WindowedText
        {
            get
            {
                uint start;
                uint len;
                base.Window(out start, out len);
                return Text.Substring((int)start, (int)len);
            }
        }

        public override void Draw()
        {
            Console.WriteLine("+TextArea '{0}' draw text:\n{1}", name, WindowedText);
            base.Draw();
        }
        public override string ToString()
        {
            return String.Format("TextArea:'{0}', position: {1}, width:{2}", name, Pointer, WindowWidth);
        }

        public TextArea(string text = "", uint pointer = 0, uint width = 100, string name = null) : base(pointer, width, (uint)text.Length, name)
        {
            this.Text = text;
            Style = "Default textArea   style";
        }
    }
}
