using System;
using System.Collections.Generic;
using LeetCodeChallenges.DataStructures;

namespace LeetCodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var soluton = new KLargestArrayElements();
            //Func<int[]> assign = () => { return new int[] {13, 4, 1, 5, 6, 77, 9, 9, 12, 19, 53, 0}; };
            //Func<int[]> assign = () => { return new int[] {3,2,3,1,2,4,5,5,6}; };
            Func<int[]> assign = () => { return new int[] {21, 20, 21}; };
            //Func<int[]> assign = () => { return new int[] {-1, 2, 0}; };
            var nums = assign();
            
            // {3,2,3,1,2,4,5,5,6};//{ 13, 4, 1, 5, 6, 77, 9, 9, 12, 19, 53, 0 };// { -1, 2, 0 };

            for (var k = 0; k < nums.Length; k++)
            {
                nums = assign();
                var result = soluton.QuickSelect(nums, k);
                PrintArray(nums);
                Console.WriteLine($"{k}th biggest is {result} ");
                Console.ReadLine();
            }
        }

        static void PrintArray(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            
            Console.WriteLine();
        }
    }
}
