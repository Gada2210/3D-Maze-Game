using System;
using System.Collections.Generic;

namespace ShareefSoftware
{
    /// Utility class to traverse a grid.
    public class GridTraversal<T>
    {
        private readonly IGridGraph<T> grid;
        private List<((int Row, int Column) From, (int Row, int Column) To)> edges;
        private Dictionary<(int Row, int Column), (int Row, int Column)> parents;

        public GridTraversal(IGridGraph<T> grid)
        {
            this.grid = grid;
            this.edges = new List<((int Row, int Column) From, (int Row, int Column) To)>();
            this.parents = new Dictionary<(int Row, int Column), (int Row, int Column)>();
        }

        private (int Row, int Column) Find((int Row, int Column) cell)
        {
            if (parents[cell] != cell)
            {
                parents[cell] = Find(parents[cell]);
            }
            return parents[cell];
        }

        private void Union((int Row, int Column) cell1, (int Row, int Column) cell2)
        {
            parents[Find(cell1)] = Find(cell2);
        }

        private void Shuffle<E>(IList<E> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public IEnumerable<((int Row, int Column) From, (int Row, int Column) To)> GenerateMaze(int startRow, int startColumn)
        {
            for (int row = 0; row < grid.NumberOfRows; row++)
            {
                for (int column = 0; column < grid.NumberOfColumns; column++)
                {
                    if (row < grid.NumberOfRows - 1)
                    {
                        edges.Add(((row, column), (row + 1, column)));
                    }
                    if (column < grid.NumberOfColumns - 1)
                    {
                        edges.Add(((row, column), (row, column + 1)));
                    }
                    parents[(row, column)] = (row, column);
                }
            }

            Shuffle(edges);

            foreach (var edge in edges)
            {
                if (Find(edge.From) != Find(edge.To))
                {
                    Union(edge.From, edge.To);
                    yield return edge;
                }
            }
        }
    }
}
