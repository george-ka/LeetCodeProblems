using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 1091. Shortest Path in Binary Matrix
    /// https://leetcode.com/problems/shortest-path-in-binary-matrix/
    /// 
    /// Given an n x n binary matrix grid, return the length of the 
    /// shortest clear path in the matrix. If there is no clear path, 
    /// return -1.
    /// A clear path in a binary matrix is a path from the top-left cell 
    /// (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such 
    /// that:
    /// All the visited cells of the path are 0.
    /// All the adjacent cells of the path are 8-directionally connected 
    /// (i.e., they are different and they share an edge or a corner).
    /// The length of a clear path is the number of visited cells of this path.
    public class ShortestPathInBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid) 
        {
            if (grid == null
            || grid[0][0] == 1
            || grid[grid.Length - 1][grid[grid.Length - 1].Length - 1] == 1)
            {
                return -1;
            }

            var nodesList = new List<int[]>();
            var memo = new Dictionary<string, Tuple<int, int[][]>>();
            var result = GoNext(grid, 0, 0, nodesList, memo);
            
            if (result.Item1 == -1)
            {
                return -1;
            }

            return result.Item1; 
        }

        private bool IsReachable(int[] cord1, int[] cord2)
        {
            foreach (var d in Directions)
            {
                if (cord1[0] + d[0] == cord2[0]
                && cord1[1] + d[1] == cord2[1])
                {
                    return true;
                }
            }

            return false;
        }

        private Tuple<int, int[][]> GoNext(int[][] grid, int i, int j, IList<int[]> nodesList, Dictionary<string, Tuple<int, int[][]>> memo, int depth = 0)
        {
            var resultPath = nodesList.ToList();
            resultPath.Add(new int[] { i, j });

            // Destination reached
            if (i == grid.Length - 1 && j == grid.Length - 1)
            {                
                return new Tuple<int, int[][]>(1, resultPath.ToArray());
            }

            if (IsClearToDownRight(grid, i, j) 
                && memo.ContainsKey($"{i},{j}"))
            {
                return memo[$"{i},{j}"];
            }

            // mark visited
            grid[i][j] = 2;
            var nodesListCount = nodesList.Count;

            // Given that the target is known to be the bottom right cell
            // in the order of directions should be based on that direction
            // (bottom right) 
            // We should reorder directions based on the distance to the target and their own weight
            var directionsWithDistance = Directions
                .Where(d => CanMakeNextMove(grid, i, j, d))
                .Select(d => new DirectionWithDistance(d, DistanceToTarget(grid, i, j, d)))
                .OrderBy(dd => dd.Distance)
                .ToArray();

            int? resultingMinimum = null;
            int[][] minModesList = null;
            var tabulation = new string(' ', depth);
            Console.WriteLine($"{tabulation}On ({i}, {j}). Directions: " + string.Join(',', directionsWithDistance.Select(x => $"({x.Direction[0]}, {x.Direction[1]}, {x.Distance})")));
            Console.WriteLine($"{tabulation}On ({i}, {j}). Visited nodes: " + string.Join(',', nodesList.Select(x => $"({x[0]}, {x[1]})")));
            if (i == 1 && j == 0)
            {
                Console.WriteLine($"(2,0) is {grid[2][0]}");
            }
            
            foreach (var dd in directionsWithDistance)
            {
                var d = dd.Direction;
                Console.WriteLine($"{tabulation}On ({i}, {j}). Trying direction ({d[0]}, {d[1]})");
                var subresult = GoNext(grid, i + d[0], j + d[1], nodesList, memo, depth + 1);
                Console.WriteLine($"{tabulation}On ({i}, {j}). subresult {subresult} for {i+d[0]}, {j + d[1]}");
               
                if (subresult.Item1 >= 0)
                {
                    nodesList.Add(new [] { i + d[0], j + d[1]});
                    if ((resultingMinimum.HasValue && subresult.Item1 + 1 < resultingMinimum.Value)
                        || !resultingMinimum.HasValue)
                    {
                        resultingMinimum = subresult.Item1 + 1;
                        minModesList = subresult.Item2;
                    }
                }

                // revert steps for the next iteration
                for (var s = nodesList.Count - 1; s >= nodesListCount; s--)
                {
                    grid[nodesList[s][0]][nodesList[s][1]] = 0;
                    nodesList.RemoveAt(s);
                }
            }

            if (minModesList != null)
            {
                resultPath.Clear();
                for (var n = 0; n < minModesList.Length; n++)
                    resultPath.Add(minModesList[n]);

                OptimizePath(resultPath);
            }
            
            grid[i][j] = 0;
            var result = new Tuple<int, int[][]>(
                resultingMinimum.HasValue ? resultingMinimum.Value : -1, 
                resultPath.ToArray());
            
            if (IsClearToDownRight(grid, i, j))
            {
                memo[$"{i},{j}"] = result;
            }

            return result;
        }

        private void OptimizePath(List<int[]> nodesList)
        {
            Console.WriteLine("Path ");
            var path = nodesList.ToArray();
            for (var i = 0; i < path.Length; i++)
            {
                Console.WriteLine($"{path[i][0]},{path[i][1]}");

                if (i - 1 >= 0
                    && i + 1 < path.Length 
                    && IsReachable(path[i + 1], path[i - 1]))
                {
                    Console.WriteLine("DELETE!");
                    nodesList.RemoveAt(i);
                }
            }   
        }

        private bool IsClearToDownRight(int[][] grid, int i, int j)
        {
            for (var i1 = i; i1 < grid.Length; i1++)
            {
                for (var j1 = j; j1 < grid[i1].Length; j1++)
                {
                    if (grid[i1][j1] > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private double DistanceToTarget(int[][] grid, int i, int j, int[] nextMoveDirection)
        {
            var targetI = grid.Length - 1;
            var targetJ = grid[targetI].Length - 1;

            return Math.Sqrt(Math.Pow(targetI - i - nextMoveDirection[0], 2) + Math.Pow(targetJ - j - nextMoveDirection[1], 2));
        }

        private bool CanMakeNextMove(int[][] grid, int i, int j, int[] nextMoveDirection)
        {
            return IsValidCordinates(grid, i + nextMoveDirection[0], j + nextMoveDirection[1])
                 && grid[i + nextMoveDirection[0]][j + nextMoveDirection[1]] == 0;
        }

        private bool IsValidCordinates(int[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }

        private static int[][] Directions = new []
        {
            /// [-1 -1] [-1 0] [-1 +1]
            /// [ 0 -1] [ 0 0] [ 0 +1]
            /// [+1 -1] [+1 0] [+1 +1]
            /// Third coordinate is weight of a step
            new [] { 1, 1 },
            new [] { 1, 0 },
            new [] { 0, 1 },
            new [] { -1, 1 },
            new [] { 1, -1 },
            new [] { 0, -1 },
            new [] { -1, 0 },
            new [] { -1, -1 }
        };

        private class DirectionWithDistance
        {
            public DirectionWithDistance(int[] direction, double distance)
            {
                Direction = direction;
                Distance = distance;
            }

            public int[] Direction { get; set; }

            public double Distance { get; set; }
        }
    }
}