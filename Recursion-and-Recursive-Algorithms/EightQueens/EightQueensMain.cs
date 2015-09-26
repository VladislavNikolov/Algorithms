namespace EightQueens
{
    using System;
    using System.Collections.Generic;

    public class EightQueensMain
    {
        private const int Size = 8;
        private static int solutionsFound;
        private static bool[,] chessboard = new bool[Size, Size];
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);
            Console.WriteLine("Solutions found: {0}", solutionsFound);
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool positionOccupied =
                attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(col + row);
            return !positionOccupied;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    char charToPrint = chessboard[row, col] ? '*' : '-';
                    Console.Write(charToPrint);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            solutionsFound++;
        }
    }
}
