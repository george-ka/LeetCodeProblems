using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 239. Sliding Window Maximum
    /// https://leetcode.com/problems/sliding-window-maximum/description/
    /// 
    /// This solution is based on deque
    /// Should be better than the first one
    /// I'm writing it myself to remember the idea behin it
    /// though I got a sneek pick on Solutions tab
    /// 
    public class SlidingWindowMaximum2
    {
        public int[] MaxSlidingWindow(int[] nums, int k) 
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            if (nums.Length < k)
            {
                throw new ArgumentException($"Nums length should be greater than {k}");
            }

            //  0 1 2 3 4 5
            // |1|2|3|4|5|6|
            // |1|2|          1
            //   |_|_|        2
            //     |_|_|      3
            //       |_|_|    4
            //         |_|_|  5
            // num.Length - k + 1
            var result = new int[nums.Length - k + 1];
            var resultIndex = 0;
            
            // keep only indices of elements in nums 
            // but compare using value of nums
            var deque = new LinkedList<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                while (deque.Count > 0 && deque.First.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                if (i + 1 >= k)
                {
                    result[resultIndex] = nums[deque.First.Value];
                    resultIndex += 1;
                }

                // Debugging logs
                // Console.WriteLine($"i = {i}");
                // var copy = new int[deque.Count];
                // deque.CopyTo(copy, 0);
                // Console.WriteLine(String.Join(",", copy));
                // Console.WriteLine(String.Join(",", result));
            }

            return result;
        }
    }
}