using System;

namespace LeetCodeChallenges
{
    public class ThreeSumClosestSolution
    {
        ///
        /// 16. 3Sum Closest
        /// https://leetcode.com/problems/3sum-closest/
        ///
        public int ThreeSumClosest(int[] nums, int target)
        {
            // firstly, sort the input array
            // secondly, find the index of the closest number from the left
            // subtract the number from target
            // repeat 3 times
            // if the sum is not equal to the target, return to the first index and move it left
            Array.Sort(nums);

            var leftIndex = 0;
            var rightIndex = nums.Length - 1;

            int? lastBestApproximation = null;
            int currentApproximation = 0;
            if (nums.Length < 3)
            {
                throw new ArgumentException("Invalid array");
            }

            for (var middleIndex = 1; middleIndex <= nums.Length - 2; middleIndex++)
            {
                if (middleIndex > 1 && nums[middleIndex] == nums[middleIndex - 1])
                {
                    continue;
                }
                
                leftIndex = 0;
                rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    currentApproximation = nums[leftIndex] + nums[rightIndex] + nums[middleIndex];
                    
                    if (lastBestApproximation == null
                    || Math.Abs(lastBestApproximation.Value - target) > Math.Abs(currentApproximation - target))
                    {
                        lastBestApproximation = currentApproximation;
                    }
                    
                    if (currentApproximation == target)
                    {
                        return currentApproximation;
                    }
                    else if (currentApproximation < target)
                    {
                        leftIndex++;
                        if (leftIndex == middleIndex)
                        {
                            leftIndex++;
                        }
                    }
                    else if (currentApproximation > target)
                    {
                        rightIndex--;
                        if (rightIndex == middleIndex)
                        {
                            rightIndex--;
                        }
                    }
                }
            }

            return lastBestApproximation.HasValue ? lastBestApproximation.Value : 0;
        }
    }
}