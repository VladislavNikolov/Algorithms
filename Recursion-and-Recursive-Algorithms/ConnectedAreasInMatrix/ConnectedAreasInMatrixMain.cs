// You can use the Inputs.txt inside this project for console input.
// '-' charactes have been used instead of ' ' for better visual representation.

namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedAreasInMatrixMain
    {
        private static int matrixRows;
        private static int matrixCols;
        private static char[][] matrix;
        private static int connectedAreaSize;
        private static SortedSet<ConnectedArea> areasFound = new SortedSet<ConnectedArea>();

        public static void Main()
        {
            Console.WriteLine("Enter number of rows:");
            matrixRows = int.Parse(Console.ReadLine());
            matrix = new char[matrixRows][];
            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            matrixCols = matrix[0].Length;

            FindAreaStart();

            Console.WriteLine("Total areas found: {0}", areasFound.Count);
            int areaNumber = 0;
            foreach (ConnectedArea area in areasFound.Reverse())
            {
                areaNumber++;
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", areaNumber, area.FirstRow, area.FirstCol, area.Size);
            }
        }

        private static void FindAreaStart()
        {
            bool areaFound;
            do
            {
                areaFound = false;
                for (int row = 0; row < matrixRows; row++)
                {
                    if (areaFound)
                    {
                        break;
                    }

                    for (int col = 0; col < matrixCols; col++)
                    {
                        if (matrix[row][col] == '-' || matrix[row][col] == ' ')
                        {
                            areaFound = true;
                            connectedAreaSize = 0;
                            FindConnecedArea(row, col);
                            areasFound.Add(new ConnectedArea(row, col, connectedAreaSize));
                            break;
                        }
                    }
                }
            } while (areaFound);
        }

        private static void FindConnecedArea(int row, int col)
        {
            if (IsOutOfBounds(row, col) || matrix[row][col] == '*')
            {
                return;
            }

            connectedAreaSize++;
            matrix[row][col] = '*'; // Cell visited
            FindConnecedArea(row, col + 1); // Right
            FindConnecedArea(row, col - 1); // Left
            FindConnecedArea(row - 1, col); // Up
            FindConnecedArea(row + 1, col); // Down
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
