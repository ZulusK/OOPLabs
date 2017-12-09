using Lab4.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
namespace Lab4.UI
{
    [Serializable]
    [DataContract]
    abstract class Canvas
    {
        public static string Environment
        {
            get;
            protected set;
        }
        public static CSSLoader Stylizer
        {
            get;
            protected set;
        }

        static Canvas()
        {
            Environment = System.DateTime.Today.ToShortTimeString();
            Stylizer = new CSSLoader();
            Console.WriteLine(".Canvas: class loaded");
        }

        Rectangle frame;
        string css;

        public Rectangle Frame
        {
            get => frame;
            set
            {
                if (value != null)
                {
                    frame = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
        public string CSS
        {
            get => css; set
            {
                if (value != null)
                {
                    css = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        protected string GetStyle(string CSS)
        {
            if (CSS != null)
            {
                return CSS;
            }
            else
            {
                return string.Format("Default '{0}' style", this.GetType().Name);
            }
        }

        public Canvas(Rectangle frame, string CSS = null)
        {
            this.frame = frame;
            this.css = this.GetStyle(CSS);
            Console.WriteLine(".Canvas: created");
        }

        public Canvas() : this(new Rectangle())
        {
        }
        protected virtual void Render()
        {
            Stylizer.Apply(this.CSS);
            this.Draw();
        }
        protected abstract void Draw();

        public abstract void Update();
        public override string ToString()
        {
            return String.Format("Canvas in frame: {0}", this.Frame);
        }
    }
}
