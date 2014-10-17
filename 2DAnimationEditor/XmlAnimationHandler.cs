using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace _2DAnimationEditor
{
    class XmlAnimationHandler
    {
        public static List<Frame> LoadAnimationFromXml(string fileName)
        {
            
            //Создать новую анимация
            List<Frame> outputAnimation = outputAnimation = new List<Frame>();
            //Считать Xml Document
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(fileName);
            //Считать количество кадров
            XmlNodeList frameNodes = doc.SelectNodes("/Animation/Frame");

            //Заполнить пустыми кадрами
            for (int frameIndex = 0; frameIndex < frameNodes.Count; frameIndex++)
            {
                outputAnimation.Add(new Frame());
            }

            //Заполнить упрощенные списки смежности
            //Считать вершины в кадр (без соседей)
            foreach (XmlNode frame in frameNodes)
            {
                //Каждый кадр
                int frameID = Int32.Parse(frame.Attributes["ID"].Value);
                XmlNodeList vertices = frame.ChildNodes[0].ChildNodes;

                //Начальная init VerticesHashCodes & AdjacencyList
                outputAnimation[frameID].VerticesHashCodes = new List<int>();
                outputAnimation[frameID].AdjacencyList = new Dictionary<int, HashSet<int>>();
                //Для избежания поиска по хэшу в словаре, заранее пронумеруем вершины
                Dictionary<int, Vertex2D> numberedVertices = new Dictionary<int, Vertex2D>();
                for (int j = 0; j < vertices.Count; j++)
                {
                    outputAnimation[frameID].VerticesHashCodes.Add(-1);
                    outputAnimation[frameID].AdjacencyList.Add(j, new HashSet<int>());
                    numberedVertices.Add(j, null);
                }

                //Инициализация вершин, и их Хэшкодов, без списка соседей
                foreach (XmlNode vert in vertices)
                {
                    float x = Int32.Parse(vert.Attributes["X"].Value);
                    float y = Int32.Parse(vert.Attributes["Y"].Value);
                    int id = Int32.Parse(vert.Attributes["ID"].Value);

                    Vertex2D newVertex = new Vertex2D(x, y);
                    numberedVertices[id] = newVertex;
                    outputAnimation[frameID].Vertices.Add(newVertex, new HashSet<Vertex2D>());
                    outputAnimation[frameID].VerticesHashCodes[id] = newVertex.GetHashCode();

                    //Считать упрощенный список смежности
                    //Добавить его к текущему кадру
                    foreach (XmlNode neighbour in vert.ChildNodes)
                    {
                        outputAnimation[frameID].AdjacencyList[id].Add(int.Parse(neighbour.InnerText));
                    }
                }
                // Для данного кадра 
                // Есть вершины и их хэшкоды, упрощенный список смежности

                //* Назначить соседей
                foreach (var vert in outputAnimation[frameID].Vertices)
                {

                    int keyHashCode = vert.Key.GetHashCode();
                    //Получить id по хэшкоду
                    int id = outputAnimation[frameID].VerticesHashCodes.IndexOf(keyHashCode);
                    //Получить список id вершин из AdjacencyList 
                    foreach (var neighbour in outputAnimation[frameID].AdjacencyList[id])
                    {
                        vert.Value.Add(numberedVertices[neighbour]);
                    }
                }


            } //end xml read

            return outputAnimation;
        }

        public static void GenerateAnimationXml(List<Frame> Animation, string fileName)
        {

            //Создание заготовочного файла с root элементом
            XmlTextWriter textWritter = new XmlTextWriter(fileName, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("Animation");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            foreach (var frame in Animation)
            {
                XmlNode xmlElementFrame = document.CreateElement("Frame");
                document.DocumentElement.AppendChild(xmlElementFrame);

                XmlAttribute frameID = document.CreateAttribute("ID");
                frameID.Value = Animation.IndexOf(frame).ToString();
                xmlElementFrame.Attributes.Append(frameID);

                XmlNode xmlElementVertices = document.CreateElement("Vertices");
                xmlElementFrame.AppendChild(xmlElementVertices);


                int keyHashCode, keyIndex;
                // По расширенному списку смежности     
                foreach (var vert in frame.Vertices)
                {
                    XmlNode xmlElementVertex = document.CreateElement("Vertex");
                    xmlElementVertices.AppendChild(xmlElementVertex);

                    XmlAttribute attributeX = document.CreateAttribute("X");
                    attributeX.Value = vert.Key.X.ToString();
                    xmlElementVertex.Attributes.Append(attributeX);

                    XmlAttribute attributeY = document.CreateAttribute("Y");
                    attributeY.Value = vert.Key.Y.ToString();
                    xmlElementVertex.Attributes.Append(attributeY);

                    XmlAttribute attributeID = document.CreateAttribute("ID");
                    keyHashCode = vert.Key.GetHashCode();
                    keyIndex = frame.VerticesHashCodes.IndexOf(keyHashCode);
                    attributeID.Value = keyIndex.ToString();
                    xmlElementVertex.Attributes.Append(attributeID);

                    foreach (var neighbour in frame.AdjacencyList[keyIndex])
                    {
                        XmlNode xmlElementNeighbour = document.CreateElement("Neighbour");
                        xmlElementNeighbour.InnerText = neighbour.ToString();
                        xmlElementVertex.AppendChild(xmlElementNeighbour);
                    }

                }
            }

            document.Save(fileName);

        } // end saveAnimationToXml

    }
}
