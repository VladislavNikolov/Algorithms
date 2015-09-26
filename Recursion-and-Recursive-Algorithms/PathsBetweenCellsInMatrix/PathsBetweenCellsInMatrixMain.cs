// You can use the Inputs.txt inside this project for console input.
// '-' charactes have been used instead of ' ' for better visual representation.

namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PathsBetweenCellsInMatrixMain
    {
        private static char[][] matrix;
        private static int matrixRows;
        private static int matrixCols;
        private static int pathsFound;
        private static List<char> paths = new List<char>(); 

        public static void Main()
        {
            matrixRows = 5; // We can switch that value if we want;
            matrix = new char[5][];
            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            matrixCols = matrix[0].Length;
            Console.WriteLine();

            FindExit(0, 0, 'S'); // We assume that 's' is on 0, 0
            Console.WriteLine("Total paths found: {0}", pathsFound);
        }

        private static void FindExit(int row, int col, char direction)
        {
            if (IsOutOfBounds(row, col))
            {
                return;
            }

            if (matrix[row][col] == '*' || matrix[row][col] == 'x')
            {
                return;
            }

            if (matrix[row][col] == 'e')
            {
                paths.Add(direction);
                PrintPath(matrix);
                paths.Remove(paths.Last());
                Console.WriteLine();
                return;
            }

            matrix[row][col] = 'x';
            paths.Add(direction);

            FindExit(row, col + 1, 'R'); // Right
            FindExit(row, col - 1, 'L'); // Left
            FindExit(row + 1, col, 'D'); // Down
            FindExit(row - 1, col, 'U'); // Up

            matrix[row][col] = '-';
            paths.Remove(paths.Last());
        }

        private static void PrintPath(char[][] matrix)
        {
            pathsFound++;
            Console.WriteLine("Path #{0}:", pathsFound);
            Console.WriteLine(string.Join(string.Empty, paths));
            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsOutOfBounds(int row, int col)
        {
            if (row < 0 || row >= matrixRows || col < 0 || col >= matrixCols)
            {
                return true;
            }

            return false;
        }
    }
}
