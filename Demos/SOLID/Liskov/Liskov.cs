using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    class Liskov
    {
        static void Main(string[] args)
        {
            List<Rectangle> rects = new List<Rectangle> { new Rectangle { Width = 5, Height = 8 }, new Square { Height = 10 } };
            foreach (var item in rects)
            {
                item.Width = 20;
                item.Height = 40;
            }

            foreach (var item in rects)
            {
                Debug.Assert(item.Height == 40, "Height falsch");
                Debug.Assert(item.Width == 20, "Width falsch");
            }
        }
    }

    public class Rectangle
    {
        protected int m_Width;
        public virtual int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        protected int m_Height;
        public virtual int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
    }

    public class Square : Rectangle
    {
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.m_Width = value;
            }
        }

        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.m_Height = value;
            }
        }
    }
}
