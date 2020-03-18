using System;

namespace LeetCodeChallenges
{
    public class RemoveDuplicates
    {
        public static void RemoveDuplicatesTest()
        {
            RunTest(new int[] { 1, 1, 2 });
            RunTest(new int[] { 0,0,1,1,1,2,2,3,3,4 });
            RunTest(new int[] { 0,0,1,1,1,1,2,3,3 });
            RunTest(new int[] { 1,2,2 });
            RunTest(new int[] { 1,1,1 });            
            RunTest(new int[] { 1,2,2,3 });            
        }

        private static void RunTest(int[] nums)
        {
            var result = RemoveTriplicates(nums);
            Console.WriteLine(result);
            PrintArray(nums);
            Console.WriteLine();
        }

        private static void PrintArray(int[] nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i);
                Console.Write(", ");
            }

            Console.WriteLine();
        }

        public static int RemoveTriplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            // setting up last number different than first
            var lastNumber = nums[0]+1;
            var numberOfElements = 0;
            var indexToAssignNextUniqueValue = 0;
            var duplicateMet = false;
            var i = 0;

            do 
            {
                if (nums[i] == lastNumber)
                {
                    if (!duplicateMet)
                    {
                        duplicateMet = true;
                        nums[indexToAssignNextUniqueValue] = nums[i];
                        numberOfElements++;
                        indexToAssignNextUniqueValue++;
                    }
                }
                else
                {
                    nums[indexToAssignNextUniqueValue] = nums[i];
                    lastNumber = nums[i];
                    indexToAssignNextUniqueValue ++;
                    numberOfElements++;
                    
                    duplicateMet = false;
                }

                i++;
            } while (i < nums.Length);

            return numberOfElements;
        }
    }
}