using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public class Bresenham : BaseFOVAlgorithm, IFOVAlgorithm
    {
        private const int step = 1;
        public List<int[]> GetFOV(int[] startingCase, int[,] grid, int range)
        {
            List<int[]> inFOVCases = new List<int[]>();
            List<int[]> inRangeCases = GetRange(startingCase, grid, range);
            List<int[]> positions = new List<int[]>();

            foreach (int[] inRangeCase in inRangeCases)
            {
                grid[inRangeCase[0], inRangeCase[1]] = grid[inRangeCase[0], inRangeCase[1]] != 9 ? 2 : 9;
                positions = DrawLine(startingCase, inRangeCase);
                if(IsPossible(positions, grid))
                {
                    inFOVCases.Add(inRangeCase);
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
            int[] max = null;
            int[] min = null;
            if (a[0] == b[0]) // equation not possible 
            {
                max = a[1] < b[1] ? b : a;
                min = a[1] < b[1] ? a : b;

                Console.WriteLine($"line from ({min[0]};{min[1]}) to ({max[0]};{max[1]})");
                for (int i = min[1];
                i <= max[1];
                i += step)
                {
                    Console.WriteLine($"new pos ({a[0]};{i})");
                    positions.Add(new int[] { a[0], i });
                }
            }
            else
            {
                max = a[0] < b[0] ? b : a;
                min = a[0] < b[0] ? a : b;
                Equation equation = new Equation(min, max);
                Console.WriteLine($"{equation} from ({min[0]};{min[1]}) to ({max[0]};{max[1]})");
                for (int i = min[0];
                    i <= max[0];
                    i += step)
                {
                    Console.WriteLine($"new pos ({i};{equation.GetYValue(i)})");
                    positions.Add(new int[] { i, equation.GetYValue(i) });
                }
            }
            
            return positions;
        }

        /// <summary>
        /// Return if all of the case in the path are availables
        /// </summary>
        /// <param name="availableCases"></param>
        /// <returns></returns>
        private bool IsPossible(List<int[]> availableCases, int[,] matrix)
        {
            return availableCases.Where(x => matrix[x[0],x[1]] == 9).Count() == 0;
        }
    }
}
