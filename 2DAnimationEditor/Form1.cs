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

        // Все кадры
        private List<Frame> Animation = new List<Frame>();
        private int currentFrameIndex = 0;
        // Текущая позиция курсора на компоненте PictureBox
        private Point newPoint;
        // Прообраз добавляемой вершины (отображается возле курсора)
        private Vertex2D preImage;

        // Происходит ли в данный момнет перемещение вершины
        private bool vertexMoving = false;

        // Вершина, над которой в последний раз находился курсор
        private Vertex2D hitVertex;

        //Для эстетического перемещения вершины
        //При D'n'D вершины: в каком месте пользователь взял вершину,
        //относительно него и перемещаем 
        private float movingOffsetX;
        private float movingOffsetY;

        //Режимы редактирования
        private List<CheckBox> modes;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modes = new List<CheckBox> { checkBoxEdge, checkBoxVertex, checkBoxMoveMode };

            int framesCount = Convert.ToInt32(this.textBoxFramesCount.Text);

            //Чтение количества кадров по умолчанию, подготовка таблицы кадров
            dataGridAnimation.RowCount  = 1;
            dataGridAnimation.ColumnCount = framesCount;
            //Заполнение номерами кадров
            for (int i = 0; i < dataGridAnimation.ColumnCount; i++)
            {
                dataGridAnimation[i, 0].Value = i;
            }
            //Текущий кадр
            currentFrameIndex = dataGridAnimation.CurrentCell.ColumnIndex;
            //Init Пустых кадров
            for (int i = 0; i < framesCount; i++)
            {
                Animation.Add(new Frame());
            }
        }


        private void SceneView_MouseDown(object sender, MouseEventArgs e)
        {

            // Режим Vertex
            if (checkBoxVertex.Checked)
            {
                
                //Удаление вершины
                if (e.Button == MouseButtons.Right)
                {
                    if (MouseIsOver(hitVertex))
                    {
                        this.Animation[currentFrameIndex].Vertices.Remove(hitVertex);
                    }
                }
                else
                {
                    //// Добавить к прорисовке новую точку
                    this.Animation[currentFrameIndex].Vertices.Add(new Vertex2D(e.Location), new HashSet<Vertex2D>());                    
                    
                }
            }

            // Режим перемещения вершин
            if (checkBoxMoveMode.Checked)
            {
                vertexMoving = true;
                SceneView.MouseMove += SceneView_MouseMove_MovingVertex;
                SceneView.MouseUp += SceneView_MouseUp_MovingVertex;

                // Смещение курсора относительно центра
                // в момент взятия вершины
                movingOffsetX = hitVertex.X - e.X;
                movingOffsetY = hitVertex.Y - e.Y;
            }

            // Redraw
            SceneView.Invalidate();
        }

        private void SceneView_MouseMove_MovingVertex(
    object sender, MouseEventArgs e)
        {
            // Позиция нового центра вершины 
            float new_x = e.X + movingOffsetX ;
            float new_y = e.Y + movingOffsetY;

            // Взяли и отпустили в одном месте
            if (new_x == 0 && new_y == 0) return;

            // Непосредственно перемещение (прорисовка в событии Paint)
            hitVertex.X = new_x;
            hitVertex.Y = new_y;
            //Console.WriteLine("Перемещение: " + new_x.ToString() + " " + new_y.ToString());

            // Redraw.
            SceneView.Invalidate();
        }


        private void SceneView_MouseUp_MovingVertex(
            object sender, MouseEventArgs e)
        {
            SceneView.MouseMove -= SceneView_MouseMove_MovingVertex;
            SceneView.MouseUp -= SceneView_MouseUp_MovingVertex;

            //Прекратить перемещение
            vertexMoving = false;

        }


        private void SceneView_MouseMove(object sender, MouseEventArgs e)
        {
            // Обновление текущей позиции курсора
            newPoint = e.Location;

            // Проверка наложения курсора на vertex ...
            foreach (var vertex in Animation[currentFrameIndex].Vertices)
            {

                //Если есть пересечение курсора с вершиной - подсветить ее
                if (MouseIsOver(vertex.Key))
                {
                    vertex.Key.Highlight = true;
                    if (!vertexMoving)
                        hitVertex = vertex.Key;

                    //Console.WriteLine("Пересечение: " + hitVertex.X.ToString() + " " + hitVertex.Y.ToString());
                    //Console.WriteLine("Пересечение: " + vertex.Key.X.ToString() + " " + vertex.Key.Y.ToString());

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

            //Перерисовка вершин

            foreach (var vert in Animation[currentFrameIndex].Vertices)
            {
                //Console.WriteLine("Перерисовка: " + vert.Key.X + " " + vert.Key.Y);
                vert.Key.DrawBy(e);
            }

            // Прообраз добавляемой вершины (отображается возле курсора)
            if (checkBoxVertex.Checked)
            {
                preImage = new Vertex2D(newPoint);
                preImage.DrawBy(e);

            }
        }

        private void SceneView_MouseUp(object sender, MouseEventArgs e)
        {

        }


        private void checkBoxVertex_CheckedChanged(object sender, EventArgs e)
        {
            startMode(sender);
        }

        private void checkBoxMoveMode_CheckedChanged(object sender, EventArgs e)
        {
            startMode(sender);
        }

        private void checkBoxEdge_CheckedChanged(object sender, EventArgs e)
        {
            startMode(sender);
        }

        private void startMode(object sender)
        {
            CheckBox current = sender as CheckBox;
            if (current.Checked)
            {
                foreach (CheckBox mode in modes)
                {
                    if (mode.Name != current.Name)
                    {
                        mode.Checked = false;
                    }
                }
            }
        }

        private void dataGridAnimation_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCurrentFrame.Text = dataGridAnimation.CurrentCell.ColumnIndex.ToString();
        }
    }
}
