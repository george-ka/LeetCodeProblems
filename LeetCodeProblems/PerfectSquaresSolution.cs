using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 279. Perfect Squares
    /// https://leetcode.com/problems/perfect-squares/description/
    ///
    public class PerfectSquaresSolution
    {
        public int FindMinimalNumberOfSqaresWhichSumUpTo(int target)
        {
            // Strategy
            // 0. Check the input
            // 1. Find the trivial solution
            // 2. Try to optimize

            // 0^2 = 0
            // 1^2 = 1
            // 2^2 = 4
            // 3^2 = 9
            // 4^2 = 16

            if (target == 0 || target < 0)
            {
                throw new ArgumentException(nameof(target));
            }

            Cache = new Dictionary<int, List<int>>();
            var split = SplitToSumOfPerfectNumbers(target, 10000, 0);
            if (split == null)
            {
                return 0;
            }

            return split.Count;
        }
        
        private List<int> SplitToSumOfPerfectNumbers(int target, int minNumberOfElementsInTheSum, int currentNumberOfElements)
        {
            if (Cache.ContainsKey(target))
            {
                return Cache[target];
            }

            Console.WriteLine($"    Split {target} {minNumberOfElementsInTheSum} {currentNumberOfElements}");
            if (currentNumberOfElements >= minNumberOfElementsInTheSum)
            {
                return null;
            }

            var result = new List<int>();
            var closestSquareRoot = (int)Math.Floor(Math.Sqrt(target));
            var firstApproximation = closestSquareRoot * closestSquareRoot;
            Console.WriteLine($"    Approximation for {target} is {firstApproximation} current level {currentNumberOfElements}");
            if (firstApproximation == target)
            {
                result.Add(firstApproximation);
                return result;
            }

            List<int> currentSumElements = null;
            for (var i = closestSquareRoot; i > 0; i--)
            {
                currentSumElements = new List<int>();
                var currentSumm = i*i;

                // breaking here because there would be more elements in the sum, than current min
                if (target / currentSumm > minNumberOfElementsInTheSum)
                {
                    Console.WriteLine($"    Break at i = {i} cause {target/currentSumm} > {minNumberOfElementsInTheSum}");
                    break;
                }
                Console.WriteLine($"    Current summ = {currentSumm}, i = {i}");
                currentSumElements.Add(currentSumm);

                var remainingSum = SplitToSumOfPerfectNumbers(
                    target - currentSumm, 
                    minNumberOfElementsInTheSum, 
                    currentNumberOfElements + 1);

                if (remainingSum == null)
                {
                    continue;
                }

                currentSumElements.AddRange(remainingSum);
                Console.WriteLine($"    Subresult for {target}:" + string.Join(",", currentSumElements.ToArray()));
                if (currentSumElements.Count == 2)
                {
                    Cache[target] = currentSumElements;
                    return currentSumElements;
                }
                
                if (currentSumElements.Count < minNumberOfElementsInTheSum)
                {
                    result = currentSumElements.Select(x => x).ToList();
                    minNumberOfElementsInTheSum = currentSumElements.Count;
                    
                    Console.WriteLine($"    New min for {target} is {minNumberOfElementsInTheSum} " + string.Join(",", currentSumElements.ToArray()));
                }
            }

            if (result.Sum() == target)
            {
                Cache[target] = result;
                return result;
            }
            else
            {
                return null;
            } 
        }

        private Dictionary<int, List<int>> Cache;
    }
}