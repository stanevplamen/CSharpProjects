using System;
using System.Collections.Generic;

class NeighborElements
{
    static int member = 0;
    static int counter = 0;
    static int currentNumber = 0;
    static char[,] matrix = new char[7, 7]
        {
            {' ',' ','X','X','X',' ','X'},
            {' ','X','X','X','X',' ','X'},
            {'X','X','X','X','X',' ','X'},
            {'X','X',' ','X','X','X','X'},
            {'X','X','X','X','X','X','X'},
            {'X','X','X','X','X','X','X'},
            {'X',' ',' ',' ','X','X','X'},
        };
    /* passable cells are ' ', not passable are 'X', 
     * when we pass throught a cell we put '*' whick means the cell is checked and we will no check it again */

    static void FindExit(int row, int col)
    {          
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1))
            || (row >= matrix.GetLength(0)))
        {
            // we are out of the matrix -> can't find a path
            return;
        }

        if (matrix[row, col] == 0)
        {
            // the current cell is not free -> can't find a path
            return;
        }
        currentNumber = matrix[row, col];
        // mark the current cell as visited
        matrix[row, col] = '*';
        // recursion to explore all possible directions
        if (col - 1 >= 0 && matrix[row, col - 1] == currentNumber)
        {
                FindExit(row, col - 1); // left
        }
        if (row - 1 >= 0 && matrix[row - 1, col] == currentNumber)
        {
            FindExit(row - 1, col); // up
        }
        if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == currentNumber)
        {
            FindExit(row, col + 1); // right
        }
        if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == currentNumber)
        {
            FindExit(row + 1, col); // down
        }

        counter++;
        return;
    }


    static void Main()
    {
        Console.ForegroundColor = System.ConsoleColor.White;
        int counterPrints = 0;
        int counterAll = 0;
        // we are making a loop recursion, but only if the current cell is passable

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] != 'X' && matrix[row, col] != '*')
                {
                    counter = 0;
                    member = matrix[row, col];
                    FindExit(row, col);
                    if (counter > 0)
                    {
                        counterPrints++;
                        Console.WriteLine("The  passable cells in the set {0} are/is {1}", counterPrints, counter);
                        PrintMatrix();
                        counterAll = counterAll + counter;
                    }
                }
            }
        }
        Console.WriteLine();
        Console.ForegroundColor = System.ConsoleColor.Yellow;
        Console.WriteLine("All the passable cells are {0}", counterAll);   
    }

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
}

