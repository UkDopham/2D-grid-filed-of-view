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
            int[,] matrix = new int[10, 10];
            int range = 4;
            matrix[3, 4] = 9;
            matrix[4, 4] = 9;
            matrix[5, 4] = 9;

            matrix[1, 4] = 9;
            matrix[2, 4] = 9;
            List<int[]> possibleCases = bresenham.GetFOV(new int[] { 3, 3 }, matrix, range);
            matrix[3, 3] = 1;
            Console.WriteLine($"range : {range}");
            foreach(int[] possibleCase in possibleCases)
            {
                matrix[possibleCase[0], possibleCase[1]] *= -1;
            }
            PrettyPrint(matrix);
        }
        private static void PrettyPrint(int[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  ");
            for (int x = 0;
                x < matrix.GetLength(1);
                x++)
            {
                Console.Write($" {x} ");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            for (int y = 0;
            y < matrix.GetLength(0);
            y++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{y} ");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int x = 0;
                    x < matrix.GetLength(1);
                    x++)
                {
                    if (matrix[x, y] < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        if (matrix[x,y] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }

                    }
                    Console.Write($"{(matrix[x, y] < 0 ? $"{matrix[x, y]}" : $" {matrix[x, y]}")}|");
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
