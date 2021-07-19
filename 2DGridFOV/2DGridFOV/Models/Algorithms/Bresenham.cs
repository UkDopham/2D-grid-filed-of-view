using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public class Bresenham : BaseFOVAlgorithm, IFOVAlgorithm
    {
        public List<int[]> GetFOV(int[] startingCase, int[,] grid, int range)
        {
            List<int[]> inFOVCases = new List<int[]>();
            List<int[]> inRangeCases = GetRange(startingCase, grid, range);
            List<int[]> positions = new List<int[]>();

            foreach (int[] inRangeCase in inRangeCases)
            {
                grid[inRangeCase[0], inRangeCase[1]] = 2;
                positions = DrawLine(startingCase, inRangeCase);
                if(IsPossible(positions, grid))
                {
                    foreach(int[] avaibleCase in positions)
                    {
                        if(!Contains(inFOVCases,avaibleCase)) 
                        {
                            inFOVCases.Add(avaibleCase);
                        }
                    }
                }
            }
            return inFOVCases;
        }
        /// <summary>
        /// Check if the item is already in the list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool Contains(List<int[]> list, int[] item)
        {
            bool contains = false;
            foreach(int[] listItem in list)
            {
                if (listItem[0] == item[0] && listItem[1] == item[1])
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        /// <summary>
        /// Return true if the point belong to the line
        /// </summary>
        /// <returns></returns>
        private bool Belong()
        {
            bool belong = false;

            return belong;
        }
        /// <summary>
        /// return the positions of the cases which composed a line between 2 cases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private List<int[]> DrawLine(int[] a, int[] b)
        {
            List<int[]> positions = new List<int[]>();
            float dy = b[1] - a[1];
            float dx = b[0] - a[0];
            float m = dy / dx;
            //int x = 0;
            //int y = 0;
            //float dx = Math.Abs(b[0] - a[0]);
            //float dy = Math.Abs(b[1] - a[1]);
            //float m = dx == 0 ? 0 : dy / dx;
            //Console.WriteLine($"m : {m} dx : {dx} dy : {dx}");
            //for (int i = 0;
            //    i < dx;
            //    i++)
            //{
            //    x = a[0] + i;
            //    y = (int)(a[1] + m * i);
            //    int[] newPosition = new int[] { x, y };
            //    Console.WriteLine($"new position : {newPosition[0]} {newPosition[1]} from {a[0]} {a[1]} to {b[0]} {b[1]}");
            //    positions.Add(newPosition);
            //}
            return positions;
        }

        /// <summary>
        /// Return if all of the case in the path are availables
        /// </summary>
        /// <param name="availableCases"></param>
        /// <returns></returns>
        private bool IsPossible(List<int[]> availableCases, int[,] matrix)
        {
            return availableCases.Where(x => matrix[x[0],x[1]] != 0).Count() == 0;
        }
    }
}
