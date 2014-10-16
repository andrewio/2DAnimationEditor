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
        private float radiusHighlight;
        private float highlightRate = 1.25f;

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
            Init();
        }

        public Vertex2D(float x, float y)
            : base(x, y)
        {
            Init();
        }

        public Vertex2D() : base() 
        {
            Init();
        }


        public void Init()
        {
            // Подсветка - настройка 
            radiusHighlight = radius * highlightRate;
               
        }

        public void DrawBy (PaintEventArgs e)
        {
            
            /* Прорисовка this на компоненте PictureBox */
            RectangleF skeleton = new RectangleF(X - radius, Y - radius, 2 * radius, 2 * radius);
            e.Graphics.DrawEllipse(Pens.Aqua, skeleton);
            e.Graphics.FillEllipse(Brushes.Black, skeleton);

            // Подсветка (устанавливается в true при наведении курсора)
            if (highlight == true)
            {
                e.Graphics.DrawEllipse(Pens.Aqua, X - radiusHighlight, Y - radiusHighlight, 2 * radiusHighlight, 2 * radiusHighlight);
                highlight = false;
            }
        }

        public Point GetPoint()
        {
            Point p = new Point((int)X, (int)Y);
            return p;
        }

    }
}
