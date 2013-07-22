using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFSExample
{
    class DFSExample // проверава всички
    {
        static char[,] matrix = new char[7, 7]
        {
            {' ',' ',' ','X','X','X',' '},
            {' ','X',' ',' ',' ','X',' '},
            {' ','X',' ','X','X','X',' '},
            {' ','X',' ',' ',' ',' ',' '},
            {' ','X',' ','X','X','X',' '},
            {' ','X','X','X','X','X',' '},
            {'E',' ',' ',' ',' ',' ',' '},
        };

        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        Console.ForegroundColor = System.ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = System.ConsoleColor.White;
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == 'E')
            {
                PrintMatrix();
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = '*';
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down
            matrix[row, col] = ' ';
        }

        static void Main(string[] args)
        {
            FindPathToExit(0, 6);
        }
    }
}