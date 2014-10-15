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


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void SceneView_MouseDown(object sender, MouseEventArgs e)
        {

            //Режим Vertex
            if (checkBoxVertex.Checked)
            {
                this.vertices.Add(new Vertex2D(e.Location));
            }

            // Redraw
            SceneView.Invalidate();
        }


        private void SceneView_MouseMove(object sender, MouseEventArgs e)
        {
            // Обновление текущей позиции курсора
            newPoint = e.Location;


            // Проверка наложения курсора на vertex ...
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

            // Перерисовка
            SceneView.Invalidate();
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
    }
}
