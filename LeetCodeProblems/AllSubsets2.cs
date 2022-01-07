using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 90. Subsets II
    /// https://leetcode.com/problems/subsets-ii/
    /// WITH DUPLICATES
    /// 
    /// Given an integer array nums that may contain duplicates, return all possible subsets 
    /// (the power set).
    /// The solution set must not contain duplicate subsets. Return the solution in any order.
    public class AllSubsets2
    {
        // Starting from the 1st element add one by one next elements
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            
            if (nums.Length > 0)
            {
                result.AddRange(GenerateSubsets(nums, new List<int>(), 0));
                result.Add(new int[0]);
            }

            return result;
        }

        // [ 1 2 2 3]
        // [] - level 0
        // [1], [2], [2] (skip), [3] - level 1
        // [1 2], [1 2] (skip), [1 3] - level 2 for [1] 
        // [2 2], [2 3] - level 2 for [2]
        // skip level 2 for second [2]
        // level 2 for [3] - empty
        // [1 2 2] - level 3 for [1 2]
        // [1 2 3] - level 3 for [1 2]
        // skip next [1 2]
        // for [1 3] level 3 - empty
        // [2 2 3] - level 3 for [2 2]
        // for [2 3] level 3 - empty
        // [1 2 2 3] - level 4 for 1 2 2
        private IList<IList<int>> GenerateSubsets(int[] nums, List<int> currentList, int fromIndex)
        {
            var result = new List<IList<int>>();

            for (var i = fromIndex; i < nums.Length; i++)
            {
                if (i != fromIndex && nums[i-1] == nums[i])
                {
                    continue;
                }

                currentList.Add(nums[i]);
                result.Add(currentList.ToList());
                result.AddRange(GenerateSubsets(nums, currentList, i + 1));
                currentList.RemoveAt(currentList.Count - 1);
            }

            return result;
        }
    }
}