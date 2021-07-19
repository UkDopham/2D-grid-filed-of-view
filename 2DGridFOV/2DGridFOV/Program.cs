using _2DGridFOV.Models;
using _2DGridFOV.Models.Algorithms;
using System;
using System.Collections.Generic;

namespace _2DGridFOV
{
    class Program
    {
        private static void SimpleGrid()
        {
            Bresenham bresenham = new Bresenham();
            int[,] matrix = new int[6, 6];
            int range = 2;
            List<int[]> possibleCases = bresenham.GetFOV(new int[] { 3, 3 }, matrix, range);
            matrix[3, 3] = 1;
            Console.WriteLine($"range : {range}");
            foreach(int[] possibleCase in possibleCases)
            {
                matrix[possibleCase[0], possibleCase[1]] *= -1;
            }
            Print(matrix);
        }
        private static void Print(int[,] matrix)
        {
            for(int x = 0;
                x < matrix.GetLength(0);
                x ++)
            {
                for (int y = 0;
                    y < matrix.GetLength(1);
                    y++)
                {
                    Console.Write($"{matrix[x, y]}|");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SimpleGrid();
        }
    }
}
