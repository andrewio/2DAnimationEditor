using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DAnimationEditor
{
    class Vertex2D : Point2D, IEquatable<Vertex2D>
    {
        private float radius = 20;
        private float radiusHighlight;
        private float highlightRate = 1.25f;
        private RectangleF skeletonHighlight;
        private RectangleF skeleton;

        private int vertex2D_ID;

        public int Vertex2D_ID
        {
            get 
            {
                return vertex2D_ID; 
            }
            set 
            { 
                vertex2D_ID = value; 
            }
        }

        public override int GetHashCode()
        {
            return Vertex2D_ID;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex2D);
        }
        public bool Equals(Vertex2D obj)
        {
            return obj != null && obj.Vertex2D_ID == this.Vertex2D_ID;
        }

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
            // Заготовка эллипса и его подсветки для this
            // (Рисуем эллипс относительно центра)
            radiusHighlight = radius * highlightRate;
            skeleton = new RectangleF(X - radius, Y - radius, 2 * radius, 2 * radius);
            skeletonHighlight = new RectangleF(X - radiusHighlight, Y - radiusHighlight, 2 * radiusHighlight, 2 * radiusHighlight);
               
        }

        public void DrawBy (PaintEventArgs e)
        {
            /* Прорисовка this на компоненте PictureBox */

            e.Graphics.DrawEllipse(Pens.Aqua, skeleton);
            e.Graphics.FillEllipse(Brushes.Black, skeleton);

            // Подсветка (устанавливается в true при наведении курсора)
            if (highlight == true)
            {
                e.Graphics.DrawEllipse(Pens.Aqua, skeletonHighlight);
                highlight = false;
            }
        }

    }
}
