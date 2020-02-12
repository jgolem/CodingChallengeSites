using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class Shift_2D_Grid
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
            TestEx3();
            TestLeetCodeEx();
        }

        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            IList<IList<int>> results = new List<IList<int>>();

            // strip any full rotations from k
            k = k % (grid.Length * grid[0].Length);

            if (k != 0)
            {
                RotateUsingStack(grid, k);
            }

            // put the results in the desired output format
            foreach (int[] row in grid)
            {
                results.Add(row.ToList());
            }

            return results;
        }

        private void RotateUsingStack(int[][] grid, int rotations)
        {
            Stack<int> stack = new Stack<int>();

            int rows = grid.Length;
            int cols = grid[0].Length;

            // Push each value in the grid on to a stack starting with the 0,0 position
            for (int i = 0; i < rows * cols; i++)
            {
                stack.Push(grid[i / grid[0].Length][i % grid[0].Length]);
            }

            // pop the values back to their expected destination 
            for (int i = rows * cols - 1 ; i >= 0; i--)
            {
                var newPosition = (i + rotations) % (rows * cols);
                grid[newPosition / grid[0].Length][newPosition % grid[0].Length] = stack.Pop();
            }
        }

        private void Rotate(int[][] grid, int rotations)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int[] newValues = new int[grid.Length * grid[0].Length];
            int valueReplaced = grid[0][0];
            for (int i = 0; i < rows * cols; i++)
            {
                XY original = new XY(i / rows, i % cols);
                int newPosition = i + rotations % (rows * cols);
                XY destination = new XY(newPosition / rows, newPosition % cols);
                valueReplaced = grid[destination.X][destination.Y];
                grid[destination.X][destination.Y] = valueReplaced;
            }
        }


        private void TestEx1()
        {
            int[][] grid = new int[3][] { new int[3]{1, 2, 3 }, new int[3] { 4,5,6 }, new int[3] { 7,8,9 } };
            IList<IList<int>> result = ShiftGrid(grid, 1); // expected result = [[9,1,2],[3,4,5],[6,7,8]]
        }

        private void TestEx2()
        {
            int[][] grid = new int[4][] { new int[4] { 3, 8, 1, 9 }, new int[4] { 19, 7, 2, 5 }, new int[4] { 4, 6, 11, 10 }, new int[4] { 12, 0, 21, 13 } };
            IList<IList<int>> result = ShiftGrid(grid, 4); // expected result = [[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]
        }

        private void TestLeetCodeEx()
        {
            int[][] grid = new int[7][] { new int[1] { 1 }, new int[1] {2 }, new int[1] { 3 }, new int[1] { 4 }, new int[1] { 7 }, new int[1] { 6 }, new int[1] { 5 } };
            IList<IList<int>> result = ShiftGrid(grid, 23); // expected result = [[6],[5],[1],[2],[3],[4],[7]]
        }

        class XY
        {
            public int X;
            public int Y;

            public XY()
            {

            }

            public XY(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private void TestEx3()
        {
            int[][] grid = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } };
            IList<IList<int>> result = ShiftGrid(grid, 9); // expected result = [[1,2,3],[4,5,6],[7,8,9]]
        }
    }
}
