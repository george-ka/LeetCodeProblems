using System;
using System.Collections.Generic;

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
            PrintList<int>(nums);
        }

        public static void PrintList<T>(this IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            
            Console.WriteLine();
        }
    }
}