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
        private List<Vertex2D> vertices = new List<Vertex2D>();

        // The current mouse position while drawing a new polygon.
        private Point newPoint;


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

            if (checkBoxVertex.Checked)
            {
                this.vertices.Add(new Vertex2D(e.Location));
            }

            // Redraw.
            SceneView.Invalidate();
        }


      

        // Move the next point in the new polygon.
        private void SceneView_MouseMove(object sender, MouseEventArgs e)
        {
            
            newPoint = e.Location;
            foreach (var vertex in this.vertices)
            {
                //Если есть пересечение курсора с вершиной - подсветить ее
                if (Math.Pow(newPoint.X - vertex.X, 2) + Math.Pow(newPoint.Y - vertex.Y, 2) < Math.Pow(vertex.Radius, 2))
                {
                    vertex.Highlight = true;
                }
                else
                {
                    //vertex.Highlight = false;
                }

            }


            SceneView.Invalidate();
        }

        // Redraw old polygons in blue. Draw the new polygon in green.
        // Draw the final segment dashed.
        private void SceneView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(SceneView.BackColor);

            foreach (var vertex in this.vertices)
            {
                vertex.DrawBy(e);
            }

            if (checkBoxVertex.Checked)
            {
                Vertex2D v = new Vertex2D(newPoint);
                v.DrawBy(e);

            }
        }


       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxVertex_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
