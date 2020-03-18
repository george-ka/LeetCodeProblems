using System;

namespace LeetCodeChallenges
{
    public static class QueensAttackingTheKingTests 
    {
        public static void RunTests()
        {
            var qatk = new QueensAttackingTheKing();

            var queens = new int[][] { new[] { 0,1 }, new[] { 1, 0 }, new[] { 4,0 }, new[] { 0,4 }, new [] { 3,3 }, new [] {2,4} };
            var king = new[] { 0,0 };
            qatk.QueensAttacktheKing(queens, king);
        }
    }
}
