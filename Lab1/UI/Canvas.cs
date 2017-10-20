﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.UI
{

    abstract class Canvas
    {
        static string environment;
        static CSSLoader stylyzer;

        uint width;
        uint height;
        int left;
        int top;
        string css;

        static Canvas()
        {
            environment = System.DateTime.Today.ToShortTimeString();
            stylyzer = new CSSLoader();
            Console.WriteLine("~canvas~ class loaded");
        }


        static CSSLoader Stylyzer
        {
            get => stylyzer;
        }


        public Canvas(string css = "Default") : this(0, 0, 0, 0, css)
        {

        }

        public Canvas(uint width, uint height, int left, int top, string css = null)
        {
            this.width = width;
            this.height = height;
            this.top = top;
            this.left = left;
            this.css = css!=null?css:"Default";
            Console.WriteLine("~canvas~ created ");
        }

        public uint Width
        {
            get => width;
            set
            {
                width = value;
                Update();
            }
        }
        public uint Height
        {
            get => height;
            set
            {
                height = value;
                Update();
            }
        }
        public int Left
        {
            get => left;
            set
            {
                left = value;
                Update();
            }
        }
        public int Top
        {
            get => top;
            set
            {
                top = value;
                Update();
            }
        }
        public long Bottom
        {
            get => top + height;
        }
        public long Rigth
        {
            get => left + width;
        }
        public string CSS
        {
            set
            {
                if (value != null)
                {
                    css = value;
                    Update();
                }
            }
            get => css;
        }
        protected virtual void Render()
        {
            stylyzer.apply(css);
            Draw();
        }
        protected virtual void Draw()
        {
            Console.WriteLine("~canvas~ draw canvas");
        }
        public virtual void Update()
        {
            Render();
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
