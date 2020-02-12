using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class MajorityElement
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
        }

        public int GetMajorityElement(int[] nums)
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
                    elementCount.Add(num,1);
                }
            }

            return elementCount.OrderByDescending(i => i.Value).First().Key;
        }

        private void TestEx1()
        {
            int[] nums = { 3, 2, 3 };
            int result = GetMajorityElement(nums); // expected result = 3
        }

        private void TestEx2()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int result = GetMajorityElement(nums); // expected result = 2
        }
    }
}
