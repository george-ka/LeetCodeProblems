using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeChallenges
{
    ///
    /// 47. Permutations II
    /// https://leetcode.com/problems/permutations-ii/
    /// WITH DUPLICATES
    /// 
    /// Given a collection of numbers, nums, that might contain duplicates, 
    /// return all possible unique permutations in any order.    
    public class Premutations2
    {
        // Heap's algorithm
        // https://en.wikipedia.org/wiki/Heap%27s_algorithm
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var set = new HashSet<string>();
            Array.Sort(nums);
            if (nums.Length > 1)
            {
                return GeneratePremutations(nums, nums.Length, set);
            }
            else
            {
                var result = new List<IList<int>>();
                result.Add(nums);
                return result;
            }
        }

        private IList<IList<int>> GeneratePremutations(int[] nums, int k, HashSet<string> set)
        {
            var result = new List<IList<int>>();
            if (k == 1)
            {
                var numsString = Stringify(nums); 
                if (!set.Contains(numsString))
                {
                    result.Add(nums.ToArray());
                    set.Add(numsString);
                }
                
                return result;
            }

            result.AddRange(GeneratePremutations(nums, k - 1, set));

            for (var i = 0; i < k - 1; i++)
            {
                if (k % 2 == 0)
                {
                    Swap(nums, i, k-1);
                }
                else
                {
                    Swap(nums, 0, k-1);
                }

                Console.WriteLine($"Add {i}, {k}");
                result.AddRange(GeneratePremutations(nums, k - 1, set));
            }

            return result;
        }

        private static string Stringify(int[] nums)
        {
            var stringBuilder = new System.Text.StringBuilder();
            for (var i = 0; i < nums.Length; i++)
            {
                stringBuilder.Append(nums[i]);
                stringBuilder.Append(",");
            }

            return stringBuilder.ToString();
        }

        public static void Swap<T>(T[] arr, int i, int j)
        {
            var buffer = arr[i];
            arr[i] = arr[j];
            arr[j] = buffer;
        }
    }
}