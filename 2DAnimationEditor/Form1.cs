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
using System.Xml;
using System.IO;

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
        // Вершина, над которой в последний раз находился курсор
        private Vertex2D hitVertex;

        // Происходит ли в данный момнет перемещение вершины
        private bool vertexMoving = false;

        // Для эстетического перемещения вершины
        // При D'n'D вершины: в каком месте пользователь взял вершину,
        // относительно него и перемещаем 
        private float movingOffsetX;
        private float movingOffsetY;

        // Режимы редактирования
        private List<CheckBox> modes;

        // Создаваемое ребро
        private List<Vertex2D> Edge = new List<Vertex2D>(2);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Переключение между кадрами
            if (Char.ToUpper(e.KeyChar) == (char)Keys.A && currentFrameIndex > 0)
            {
                currentFrameIndex--;
                dataGridAnimation.ClearSelection();
                dataGridAnimation.Rows[dataGridAnimation.CurrentCell.RowIndex].Cells[currentFrameIndex].Selected = true;
                textBoxCurrentFrame.Text = (currentFrameIndex).ToString();
                SceneView.Invalidate();
            }
            else if (Char.ToUpper(e.KeyChar) == (char)Keys.D && currentFrameIndex < dataGridAnimation.ColumnCount - 1)
            {
                currentFrameIndex++;
                dataGridAnimation.ClearSelection();
                dataGridAnimation.Rows[dataGridAnimation.CurrentCell.RowIndex].Cells[currentFrameIndex].Selected = true;
                textBoxCurrentFrame.Text = (currentFrameIndex).ToString();
                SceneView.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modes = new List<CheckBox> { checkBoxEdge, checkBoxVertex, checkBoxMoveMode };

            int framesCount = Convert.ToInt32(this.textBoxFramesCount.Text);
            textBoxCurrentFrame.Text = currentFrameIndex.ToString();
            //Чтение количества кадров по умолчанию, подготовка таблицы кадров
            dataGridAnimation.RowCount  = 1;
            dataGridAnimation.ColumnCount = framesCount;
            SetFramesNumbers();
            //Текущий кадр
            currentFrameIndex = dataGridAnimation.CurrentCell.ColumnIndex;
            //Init Пустых кадров
            for (int i = 0; i < framesCount; i++)
            {
                Animation.Add(new Frame());
            }
        }

        private void SetFramesNumbers()
        {
            //Заполнение номерами кадров
            for (int i = 0; i < dataGridAnimation.ColumnCount; i++)
            {
                dataGridAnimation[i, 0].Value = i;
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

                        //Удаление связанных граней
                        foreach (var vert in Animation[currentFrameIndex].Vertices)
                        {
                            vert.Value.Remove(hitVertex);

                        }
                    }
                }
                else
                {
                    // Добавить к прорисовке новую точку
                    this.Animation[currentFrameIndex].Vertices.Add(new Vertex2D(e.Location), new HashSet<Vertex2D>());                    
                    
                }
            }

            // Режим перемещения вершин
            if (checkBoxMoveMode.Checked && MouseIsOver(hitVertex))
            {
                vertexMoving = true;
                SceneView.MouseMove += SceneView_MouseMove_MovingVertex;
                SceneView.MouseUp += SceneView_MouseUp_MovingVertex;

                // Смещение курсора относительно центра
                // в момент взятия вершины
                movingOffsetX = hitVertex.X - e.X;
                movingOffsetY = hitVertex.Y - e.Y;
            }

            //Режим добалвения граней
            if (checkBoxEdge.Checked)
            {            
                if (MouseIsOver(hitVertex))
                {
                    Edge.Add(hitVertex);
                    if (Edge.Count == 2)
                        SceneView.MouseUp += SceneView_MouseUp_EdgeCreating;
                }              
            }

            // Redraw
            SceneView.Invalidate();
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

        private void SceneView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(SceneView.BackColor);

            //Перерисовка вершин и ребер

            foreach (var vert in Animation[currentFrameIndex].Vertices)
            {
                //Console.WriteLine("Перерисовка: " + vert.Key.X + " " + vert.Key.Y);
                vert.Key.DrawBy(e);

                // соседи
                foreach (var neighbour in vert.Value)
                {
                    e.Graphics.DrawLine(Pens.Red, vert.Key.GetPoint(), neighbour.GetPoint());
                }

            }

            // Прообраз добавляемой вершины (отображается возле курсора)
            if (checkBoxVertex.Checked)
            {
                preImage = new Vertex2D(newPoint);
                preImage.DrawBy(e);

            }
        }

        private void SceneView_MouseUp_EdgeCreating(
            object sender, MouseEventArgs e)
        {
            SceneView.MouseUp -= SceneView_MouseUp_EdgeCreating;

            if (e.Button == MouseButtons.Right)
            {
                //Добавление ребра
                Animation[currentFrameIndex].Vertices[Edge[0]].Remove(Edge[1]);
                Animation[currentFrameIndex].Vertices[Edge[1]].Remove(Edge[0]);
            }
            else
            {
                //Добавление ребра
                Animation[currentFrameIndex].Vertices[Edge[0]].Add(Edge[1]);
                Animation[currentFrameIndex].Vertices[Edge[1]].Add(Edge[0]);
            }

            //Закончить добаление ребра
            Edge.Clear();
            
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
        
        private bool MouseIsOver(Vertex2D vertex)
        {
            //Отслеживание наложения курсора
            return Math.Pow(newPoint.X - vertex.X, 2) + Math.Pow(newPoint.Y - vertex.Y, 2) < Math.Pow(vertex.Radius, 2);
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
            // Менеджер режимов редактирования
            // Включение одного - влечет отключение остальных
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
        private void dataGridAnimation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Динамическое отображение номера текущего кадра
            currentFrameIndex = dataGridAnimation.CurrentCell.ColumnIndex;
            textBoxCurrentFrame.Text = currentFrameIndex.ToString();

            //Загрузка кадра
            SceneView.Invalidate();

        }
        private void buttonSetFramesCount_Click(object sender, EventArgs e)
        {
            /* Установка количества кадров */
            try
            {
                setAnimationUI();

                int difference = dataGridAnimation.ColumnCount - Animation.Count;
                //Добавить или удалить кадры
                if (difference > 0)
                {
                    for (int i = 0; i < difference; i++)
                    {
                        Animation.Add(new Frame());
                    }
                }
                else if (difference < 0)
                {
                    for (int i = 0; i < Math.Abs(difference); i++)
                    {
                        // удаление последнего
                        Animation.RemoveAt(Animation.Count - 1);
                    }
                }

            }
            catch (Exception)
            {

                string caption = "Ошибка!";
                string message = "Неверный формат ввода данных.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            
            //Добавление или обрезание кадров к анимации
            
            
        }

        private void setAnimationUI()
        {
            dataGridAnimation.ColumnCount = Int32.Parse(textBoxFramesCount.Text);
            currentFrameIndex = dataGridAnimation.CurrentCell.ColumnIndex;
            textBoxCurrentFrame.Text = currentFrameIndex.ToString();
            SetFramesNumbers();
        }

        private void buttonSaveAnimation_Click(object sender, EventArgs e)
        {
            //Выбор директории для файла
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
      
            // Задание возможных расширений для файла
            saveFileDialog1.Filter = "txt files (*.xml)|*.xml| (*.*)|*.*";
            saveFileDialog1.FileName = "Animation";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Генерация упрощенных списков смежности
                for (int frameIndex = 0; frameIndex < Animation.Count; frameIndex++)
                {
                    CreateAdjecencyListForFrame(frameIndex);
                    //Распечатать список смежности
                    //PrintAdjacencyList(frameIndex);

                    Console.WriteLine("\nКадр №{0}\n", frameIndex);
                }

                // ***Запись в файл
                string fileName = saveFileDialog1.FileName;

                try
                {
                    XmlAnimationHandler.GenerateAnimationXml(Animation, fileName);
                }
                catch (Exception)
                {

                    string caption = "Ошибка!";
                    string message = "Запись невозможна";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }

            }
            

        } // end Save Button Click


        private void buttonLoadAnimation_Click(object sender, EventArgs e)
        {
            //Выбор директории для файла
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            // Задание возможных расширений для файла
            OpenFileDialog1.Filter = "txt files (*.xml)|*.xml| (*.*)|*.*";
            OpenFileDialog1.FileName = "Animation";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string fileName = OpenFileDialog1.FileName;
                try
                {
                    Animation = XmlAnimationHandler.LoadAnimationFromXml(fileName);
                    dataGridAnimation.ColumnCount = Animation.Count;
                    textBoxFramesCount.Text = Animation.Count.ToString();
                    currentFrameIndex = dataGridAnimation.CurrentCell.ColumnIndex;
                    textBoxCurrentFrame.Text = currentFrameIndex.ToString();
                    
                    SetFramesNumbers();
                }
                catch (Exception)
                {

                    string caption = "Ошибка!";
                    string message = "Неверный формат данных";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }

            }// end if - openFileDialog

        }//end click


        private void CreateAdjecencyListForFrame(int frameIndex)
        {
            // Пронумеровать вершины для каждого кадра,
            // опираясь на их Хэшкоды
            Animation[frameIndex].VerticesHashCodes = new List<int>();

            foreach (var vert in Animation[frameIndex].Vertices)
            {
                Animation[frameIndex].VerticesHashCodes.Add(vert.Key.GetHashCode());
            }

            //printArray(Animation[frameIndex].VerticesHashCodes);

            // ***Составить список смежности (упрощенный)

            // Начальная init
            Animation[frameIndex].AdjacencyList = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < Animation[frameIndex].VerticesHashCodes.Count; i++)
            {
                Animation[frameIndex].AdjacencyList.Add(i, new HashSet<int>());
            }// end Начальныая init


            int keyHashCode, keyIndex, neighbourHashCode, neighbourIndex;
            // По расширенному списку смежности     
            foreach (var vert in Animation[frameIndex].Vertices)
            {
                keyHashCode = vert.Key.GetHashCode();
                keyIndex = Animation[frameIndex].VerticesHashCodes.IndexOf(keyHashCode);

                // Ищем в соседях всех вершин этот Хэшкод
                foreach (var neighbour in vert.Value)
                {
                    neighbourHashCode = neighbour.GetHashCode();
                    neighbourIndex = Animation[frameIndex].VerticesHashCodes.IndexOf(neighbourHashCode);

                    // Добавить индекс соседа
                    Animation[frameIndex].AdjacencyList[keyIndex].Add(neighbourIndex);

                }

            }
        }

        private void PrintHashCodes(int frame)
        {
            foreach (KeyValuePair<Vertex2D, HashSet<Vertex2D>> KV in Animation[frame].Vertices)
            {
                Console.WriteLine();
                Console.WriteLine(KV.Key.GetHashCode() + ":");
                foreach (var item in KV.Value)
                {
                    Console.Write("{0} ", item.GetHashCode());
                }
                Console.WriteLine();
            }
        }

        private void PrintAdjacencyList(int frame)
        {
            foreach (KeyValuePair<int, HashSet<int>> KV in Animation[frame].AdjacencyList)
            {
                Console.WriteLine("\n" + KV.Key + ":");
                foreach (var item in KV.Value)
                {
                    Console.Write("{0} ", item);
                }
            }
        }

        public void printArray<T>(IEnumerable<T> a)
        {
            foreach (var i in a)
            {
                Console.Write("{0}\t",i);
            }
        }

        
    }
}
