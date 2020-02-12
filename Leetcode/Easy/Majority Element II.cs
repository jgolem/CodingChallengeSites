using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class Majority_Element_II
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
        }

        public int[] MajorityElement(int[] nums)
        {
            Dictionary<int, int> elementCount = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (elementCount.ContainsKey(num))
                {
                    elementCount[num]++;
                }
                else
                {
                    elementCount.Add(num, 1);
                }
            }

            int oneThird = nums.Length / 3;
            List<int> results = new List<int>();

            foreach (KeyValuePair<int, int> keyValuePair in elementCount.OrderBy(i => i.Value))
            {
                if(keyValuePair.Value > oneThird) results.Add(keyValuePair.Key);
            }

            return results.ToArray();
        }

        private void TestEx1()
        {
            int[] nums = { 3, 2, 3 };
            int[] result = MajorityElement(nums); // expected result = 3
        }

        private void TestEx2()
        {
            int[] nums = { 1, 1, 1, 3, 3, 2, 2, 2 };
            int[] result = MajorityElement(nums); // expected result = 2
        }
    }
}
