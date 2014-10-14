using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DAnimationEditor
{
    class Vertex2D : Point2D
    {
        private float radius = 20;
        private float radiusHighlight = 30;

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        private bool highlight = false;

        public bool Highlight
        {
            get { return highlight; }
            set { highlight = value; }
        }


        public Vertex2D(Point p) : base(p.X, p.Y)
        {

        }

        public Vertex2D(float x, float y)
            : base(x, y)
        {

        }

        public Vertex2D() : base() { }

        public void DrawBy (PaintEventArgs e)
        {
            RectangleF rect = new RectangleF(X - radius, Y - radius, 2 * radius, 2 * radius);
            e.Graphics.DrawEllipse(Pens.Aqua, rect);
            e.Graphics.FillEllipse(Brushes.Black, rect);


            if (highlight == true)
            {

                RectangleF rectHighlight = new RectangleF(X - radiusHighlight, Y - radiusHighlight, 2 * radiusHighlight, 2 * radiusHighlight);
                e.Graphics.DrawEllipse(Pens.Aqua, rectHighlight);
                highlight = false;
            }
        }

    }
}
