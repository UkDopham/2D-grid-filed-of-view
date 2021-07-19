using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public abstract class BaseFOVAlgorithm
    {
        /// <summary>
        /// Get the cases in range
        /// </summary>
        /// <param name="startingCase"></param>
        /// <param name="grid"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        protected List<int[]> GetRange(int[] startingCase, int[,] grid, int range)
        {
            List<int[]> cases = new List<int[]>();
            for(int row = 0;
                row < grid.GetLength(0);
                row ++)
            {
                for (int column = 0;
                    column < grid.GetLength(1);
                    column ++)
                {
                    if(GetLength(startingCase, new int[] { row, column }) <= range)
                    {
                        cases.Add(new int[] { row, column });
                    }
                }
            }
            return cases;
        }
        /// <summary>
        /// Distance between two points on the Cartesian plane
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double GetLength(int[] a, int[] b)
        {
            return Math.Sqrt(Math.Pow((a[0] - b[0]), 2) + Math.Pow((a[1] - b[1]), 2)); 
        }
    }
}
