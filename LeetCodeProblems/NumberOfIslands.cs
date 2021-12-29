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
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            char currentIsland = (char)0;
            var listOfIslandsToMerge = new HashSet<string>();

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '0')
                    {
                        currentIsland = MarkAdjacent(grid, i, j, currentIsland, listOfIslandsToMerge);
                    }
                }
            }
            
            Console.WriteLine($"current island {(int)currentIsland}, list of islands to merge {listOfIslandsToMerge.Count}");
            foreach (var p in listOfIslandsToMerge)
            {
                Console.WriteLine($"merge {p}");
            }

            var islandsAdjacencyList = new Dictionary<int, HashSet<int>>();
            for (var i = 1; i <= (int)currentIsland; i++ )
            {
                if (i == (int)'0' || i == (int)'1')
                {
                    continue;
                }
                
                islandsAdjacencyList[i] = new HashSet<int>();        
            }

            foreach (var adjacency in listOfIslandsToMerge)
            {
                islandsAdjacencyList[(int)adjacency[0]].Add((int)adjacency[1]);
                islandsAdjacencyList[(int)adjacency[1]].Add((int)adjacency[0]);
            }
            
            return CountNumberOfIslands(islandsAdjacencyList);
        }

        private int CountNumberOfIslands(Dictionary<int, HashSet<int>> adjacencyList)
        {
            var visited = new Dictionary<int, bool>();
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
                var visitQueue = new Queue<int>();
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

        private char MarkAdjacent(
            char[][] grid, 
            int i,
            int j,
            char currentIsland, 
            HashSet<string> listOfIslandsToMerge)
        {
            var newCurrentIsland = currentIsland;
            var adjacentIslands = new List<char>();
            if (IsMarkedAsIsland(grid, i, j))
            {
                adjacentIslands.Add(grid[i][j]);
            }

            if (IsMarkedAsIsland(grid, i - 1, j))
            {
                adjacentIslands.Add(grid[i - 1][j]);
            }

            if (IsMarkedAsIsland(grid, i + 1, j))
            {
                adjacentIslands.Add(grid[i + 1][j]);
            }

            if (IsMarkedAsIsland(grid, i, j - 1))
            {
                adjacentIslands.Add(grid[i][j - 1]);
            }

            if (IsMarkedAsIsland(grid, i, j + 1))
            {
                adjacentIslands.Add(grid[i][j + 1]);
            }

            char islandName;
            if (adjacentIslands.Count == 0)
            {
                newCurrentIsland = (char)((int)currentIsland + 1);
                Console.WriteLine($"New current Island = {newCurrentIsland} {(int)newCurrentIsland}");
                while (newCurrentIsland == '0' || newCurrentIsland == '1')
                {
                    newCurrentIsland++;
                }

                islandName = newCurrentIsland;
            }
            else
            {
                islandName = adjacentIslands[0];
                foreach (var islandToMerge in adjacentIslands)
                {
                    if (islandToMerge == islandName)
                    {
                        continue;
                    }
                    
                    listOfIslandsToMerge.Add(new string(new [] { islandName, islandToMerge }));
                }
            }

            MarkIsland(grid, i, j, islandName);

            return newCurrentIsland;
        }

        private void MarkIsland(char[][] grid, int i, int j, char islandName)
        {
            if (!IsValidCordinates(grid, i, j))
            {
                return;
            }
            
            grid[i][j] = islandName;
        }

        private bool IsMarkedAsIsland(char[][] grid, int i, int j)
        {
            return IsValidCordinates(grid, i, j)
                && grid[i][j] != '1' && grid[i][j] != '0';
        }

        private bool IsValidCordinates(char[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }
    }
}