using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI.Text
{
    abstract class ScrollFrame : Canvas
    {
        protected uint pointer = 0;
        public uint Pointer
        {
            get => pointer;
            set
            {
                if (value < maxPointer)
                {
                    pointer = value;
                    Update();
                }
            }
        }
        public uint WindowWidth { get; set; } = 0;
        protected uint maxPointer = 0;

        public void Window(out uint start, out uint end)
        {
            start = Math.Max(Pointer, maxPointer - WindowWidth);
            end = Math.Min(maxPointer, start + WindowWidth) - start;
        }
        //public ScrollFrame(uint pointer = 0, uint width = 0, uint max = 0, string name = null) : base(name != null ? name : "scrollFrame " + ID)
        //{
        //    this.Pointer = pointer;
        //    this.WindowWidth = width;
        //    this.maxPointer = max;
        //}
        //public override string ToString()
        //{
            //return String.Format("ScrollFrame:'{0}',length:{1}, widndow:{2}", name, maxPointer, WindowWidth);
        //}
    }
}
