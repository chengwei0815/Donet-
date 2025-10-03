using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 4. Two Sum
 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

●	You may assume that each input would have exactly one solution.

●	You may not use the same element twice.

●	You can return the answer in any order.
*/

namespace HW1
{
    public class TwoSum
    {
        //    static void Main(string[] args)
        //    {
        //        int[] nums = { 2, 7, 11, 15 };
        //        int target = 9;
        //        int[] result = TwoSum(nums, target);
        //        Console.WriteLine($"[{result[0]}, {result[1]}]");
        //    }
        //    static int[] TwoSum(int[] nums, int target)
        //    {
        //        for (int i = 0; i < nums.Length; i++)
        //        {
        //            for (int j = i + 1; j < nums.Length; j++)
        //            {
        //                if (nums[i] + nums[j] == target)
        //                {
        //                    return new int[] { i, j };
        //                }
        //            }
        //        }
        //        return new int[] { -1, -1 }; // Return -1, -1 if no solution is found
        //    }
        //}

        public static int[] FindTwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }
            return new int[] { -1, -1 };
        }
    }

    }
