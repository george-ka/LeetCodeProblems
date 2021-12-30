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
    public class NumberOfIslands3
    {
        // In this solution we'll try to DFS using the grid
        public int NumIslands(char[][] grid)
        {
            var numberOfIslands = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '0' && grid[i][j] != 'v')
                    {
                        numberOfIslands++;
                        MarkVisitedAndAllAdjacent(grid, i, j);
                    }
                }
            }
            
            return numberOfIslands;
        }

        private void MarkVisitedAndAllAdjacent(char[][] grid, int i, int j)
        {
            grid[i][j] = 'v';

            foreach (var direction in Directions)
            {
                if (IsValidCordinates(grid, i + direction[0], j + direction[1]) 
                    && grid[i + direction[0]][j + direction[1]] == '1')
                {
                    MarkVisitedAndAllAdjacent(grid, i + direction[0], j + direction[1]);
                }
            }
        }

        private static List<int[]> Directions = new List<int[]> 
        { 
            new int[] { -1, 0 }, 
            new int[] { 1, 0 }, 
            new int[] { 0, -1 }, 
            new int[] { 0, 1 }, 
        };

        private bool IsValidCordinates(char[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }
    }
}