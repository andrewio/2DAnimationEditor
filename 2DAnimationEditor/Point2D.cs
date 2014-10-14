using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAnimationEditor
{
    class Point2D
    {
        private float x;

        public float X
        {
            get { return x; }
            set { x = value; }
        }
        private float y;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        public Point2D()
            : this(0, 0)
        { }
    }
}
