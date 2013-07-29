using System;

class EightQueenGame
{
    static int boardLength = 8;
    static int uniqueCounter = 0;

    static void Main()
    {
        SolveEightQueens(new bool[boardLength, boardLength], new int[boardLength, boardLength], 0);
        Console.WriteLine();
        Console.ForegroundColor = System.ConsoleColor.Yellow;
        Console.WriteLine("Total unique queen distribution {0}",uniqueCounter);
    }

    static void SolveEightQueens(bool[,] board, int[,] occupied, int columnIndex) // функция която разпределя цариците по дъската
    {
        // в една колона и един ред винаги имаме по една царица
        if (columnIndex == boardLength)
        {
            PrintMatrix(board);
            uniqueCounter++;
            return;
        }

        for (int rowIndex = 0; rowIndex < boardLength; rowIndex++)
        {
            if (occupied[rowIndex, columnIndex] == 0)
            {
                // поставяме царицата board[rowIndex, columnIndex];
                board[rowIndex, columnIndex] = true;
                // маркираме елементите които ще са false: където не да не можем да сложим нова царица
                MarkOccupied(occupied, 1, rowIndex, columnIndex);
                // извикваме рекурсивно да поставим нова царица, 
                SolveEightQueens(board, occupied, columnIndex + 1);
                // отново разрешаваме да ползваме даденото място
                board[rowIndex, columnIndex] = false;
                MarkOccupied(occupied, -1, rowIndex, columnIndex);
            }
        }
    }

    static void MarkOccupied(int[,] occupied, int value, int rowIndex, int columnIndex)
    {
        for (int rowcow = 0; rowcow < occupied.GetLength(0); rowcow++)
        {
            occupied[rowcow, columnIndex] = occupied[rowcow, columnIndex] + value;
            occupied[rowIndex, rowcow] = occupied[rowIndex, rowcow] + value;

            if (columnIndex + rowcow < occupied.GetLength(1) && rowIndex + rowcow < occupied.GetLength(0))
            {
                occupied[rowIndex + rowcow, columnIndex + rowcow] = occupied[rowIndex + rowcow, columnIndex + rowcow] + value;
            }
            if (columnIndex + rowcow < occupied.GetLength(1) && rowIndex - rowcow >= 0)
            {
                occupied[rowIndex - rowcow, columnIndex + rowcow] = occupied[rowIndex - rowcow, columnIndex + rowcow] + value;
            }
        }
    }

    static void PrintMatrix(bool[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == true)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    Console.Write("{0, -2}", 'Q');
                }
                else
                {
                    Console.ForegroundColor = System.ConsoleColor.White;
                    Console.Write("{0, -2}", 'X');
                }
                //Console.Write("{0, -6}", board[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

