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

        private List<Vertex2D> vertices = new List<Vertex2D>();

        // Текущая позиция курсора на компоненте PictureBox
        private Point newPoint;
        // Прообраз добавляемой вершины (отображается возле курсора)
        private Vertex2D preImage;

        private int hitVertex;
        private float offsetX;
        private float offsetY;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void SceneView_MouseDown(object sender, MouseEventArgs e)
        {

            // Режим Vertex
            if (checkBoxVertex.Checked)
            {
                this.vertices.Add(new Vertex2D(e.Location));
            }

            // Режим перемещения вершин
            if (checkBoxMoveMode.Checked)
            {
                SceneView.MouseMove += SceneView_MouseMove_MovingVertex;
                SceneView.MouseUp += SceneView_MouseUp_MovingVertex;

                // Remember the offset from the mouse
                // to the segment's first point.
                offsetX = vertices[hitVertex].X - e.X;
                offsetY = vertices[hitVertex].Y - e.Y;
            }

            // Redraw
            SceneView.Invalidate();
        }

        private void SceneView_MouseMove_MovingVertex(
    object sender, MouseEventArgs e)
        {
            // See how far the first point will move.
            int new_x1 = e.X + (int)offsetX;
            int new_y1 = e.Y + (int)offsetY;

            int dx = new_x1 - (int)vertices[hitVertex].X;
            int dy = new_y1 - (int)vertices[hitVertex].Y;

            if (dx == 0 && dy == 0) return;


            vertices[hitVertex] = new Vertex2D(
                    vertices[hitVertex].X + dx,
                    vertices[hitVertex].Y + dy);
            

            // Redraw.
            SceneView.Invalidate();
        }

        // Finish moving the selected polygon.
        private void SceneView_MouseUp_MovingVertex(
            object sender, MouseEventArgs e)
        {
            SceneView.MouseMove -= SceneView_MouseMove_MovingVertex;
            SceneView.MouseUp -= SceneView_MouseUp_MovingVertex;
        }


        private void SceneView_MouseMove(object sender, MouseEventArgs e)
        {
            // Обновление текущей позиции курсора
            newPoint = e.Location;

            // Проверка наложения курсора на vertex ...
            foreach (var vertex in vertices)
            {
                //Если есть пересечение курсора с вершиной - подсветить ее
                if (MouseIsOver(vertex))
                {
                    vertex.Highlight = true;
                    hitVertex = vertices.IndexOf(vertex);

                }
                else
                {
                    //vertex.Highlight = false;
                }

            }

            // Перерисовка
            SceneView.Invalidate();
        }

        
        private bool MouseIsOver(Vertex2D vertex)
        {
            //Отслеживание наложения курсора
            return Math.Pow(newPoint.X - vertex.X, 2) + Math.Pow(newPoint.Y - vertex.Y, 2) < Math.Pow(vertex.Radius, 2);
        }


        private void SceneView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(SceneView.BackColor);

            // Перерисовка вершин
            foreach (var vertex in this.vertices)
            {
                vertex.DrawBy(e);
            }

            // Прообраз добавляемой вершины (отображается возле курсора)
            if (checkBoxVertex.Checked)
            {
                preImage = new Vertex2D(newPoint);
                preImage.DrawBy(e);

            }
        }


       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxVertex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SceneView_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
