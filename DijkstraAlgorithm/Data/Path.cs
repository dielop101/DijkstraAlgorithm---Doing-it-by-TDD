using System;

namespace DijkstraAlgorithm.Data
{
    public class Path : IComparable
    {
        public string VertexOrigin { get; private set; }
        public int Distance { get; private set; }
        public string VertexDestination { get; private set; }

        public bool Checked { get; set; }

        public Path(string vertexOrigin, int distance, string vertexDestination)
        {
            Distance = distance;
            VertexOrigin = vertexOrigin;
            VertexDestination = vertexDestination;
        }

        public int CompareTo(object obj)
        {
            var otherPath = obj as Path;
            return this.Checked.CompareTo(otherPath.Checked);
        }
    }
}