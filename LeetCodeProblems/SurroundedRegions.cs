using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace LeetCodeChallenges
{
    ///
    /// 130. Surrounded Regions
    /// https://leetcode.com/problems/surrounded-regions/
    /// 
    /// Given an m x n matrix board containing 'X' and 'O', 
    /// capture all regions that are 4-directionally surrounded by 'X'.
    /// A region is captured by flipping all 'O's into 'X's in that surrounded region.
    /// Surrounded regions should not be on the border, which means that any 'O' on the 
    /// border of the board are not flipped to 'X'. Any 'O' that is not on the border and 
    /// it is not connected to an 'O' on the border will be flipped to 'X'. Two cells are 
    /// connected if they are adjacent cells connected horizontally or vertically.
    public class SurroundedRegions
    {
        // Start expanding regions from the border and mark them differently
        // then just flip all the rest
        public void Solve(char[][] board) 
        {
            // explore the borders and find seeds
            var queue = new Queue<(int x, int y)>();
            for (var i = 0; i < board.Length; i++)
            {
                if (board[i][0] == 'O')
                {
                    queue.Enqueue((i, 0));
                }

                if (board[i][board[0].Length - 1] == 'O')
                {
                    queue.Enqueue((i, board[0].Length - 1));
                }
            }

            for (var j = 1; j < board[0].Length - 1; j++)
            {
                if (board[0][j] == 'O')
                {
                    queue.Enqueue((0, j));
                }

                if (board[board.Length - 1][j] == 'O')
                {
                    queue.Enqueue((board.Length - 1, j));
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (board[current.x][current.y] != 'O')
                {
                    continue;
                }

                board[current.x][current.y] = 'V';
                foreach (var d in Directions)
                {
                    (int x, int y) next = (current.x + d[0], current.y + d[1]);
                    if (IsValidCordinates(board, next.x, next.y) && board[next.x][next.y] == 'O')
                    {
                        queue.Enqueue(next);
                    }
                }
            }

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    else if (board[i][j] == 'V')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private bool IsValidCordinates(char[][] grid, int i, int j)
        {
            return i >= 0 && i < grid.Length && j >= 0 && j < grid[i].Length;
        }

        private static int[][] Directions = new []
        {
            ///         [-1 0]
            /// [ 0 -1] [ 0 0] [ 0 +1]
            ///         [+1 0] 
            new [] { 1, 0 },
            new [] { 0, 1 },
            new [] { 0, -1 },
            new [] { -1, 0 }
        };
    }
}