using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public class Bresenham : BaseFOVAlgorithm, IFOVAlgorithm
    {
        private const float step = 0.5f;
        public List<int[]> GetFOV(int[] startingCase, int[,] grid, int range, bool isDebugging)
        {
            List<int[]> inFOVCases = new List<int[]>();
            List<int[]> inRangeCases = GetRange(startingCase, grid, range);
            List<int[]> positions = new List<int[]>();

            foreach (int[] inRangeCase in inRangeCases)
            {
                grid[inRangeCase[0], inRangeCase[1]] = grid[inRangeCase[0], inRangeCase[1]] != (int)Case.block ? (int)Case.range : (int)Case.block;
                positions = DrawLine(startingCase, inRangeCase, inRangeCases, isDebugging);
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
        private List<int[]> DrawLine(int[] a, int[] b, List<int[]> inRangeCases, bool isDebugging)
        {
            List<int[]> positions = new List<int[]>();
            int[] max = null;
            int[] min = null;
            if (a[0] == b[0]) // equation not possible 
            {
                max = a[1] < b[1] ? b : a;
                min = a[1] < b[1] ? a : b;

                if (isDebugging)
                {
                    Console.WriteLine($"line from ({min[0]};{min[1]}) to ({max[0]};{max[1]})");
                }
                for (float i = min[1];
                i <= max[1];
                i += step)
                {
                    if (isDebugging)
                    {
                        Console.WriteLine($"new pos ({a[0]};{i})");
                    }
                    positions.Add(new int[] { a[0], (int)i });
                }
            }
            else
            {
                max = a[0] < b[0] ? b : a;
                min = a[0] < b[0] ? a : b;
                Equation equation = new Equation(min, max);
                if (isDebugging)
                {
                    Console.WriteLine($"{equation} from ({min[0]};{min[1]}) to ({max[0]};{max[1]})");
                }
                for (float i = min[0];
                    i <= max[0];
                    i += step)
                {
                    int y = equation.GetYValue(i);
                    int[] position = GetNearest(inRangeCases, new float[] {i, y });
                    if (isDebugging)
                    {
                        Console.WriteLine($"new pos : ({position[0]};{position[1]})");
                    }
                    positions.Add(position);
                }
            }
            
            return positions;
        }
        /// <summary>
        /// Get the nearest case
        /// </summary>
        /// <param name="inRangeCases"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int[] GetNearest(List<int[]> inRangeCases, float[] pos)
        {
            int[] nearest = null;
            double nearestRange = double.MaxValue;
            foreach(int[] inRangeCase in inRangeCases)
            {
                double range = GetLength(inRangeCase, pos);
                if(nearestRange > range)
                {
                    nearest = inRangeCase;
                    nearestRange = range;
                }
            }
            return nearest;
        }
        /// <summary>
        /// Return if all of the case in the path are availables
        /// </summary>
        /// <param name="availableCases"></param>
        /// <returns></returns>
        private bool IsPossible(List<int[]> availableCases, int[,] matrix)
        {
            bool isPossible = matrix[availableCases[0][0], availableCases[0][1]] != (int)Case.block;
            for (int i = 1;
                i < availableCases.Count;
                i ++)
            {
                if (matrix[availableCases[i][0], availableCases[i][1]] == (int)Case.block)
                {
                    isPossible = false;
                    break;
                }                
            }
            return isPossible;
        }
    }
}
