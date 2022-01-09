using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 40. Combination Sum II
    /// https://leetcode.com/problems/combination-sum-ii/
    /// 
    /// Given a collection of candidate numbers (candidates) and a target number (target), 
    /// find all unique combinations in candidates where the candidate numbers sum to target.
    /// Each number in candidates may only be used once in the combination.
    /// Note: The solution set must not contain duplicate combinations.
    public class CombinationSum2Solution
    {
        public IList<IList<int>> CombinationSum2(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> toReturn = new List<IList<int>>();
            var result = GenerateSum(nums, target, 0)
                .Select(x => { var a = x.ToArray(); Array.Sort(a); return a; })
                .ToList();

            var skip = new HashSet<int>();
            for (var i = 0; i < result.Count; i++)
            {
                for (var j = i + 1; j < result.Count; j++)
                {
                    if (AreEqual(result[i], result[j]))
                    {
                        skip.Add(j);
                    }
                }

                if (!skip.Contains(i))
                {
                    toReturn.Add(result[i]);
                }
            }

            return toReturn;
        }

        private List<List<int>> GenerateSum(int[] nums, int target, int startFrom)
        {
            var result = new List<List<int>>();
            for (var i = startFrom; i < nums.Length; i++)
            {
                // since all nums and target are positive
                if (nums[i] > target)
                {
                    continue;
                }

                // that would be duplicate we'll find all possible sums with this number resursively
                if (i > startFrom && nums[i] == nums[i - 1])
                {
                    continue;
                }

                if (target == nums[i])
                {
                    result.Add(new List<int> { nums[i] });
                }
                else if (target - nums[i] > 0)
                {
                    // For 39. Combination Sum 
                    // https://leetcode.com/problems/combination-sum/
                    // go recursively from i
                    var subresult = GenerateSum(nums, target - nums[i], i + 1);
                    if (subresult.Count > 0)
                    {
                        foreach (var list in subresult)
                        {
                            list.Add(nums[i]);
                            result.Add(list);
                        }
                    }
                }
            }

            return result;
        }

        private static string Stringify(List<int> nums)
        {
            return string.Join(",", nums);
        }

        private static bool AreEqual(int[] arr1, int[] arr2)
        {
            if (arr1 == arr2)
            {
                return true;
            }

            if (arr1 == null || arr2 == null)
            {
                return false;
            }

            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (var i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}