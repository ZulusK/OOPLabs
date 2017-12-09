using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Lab4.UI.Entities
{
    [Serializable]
    [DataContract]
    public class Rectangle
    {

        public Rectangle(uint width, uint heigth)
        {
            Width = width;
            Heigth = heigth;
        }

        public Rectangle()
        {
        }

        public Rectangle(uint width, uint heigth, int left, int top)
        {
            Width = width;
            Heigth = heigth;
            Left = left;
            Top = top;
        }

        [DataMember]
        public uint Width { get; set; }
        [DataMember]
        public uint Heigth { get; set; }
        [DataMember]
        public int Left { get; set; }
        [DataMember]
        public int Top { get; set; }

        public override String ToString()
        {
            return String.Format("Rectangle{0}x{1}:[{2},{3}]", Width, Heigth, Top, Left);
        }
    }
}
