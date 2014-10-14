using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _2DAnimationEditor
{
    public partial class Form1 : Form
    {


        // Each polygon is represented by a List.
        private List<Point> Vertices = new List<Point>();

        // The current mouse position while drawing a new polygon.
        private Point NewPoint;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Start or continue drawing a new polygon.
        private void SceneView_MouseDown(object sender, MouseEventArgs e)
        {
            this.Vertices.Add(e.Location);

            // Redraw.
            SceneView.Invalidate();
        }


      

        // Move the next point in the new polygon.
        private void SceneView_MouseMove(object sender, MouseEventArgs e)
        {
            NewPoint = e.Location;
            SceneView.Invalidate();
        }

        // Redraw old polygons in blue. Draw the new polygon in green.
        // Draw the final segment dashed.
        private void SceneView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(SceneView.BackColor);

            foreach (var vertex in this.Vertices)
            {
                DrawVertex(vertex, e);
            }

            DrawVertex(NewPoint,e);
        }


        private void DrawVertex(Point p, PaintEventArgs e)
        {
            int vertexWidth = 40;
            Rectangle rect = new Rectangle(p.X - vertexWidth / 2, p.Y - vertexWidth / 2, vertexWidth, vertexWidth);
            e.Graphics.DrawEllipse(Pens.Aqua, rect);
            e.Graphics.FillEllipse(Brushes.Black, rect);
        }
    }
}
