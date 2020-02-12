using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class Check_If_a_Number_Is_Majority_Element_in_a_Sorted_Array
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
        }

        public bool IsMajorityElement(int[] nums, int target)
        {
            int majorityCountNeeded = nums.Length / 2;

            // get a location of the target value in the array if it exists
            int targetIndex = GetTargetIndex(nums, target);

            // target value doesn't exist in the array
            if (targetIndex == -1) return false;

            // how many of the target values have been found
            int targetCount = 1;

            int index = targetIndex;

            // count the target values to the right in the array
            while (++index < nums.Length)
            {
                if (nums[index] != target) break;
                targetCount++;
                if (targetCount > majorityCountNeeded) return true;
            }

            // reset the index to the original point
            index = targetIndex;

            // count the target values to the left in the array
            while (--index >= 0)
            {
                if (nums[index] != target) break;
                targetCount++;
                if (targetCount > majorityCountNeeded) return true;
            }

            if (targetCount > nums.Length / 2) return true;

            return false;
        }

        private void TestEx1()
        {
            int[] nums = {2, 4, 5, 5, 5, 5, 5, 6, 6};
            bool result = IsMajorityElement(nums, 5); // expected result = true
        }

        private void TestEx2()
        {
            int[] nums = { 10, 100, 101, 101 };
            bool result = IsMajorityElement(nums, 4); // expected result = false
        }

        private int GetTargetIndex(int[] nums, int target)
        {
            int minNum = 0;
            int maxNum = nums.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (target == nums[mid])
                {
                    return ++mid;
                }
                else if (target < nums[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }

            return -1;
        }
    }
}
