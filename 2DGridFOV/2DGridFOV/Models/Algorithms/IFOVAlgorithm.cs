using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGridFOV.Models.Algorithms
{
    public interface IFOVAlgorithm
    {
        /// <summary>
        /// Return the cases in the field of view
        /// </summary>
        /// <param name="startingCase"></param>
        /// <param name="grid"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public List<int[]> GetFOV(int[] startingCase, int[,] grid, int range, bool isDebugging);
    }
}
