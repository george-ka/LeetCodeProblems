using System;

namespace LeetCodeChallenges
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] arr, int i, int j)
        {
            var buffer = arr[i];
            arr[i] = arr[j];
            arr[j] = buffer;
        }

        public static void PrintArray(this int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            
            Console.WriteLine();
        }
    }
}