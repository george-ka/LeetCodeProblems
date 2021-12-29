using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 200. Number of Islands
    /// https://leetcode.com/problems/number-of-islands/
    /// 
    /// Given an m x n 2D binary grid grid which represents a map of 
    /// '1's (land) and '0's (water), return the number of islands.
    /// An island is surrounded by water and is formed by connecting
    /// adjacent lands horizontally or vertically. You may assume all 
    /// four edges of the grid are all surrounded by water.
    public class NumberOfIslands2
    {
        // In this solution we'll try to build adjacency list 
        // from the very beginning 
        // it will be much longer
        public int NumIslands(char[][] grid)
        {
            var adjacencyList = new Dictionary<string, HashSet<string>>();

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '0')
                    {
                        var cord = $"{i},{j}";
                        var adjacentCord = string.Empty;
                        adjacencyList[cord] = new HashSet<string>();
                        if (IsValidCordinates(grid, i + 1, j) && grid[i + 1][j] != '0')
                        {
                            adjacentCord = $"{i+1},{j}";
                            adjacencyList[cord].Add(adjacentCord);
                        }

                        if (IsValidCordinates(grid, i - 1, j) && grid[i - 1][j] != '0')
                        {
                            adjacentCord = $"{i-1},{j}";
                            adjacencyList[cord].Add(adjacentCord);
                        }

                        if (IsValidCordinates(grid, i, j + 1) && grid[i][j + 1] != '0')
                        {
                            adjacentCord = $"{i},{j + 1}";
                            adjacencyList[cord].Add(adjacentCord);
                        }

                        if (IsValidCordinates(grid, i, j - 1) && grid[i][j - 1] != '0')
                        {
                            adjacentCord = $"{i},{j - 1}";
                            adjacencyList[cord].Add(adjacentCord);
                        }
                    }
                }
            }
            
            return CountNumberOfIslands(adjacencyList);
        }

        private int CountNumberOfIslands(Dictionary<string, HashSet<string>> adjacencyList)
        {
            var visited = new Dictionary<string, bool>();
            foreach (var key in adjacencyList.Keys)
            {
                visited[key] = false;
            }

            var numberOfIslands = 0;
            foreach (var key in adjacencyList.Keys)
            {
                if (visited[key])
                {
                    continue;
                }

                numberOfIslands++;
                var visitQueue = new Queue<string>();
                visitQueue.Enqueue(key);

                while (visitQueue.Count > 0)
                {
                    var visitKey = visitQueue.Dequeue();
                    if (visited[visitKey])
                    {
                        continue;
                    }

                    visited[visitKey] = true;
                    foreach (var toVisit in adjacencyList[visitKey])
                    {
                        visitQueue.Enqueue(toVisit);
                    }
                }
            }

            return numberOfIslands;
        }

        private bool IsValidCordinates(char[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }
    }
}