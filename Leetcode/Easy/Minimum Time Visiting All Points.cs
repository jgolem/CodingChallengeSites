using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class Minimum_Time_Visiting_All_Points
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
        }
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int result = 0;

            for (int i = 0; i < points.Length - 1; i++)
            {
                int x = Math.Abs(points[i][0] - points[i + 1][0]);
                int y = Math.Abs(points[i][1] - points[i + 1][1]);
                result += Math.Max(x, y);
            }

            return result;
        }
    
        private void TestEx1()
        {
            int[][] grid = { new[] { 1, 1 }, new[] { 3, 4 }, new[] {-1, 0 } };
            int result = MinTimeToVisitAllPoints(grid); // expected result = 7
        }

        private void TestEx2()
        {
            int[][] grid = { new[] { 3, 2 }, new[] { -2, 2 } };
            int result = MinTimeToVisitAllPoints(grid); // expected result = 5
        }
    }
}
