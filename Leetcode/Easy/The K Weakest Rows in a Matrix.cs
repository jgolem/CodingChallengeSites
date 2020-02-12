using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    class The_K_Weakest_Rows_in_a_Matrix
    {
        public void RunTests()
        {
            TestEx1();
            TestEx2();
            TestEx3();
        }


        public int[] KWeakestRows(int[][] mat, int k)
        {
            // store the rows by sum (total soldiers)
            Dictionary<int, List<int>> rowsBySoldiers = new Dictionary<int, List<int>>();
            int[] weakestRows = new int[k];

            // Add the rows to the dictionary by strength;
            for (var row = 0; row < mat.Length; row++)
            {
                int[] ints = mat[row];
                int sum = 0;
                foreach (int i in ints)
                {
                    if (i == 0) break;
                    sum += i;
                }

                if (rowsBySoldiers.ContainsKey(sum))
                {
                    rowsBySoldiers[sum].Add(row);
                }
                else
                {
                    List<int> newList = new List<int>();
                    newList.Add(row);
                    rowsBySoldiers.Add(sum, newList);
                }
            }

            int count = 0;
            // copy the proper number of row id's to the result. Weakest first;
            foreach (KeyValuePair<int, List<int>> keyValuePair in rowsBySoldiers.OrderBy(i => i.Key))
            {
                foreach (int i in keyValuePair.Value)
                {
                    weakestRows[count++] = i;
                    if (count >= k) return weakestRows;
                }

            }

            return weakestRows;
        }

        /// <summary>
        /// Gonna try to make it run faster
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRowsAgain(int[][] mat, int k)
        {
            // store the rows by sum (total soldiers)
            Dictionary<int, List<int>> rowsBySoldiers = new Dictionary<int, List<int>>();
            int[] weakestRows = new int[k];
            int[] usedRows = new int[mat.Length];

            int count = 0;
            for (int column = 0; column < mat[0].Length; column++)
            {
                for (int row = 0; row < mat.Length; row++)
                {
                    if (usedRows[row] == 1) continue;

                    if (mat[row][column] == 0)
                    {
                        usedRows[row] = 1;
                        weakestRows[count++] = row;
                        if (count >= k) return weakestRows;
                    }

                }
            }

            for (var index = 0; index < usedRows.Length; index++)
            {
                if (usedRows[index] == 0)
                {
                    weakestRows[count++] = index;
                    if (count >= k) return weakestRows;
                }
            }

            return weakestRows;
        }

        // this could be done with a priority queue
        // this could be done with min heap
        // this could be done with a 


        // Tests
        private void TestEx1()
        {
            int[][] mat = new int[5][];
            mat[0] = new[] { 1, 1, 0, 0, 0 };
            mat[1] = new[] { 1, 1, 1, 1, 0 };
            mat[2] = new[] { 1, 0, 0, 0, 0 };
            mat[3] = new[] { 1, 1, 0, 0, 0 };
            mat[4] = new[] { 1, 1, 1, 1, 1 };

            int[] result = KWeakestRows(mat, 3);
            result = KWeakestRowsAgain(mat, 3);
        }

        private void TestEx2()
        {
            int[][] mat = new int[4][];
            mat[0] = new[] { 1, 0, 0, 0 };
            mat[1] = new[] { 1, 1, 1, 1 };
            mat[2] = new[] { 1, 0, 0, 0 };
            mat[3] = new[] { 1, 0, 0, 0 };

            int[] result = KWeakestRows(mat, 2);
            result = KWeakestRowsAgain(mat, 2);
        }

        private void TestEx3()
        {
            int[][] mat = new int[4][];
            mat[0] = new[] { 1, 0 };
            mat[1] = new[] { 1, 0 };
            mat[2] = new[] { 1, 0 };
            mat[3] = new[] { 1, 1 };

            int[] result = KWeakestRows(mat, 4);
            result = KWeakestRowsAgain(mat, 4);
        }
    }
}
