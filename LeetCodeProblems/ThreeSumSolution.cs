using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 15. 3Sum
    /// https://leetcode.com/problems/3sum/
    ///
    /// Given an integer array nums, return all the triplets 
    /// [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, 
    /// and nums[i] + nums[j] + nums[k] == 0.
    /// Notice that the solution set must not contain duplicate triplets.
    ///
    /// Solution is far from optimal and is O(n^2) see ThreeSumClosest 
    /// solution for a smarter approach 
    ///
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums) 
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
         
            if (nums.Length < 3)
            {
                return result;
            }
            
            var resultHash = new HashSet<string>();
            var numsHash = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (numsHash.ContainsKey(nums[i]))
                {
                    numsHash[nums[i]]++;
                }
                else
                {
                    numsHash[nums[i]] = 1;
                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var triples = FindTwoSums(nums, numsHash, nums[i], i);
                foreach (var triple in triples)
                {
                    var sortedTripleString = ToSortedTripleString(triple);
                    if (!resultHash.Contains(sortedTripleString))
                    {
                        resultHash.Add(sortedTripleString);
                        result.Add(triple);
                    }
                }
            }

            return result;
        }

        private List<int[]> FindTwoSums(int[] nums, Dictionary<int, int> hashNums, int targetVal, int excludeIndex)
        {
            var result = new List<int[]>();
            for (var i = excludeIndex + 1; i < nums.Length; i++)
            {                
                var twoSum = nums[i] + targetVal;
                if (i < nums.Length - 2 && nums[i] + nums[i+1] + targetVal > 0)
                {
                    // early exit
                    break;
                }

                var negativeTwoSum = -1 * twoSum;
                if (hashNums.ContainsKey(negativeTwoSum))
                {
                    if (nums[excludeIndex] == negativeTwoSum)
                    {
                        if (nums[i] == negativeTwoSum)
                        {
                            if (hashNums[negativeTwoSum] < 3)
                            {
                                continue;
                            }
                        }
                        else if (hashNums[negativeTwoSum] < 2)
                        {
                            continue;
                        }
                    }

                    if (nums[i] == negativeTwoSum
                         && hashNums[negativeTwoSum] < 2)
                    {
                        continue;
                    }

                    result.Add(new int[] { targetVal, nums[i], -1 * twoSum });
                }
            }

            return result;
        }

        private string ToSortedTripleString(int[] triple)
        {
            Array.Sort(triple);
            return String.Join(",", triple);
        }
    }
}