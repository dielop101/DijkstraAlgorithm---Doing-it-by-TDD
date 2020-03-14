using DijkstraAlgorithm.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgorithm
{
    public class DijkstraService
    {
        public int CalculateResult(List<Path> paths, string origin, string destination)
        {
            var allResults = new List<int>();

            while (paths.Any(x => !x.Checked))
            {
                var currentPath = paths.Where(path => path.VertexOrigin.Equals(origin)).OrderBy(path => !path.Checked ? 0 : 1).FirstOrDefault();
                currentPath.Checked = true;

                allResults.Add(GetResultForPath(paths, currentPath, destination));
            }

            allResults.Sort();
            return allResults.FirstOrDefault(value => value > 0);
        }

        private int GetResultForPath(List<Path> paths, Path currentPath, string destination)
        {
            var totalDistance = currentPath.Distance;
            var lastestOrigins = new List<string> { currentPath.VertexOrigin };

            while (!currentPath.VertexDestination.Equals(destination))
            {
                currentPath = paths.Where(path => path.VertexOrigin.Equals(currentPath.VertexDestination)).OrderBy(path => !path.Checked ? 0 : 1).FirstOrDefault();
                currentPath.Checked = true;

                if (lastestOrigins.Contains(currentPath.VertexDestination))
                    return 0;
                else
                {
                    totalDistance += currentPath.Distance;
                    lastestOrigins.Add(currentPath.VertexOrigin);
                }

            }

            return totalDistance;
        }
    }
}
