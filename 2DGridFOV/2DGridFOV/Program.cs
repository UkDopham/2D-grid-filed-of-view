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
            bool isDebugging = true;
            int start = 5;
            Bresenham bresenham = new Bresenham();
            int size = 10;
            int maxRandom = size*2;
            int[,] matrix = new int[size, size];
            int range = 10;
            Random random = new Random();
            int n = random.Next(0, maxRandom);
            Console.WriteLine($" n :{n}");
            for (int i = 0;
                i < n;
                i ++)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                matrix[x, y] = x != start && y != start ? (int)Case.block : (int)Case.empty ;
            }
            List<int[]> possibleCases = bresenham.GetFOV(new int[] { start, start }, matrix, range, isDebugging);
            matrix[start, start] = (int)Case.player;
            Console.WriteLine($"range : {range}");
            foreach(int[] possibleCase in possibleCases)
            {
                matrix[possibleCase[0], possibleCase[1]] *= -1;
            }
            Console.WriteLine($"number of possible cases : {possibleCases.Count}");
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
                Console.Write($"{(x < 10 ? " " : "")} {x} ");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            for (int y = 0;
            y < matrix.GetLength(0);
            y++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{(y > 9 ? $"{y}" : $"{y} ")} ");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int x = 0;
                    x < matrix.GetLength(1);
                    x++)
                {
                    if (matrix[x, y] < 0)
                    {
                        if (matrix[x, y] == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                    }
                    else
                    {
                        if (matrix[x, y] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            if (matrix[x, y] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            }
                        }

                    }
                    Console.Write($"{(matrix[x, y] < 0 ? $"{matrix[x, y]}" : $" {matrix[x, y]}")}{(matrix[x, y] < 10 ? " " : "")}|" );
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                SimpleGrid();
                Console.ReadKey();
            }
        }
    }
}
