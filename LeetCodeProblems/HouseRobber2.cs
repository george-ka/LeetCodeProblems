using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 213. House Robber II
    /// https://leetcode.com/problems/house-robber-ii/
    /// 
    /// You are a professional robber planning to rob houses along a street. 
    /// Each house has a certain amount of money stashed. All houses at this place are arranged 
    /// in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent
    /// houses have a security system connected, and it will automatically contact the police if two 
    /// adjacent houses were broken into on the same night.
    /// Given an integer array nums representing the amount of money of each house, return the maximum 
    /// amount of money you can rob tonight without alerting the police.
    public class HouseRobber2
    {
        public int Rob(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            var memo = new Dictionary<int, MaximizationResult>();
            var maxResultFrom0 = MaximizeFrom(0, nums, true, memo);
            var maxResultFrom1 = MaximizeFrom(1, nums, false, memo);

            return maxResultFrom0.Profit > maxResultFrom1.Profit ? maxResultFrom0.Profit : maxResultFrom1.Profit;
        }

        private MaximizationResult MaximizeFrom(int index, int[] nums, bool exceptLast, Dictionary<int, MaximizationResult> memo)
        {
            var key = index * (exceptLast ? -1 : 1);
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            if (index == nums.Length - 4 && exceptLast)
            {
                if (nums[index] + nums[index + 2] > nums[index + 1])
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { index + 2, index },
                        Profit = nums[index] + nums[index+2]
                    };
                }
                else
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { index + 1 },
                        Profit = nums[index+1]
                    };
                }

                return memo[key];
            }
            // if not except last then go to main iteration

            if (index == nums.Length - 3)
            {
                if (exceptLast)
                {
                    var maxIndex = nums[index] > nums[index + 1] ? index : index + 1;
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { maxIndex },
                        Profit = nums[maxIndex]
                    };
                }
                else
                {
                    if (nums[index] + nums[index + 2] > nums[index + 1])
                    {
                        memo[key] = new MaximizationResult
                        {
                            Path = new List<int> { index + 2, index },
                            Profit = nums[index + 2] + nums[index]
                        };
                    }
                    else
                    {
                        memo[key] = new MaximizationResult
                        {
                            Path = new List<int> { index + 1 },
                            Profit = nums[index + 1]
                        };
                    }
                }

                return memo[key];
            }

            if (index == nums.Length - 2)
            {
                if (exceptLast || nums[index] > nums[index + 1])
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { index },
                        Profit = nums[index]
                    };
                }
                else
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { index +1 },
                        Profit = nums[index + 1]
                    };
                }

                return memo[key];
            }
            
            if (index == nums.Length - 1)
            {
                if (exceptLast)
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int>(),
                        Profit = 0
                    };
                }
                else
                {
                    memo[key] = new MaximizationResult
                    {
                        Path = new List<int> { index },
                        Profit = nums[index]
                    };
                }

                return memo[key];
            }

            var result1 = MaximizeFrom(index + 2, nums, exceptLast, memo);
            var result2 = MaximizeFrom(index + 3, nums, exceptLast, memo);
            if (nums[index] + result1.Profit > nums[index + 1] + result2.Profit)
            {
                var path = result1.Path.ToList();
                path.Add(index);
                memo[key] = new MaximizationResult
                {
                    Path = path,
                    Profit = nums[index] + result1.Profit
                };
            }
            else
            {
                var path = result2.Path.ToList();
                path.Add(index);
                memo[key] = new MaximizationResult
                {
                    Path = path,
                    Profit = nums[index + 1] + result2.Profit
                };
            }

            return memo[key];
        }

        private class MaximizationResult
        {
            public int Profit { get; set; }

            public List<int> Path { get; set; }
        }
    }
}