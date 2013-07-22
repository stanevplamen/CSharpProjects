using System;
using System.Collections.Generic;

namespace BreadthFirstSearchExample
{
    class BFSExample 
    {
        class Point
        {
            public int xCoordinate { get; set; }
            public int yCoordinate { get; set; }

            public Point(int x, int y)
            {
                xCoordinate = x;
                yCoordinate = y;
            }
        }

        static char[,] matrix = new char[7, 7]
        {
            {' ',' ',' ','X','X','X','S'},
            {' ','X',' ',' ',' ','X',' '},
            {' ','X',' ','X','X','X',' '},
            {' ','X',' ',' ',' ',' ',' '},
            {' ','X',' ','X','X','X',' '},
            {' ','X','X','X','X','X',' '},
            {'E',' ',' ',' ',' ',' ',' '},
        };

        static void BFS(Point startPoint)
        {
            Queue<Point> matrixPoints = new Queue<Point>();
            matrixPoints.Enqueue(startPoint);
            while (true)
            {
                Point currentPoint = matrixPoints.Dequeue();
                if (currentPoint.xCoordinate - 1 >= 0)
                {
                    if (matrix[currentPoint.xCoordinate - 1, currentPoint.yCoordinate] == 'E')
                    {
                        Console.WriteLine("We have found the shortest exit");
                        return;
                    }
                    if (matrix[currentPoint.xCoordinate - 1, currentPoint.yCoordinate] == ' ')
                    {
                        matrix[currentPoint.xCoordinate - 1, currentPoint.yCoordinate] = '*';
                        matrixPoints.Enqueue(new Point(currentPoint.xCoordinate - 1, currentPoint.yCoordinate));
                    }
                }
                if (currentPoint.xCoordinate + 1 < matrix.GetLength(0))
                {
                    if (matrix[currentPoint.xCoordinate + 1, currentPoint.yCoordinate] == 'E')
                    {
                        Console.WriteLine("We have found the shortest exit");
                        return;
                    }
                    if (matrix[currentPoint.xCoordinate + 1, currentPoint.yCoordinate] == ' ')
                    {
                        matrix[currentPoint.xCoordinate + 1, currentPoint.yCoordinate] = '*';
                        matrixPoints.Enqueue(new Point(currentPoint.xCoordinate + 1, currentPoint.yCoordinate));
                    }
                }
                if (currentPoint.yCoordinate + 1 < matrix.GetLength(0)) 
                { 
                    if (matrix[currentPoint.xCoordinate, currentPoint.yCoordinate + 1] == 'E') 
                    {
                        Console.WriteLine("We have found the shortest exit"); 
                        return; 
                    }
                    if (matrix[currentPoint.xCoordinate, currentPoint.yCoordinate + 1] == ' ') 
                    { 
                        matrix[currentPoint.xCoordinate, currentPoint.yCoordinate + 1] = '*'; 
                        matrixPoints.Enqueue(new Point(currentPoint.xCoordinate, currentPoint.yCoordinate + 1)); 
                    } 
                } 
                if (currentPoint.yCoordinate - 1 >= 0)
                {
                    if (matrix[currentPoint.xCoordinate, currentPoint.yCoordinate - 1] == 'E')
                    {
                        Console.WriteLine("We have found the shortest exit");
                        return;
                    }
                    if (matrix[currentPoint.xCoordinate, currentPoint.yCoordinate - 1] == ' ')
                    {
                        matrix[currentPoint.xCoordinate, currentPoint.yCoordinate - 1] = '*';
                        matrixPoints.Enqueue(new Point(currentPoint.xCoordinate, currentPoint.yCoordinate - 1));
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                PrintMatrix();
            }
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
        }

        static void Main(string[] args)
        {
            Point startPoint = new Point(0, 6);
            BFS(startPoint);
        }
    }
}
