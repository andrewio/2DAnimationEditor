using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAnimationEditor
{
    class Frame
    {
        // Список смежности (теория графов) с полной информацией о вершинах
        // Ключ - Значение: Вершина - соседи
        private Dictionary<Vertex2D, HashSet<Vertex2D>> vertices = new Dictionary<Vertex2D, HashSet<Vertex2D>>();
        // Хэшкоды всех вершин данного кадра
        private List<int> verticesHashCodes;
        // Список смежности (упрощенный) - "Карта" 
        private Dictionary<int, HashSet<int>> adjacencyList;

        public Dictionary<int, HashSet<int>> AdjacencyList
        {
            get { return adjacencyList; }
            set { adjacencyList = value; }
        }

        internal Dictionary<Vertex2D, HashSet<Vertex2D>> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        public List<int> VerticesHashCodes
        {
            get { return verticesHashCodes; }
            set { verticesHashCodes = value; }
        }

    }
}
