using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    public class QueensAttackingTheKing
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            if (queens == null || queens.Length > 63)
            {
                throw new ArgumentException("Not valid list of queens coordinate", nameof(queens));
            }

            if (king == null || king.Length != 2)
            {
                throw new ArgumentException("Not a valid coordinate for king", nameof(king));
            }

            // we have 8 strategies to find the queens: go to all possible directions
            // the strategy can be described as an increments for the coordinates 
            // direction0 left to right: y is the same, x is greater, closest x wins
            // direction1 right to left: y is the same, x is less, closest x wins
            // direction2 top to bottom: x is the same, y is greater, closest y wins
            // direction3 bottom to top: x is the same, y is lesser, closest y wins
            // direction4 diagonal queen's x and y are greater than king's
            // direction5 diagonal queen's x and y are less than king's
            // direction6 diagonal queen's x is greater, y is less than king's
            // direction7 diagonal queen's x is less, y is greater than king's
            var kingClosestQueens = new int[8][];
            var diagonals = GetKingDiagonals(king);
            
            for (var q = 0; q < queens.Length; q++)
            {
                var queen = queens[q];
                if (queen == null || queen.Length != 2)
                {
                    throw new ArgumentException();
                }

                if (!CanAttack(queen, king, diagonals))
                {
                    continue;
                }
                
                // direction0 left to right: y is the same, x is greater, closest x wins
                if (queen[0] > king[0] && queen[1] == king[1])
                {
                    kingClosestQueens[0] = ChooseClosest(kingClosestQueens[0], queen, king);
                }
                // direction1 right to left: y is the same, x is less, closest x wins
                else if (queen[0] < king[0] && queen[1] == king[1])
                {
                    kingClosestQueens[1] = ChooseClosest(kingClosestQueens[1], queen, king);
                }
                // direction2 top to bottom: x is the same, y is greater, closest y wins
                else if (queen[0] == king[0] && queen[1] > king[1])
                {
                    kingClosestQueens[2] = ChooseClosest(kingClosestQueens[2], queen, king);
                }
                // direction3 bottom to top: x is the same, y is lesser, closest y wins
                else if (queen[0] == king[0] && queen[1] < king[1])
                {
                    kingClosestQueens[3] = ChooseClosest(kingClosestQueens[3], queen, king);
                }
                // direction4 diagonal queen's x and y are greater than king's
                else if (queen[0] > king[0] && queen[1] > king[1])
                {
                    kingClosestQueens[4] = ChooseClosest(kingClosestQueens[4], queen, king);
                }
                // direction5 diagonal queen's x and y are less than king's
                else if (queen[0] < king[0] && queen[1] < king[1])
                {
                    kingClosestQueens[5] = ChooseClosest(kingClosestQueens[5], queen, king);
                }
                // direction6 diagonal queen's x is greater, y is less than king's
                else if (queen[0] > king[0] && queen[1] < king[1])
                {
                    kingClosestQueens[6] = ChooseClosest(kingClosestQueens[6], queen, king);
                }
                // direction7 diagonal queen's x is less, y is greater than king's
                else if (queen[0] < king[0] && queen[1] > king[1])
                {
                    kingClosestQueens[7] = ChooseClosest(kingClosestQueens[7], queen, king);
                }
            }

            return kingClosestQueens.Where(x => x != null).Select(x => (IList<int>)x).ToList();
        }
        
        private bool CanAttack(int[] queen, int[] king, int[] diagonals)
        {
            // x or y coords are the same  
            return queen[0] == king[0] 
                || queen[1] == king[1]
            // or coord are the same diagonal
                || queen[1] == queen[0] + diagonals[0]
                || queen[1] == diagonals[1] - queen[0];
        }
        
        private int[] ChooseClosest(int[] q1, int[] q2, int[] king)
        {
            if (q1 == null && q2 != null)
            {
                return q2;
            }
            else if (q2 == null)
            {
                throw new ArgumentException();
            }
            
            return (Math.Abs(king[0] - q1[0]) >= Math.Abs(king[0] - q2[0]) 
                && Math.Abs(king[1] - q1[1]) >= Math.Abs(king[1] - q2[1]))
            ? q2
            : q1;
        }
        
        private int[] GetKingDiagonals(int[] king)
        {
            // there are two diagonals
            // y = x + d1
            // y = d2 - x
            return new int[] { king[1] - king[0], king[1] + king[0] };        
        }
    }
}