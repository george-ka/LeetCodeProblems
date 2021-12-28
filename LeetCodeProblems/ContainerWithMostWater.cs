using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 11. Container With Most Water
    /// https://leetcode.com/problems/container-with-most-water/
    /// 
    /// You are given an integer array height of length n. 
    /// There are n vertical lines drawn such that the two endpoints 
    /// of the ith line are (i, 0) and (i, height[i]).
    ///
    /// Find two lines that together with the x-axis form a container, 
    /// such that the container contains the most water.
    /// Return the maximum amount of water a container can store.
    /// Notice that you may not slant (rotate) the container.
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height) 
        {
            /// An N^2 approach is to find area beween all bars
            ///
            ///             | |
            ///       |     | |
            /// |_____|_____|_|____________|
            /// The idea here is that there may be two highest bars,
            /// Max area is between the first and last small bars
            /// 
            /// Using two pointers we can skip checking all the bars 
            /// When we realize, that the area decreases even if we 
            /// find a bar with the same height as the right one

            /// Edge cases
            if (height == null)
            {
                throw new ArgumentNullException(nameof(height));
            }

            if (height.Length == 0 || height.Length == 1)
            {
                return 0;
            }

            if (height.Length == 2)
            {
                return GetArea(height, 0, 1);
            }

            var left = 0;
            var right = height.Length - 1;

            var maxArea = 0;
            var currentArea = 0;
            while (left < right)
            {
                currentArea = GetArea(height, left, right);
                if (currentArea > maxArea)
                {
                    Console.WriteLine($"New max {currentArea}, l {left}, r {right}, hl {height[left]}, hr {height[right]}");
                    maxArea = currentArea;
                }

                if (height[left] > height[right])
                {
                    right -= 1;
                }
                else if (height[left] < height[right])
                {
                    left += 1;
                }
                else
                {
                    // todo
                    left+=1;
                }
            }

            return maxArea;
        }

        private int GetArea(int[] heights, int left, int right)
        {
            return (right - left) * Math.Min(heights[left], heights[right]);;
        }
    }
}