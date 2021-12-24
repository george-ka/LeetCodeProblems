using System;

namespace LeetCodeChallenges
{
	///
	/// 74. Search a 2D Matrix
	/// https://leetcode.com/problems/search-a-2d-matrix/
	///
    /// Write an efficient algorithm that searches for a value in 
    /// an m x n matrix. This matrix has the following properties:
    /// - Integers in each row are sorted from left to right.
    /// - The first integer of each row is greater than the last 
    ///   integer of the previous row.
    public class SearchInSortedMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var leftBoundary = 0;
            var rightBoundary = matrix.Length - 1;
            var candidate = -1;
            var targetRow = 0;

            // step 1 search row
            while (leftBoundary < rightBoundary)
            {
                if (leftBoundary + 1 == rightBoundary)
                {
                    Console.WriteLine($"lb {leftBoundary} rb {rightBoundary}");
                    if (matrix[leftBoundary][0] == target 
                    || matrix[rightBoundary][0] == target)
                    {
                        return true;
                    }
                    else if (matrix[leftBoundary][0] < target 
                        && matrix[rightBoundary][0] > target)
                    {
                        targetRow = leftBoundary;
                        break;
                    }
                    else if (matrix[rightBoundary][0] < target
                        && matrix[rightBoundary][matrix[rightBoundary].Length - 1] >= target)
                    {
                        targetRow = rightBoundary;
                        break;
                    }
                    else
                    {
                       return false; 
                    }
                }

                candidate = leftBoundary + (rightBoundary - leftBoundary) / 2;
                if (matrix[candidate][0] == target)
                {
                    return true;
                }
                else if (matrix[candidate][0] > target)
                {
                    rightBoundary = candidate;
                }
                else if (matrix[candidate][0] < target)
                {
                    leftBoundary = candidate;
                }
            }

            var row = matrix[targetRow]; 
            leftBoundary = 0;
            rightBoundary = row.Length - 1;

            if (row.Length == 1)
            {
                return row[0] == target;
            }

            Console.WriteLine($"Target row {targetRow}");
            // step 2 search in row
            while (leftBoundary < rightBoundary)
            {
                if (leftBoundary + 1 == rightBoundary)
                {
                    if (row[leftBoundary] == target
                     || row[rightBoundary] == target)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                candidate = leftBoundary + (rightBoundary - leftBoundary) / 2;
                if (row[candidate] == target)
                {
                    return true;
                }
                else if (row[candidate] > target)
                {
                    rightBoundary = candidate;
                }
                else if (row[candidate] < target)
                {
                    leftBoundary = candidate;
                }
            }

            return false;
        }
    }
}