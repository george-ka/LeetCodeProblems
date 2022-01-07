using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 78. Subsets
    /// https://leetcode.com/problems/subsets/
    /// 
    /// Given an integer array nums of unique elements, return all possible subsets (the power set).
    /// The solution set must not contain duplicate subsets. Return the solution in any order.
    public class AllSubsets
    {
        // we can remove elements from the set. Starting from the 
        // full set and ending with the empty
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            result.Add(nums);
            
            if (nums.Length > 0)
            {
                result.AddRange(RemoveOne(nums, 0));
                result.Add(new int[0]);
            }

            return result;
        }

        // since the items are unique we can remove one by one and then go into recursion
        // from index is an important index to start removal from.
        // it prevents duplicates in the result
        private IList<IList<int>> RemoveOne(int[] nums, int fromIndex)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 1)
            {
                return result;
            }

            for (var i = fromIndex; i < nums.Length; i++)
            {
                var subset = RemoveAt(nums, i); 
                result.Add(subset);
                result.AddRange(RemoveOne(subset, i));
            }

            return result;
        }

        private int[] RemoveAt(int[] nums, int indexToRemove)
        {
            var result = new int[nums.Length - 1];
            var j = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (i == indexToRemove)
                {
                    continue;
                }

                result[j] = nums[i];
                j++;
            }

            return result;
        }
    }
}