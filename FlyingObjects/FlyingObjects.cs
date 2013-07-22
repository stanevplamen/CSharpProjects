using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

struct Car
{
    public int x;
    public int y;
    public string str;
    public ConsoleColor color;
}

struct Rock
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;

}

class FlyingObjects
{

    static void PrintCarOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void PrintObjectOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string label, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(label);
    }

    static void Main(string[] args)
    {
        int points = 0;
        int livesCount = 5;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Car userCar = new Car();
        userCar.x = Console.WindowWidth / 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.str = "(O)";
        userCar.color = ConsoleColor.Yellow;
        Random randomGenerator = new Random();
        List<Rock> rocks = new List<Rock>();

        while (true)
        {
            bool hitted = false;
            {
                Rock newRocks = new Rock();
                newRocks.color = ConsoleColor.Green; // трябва да е рамдом
                newRocks.x = randomGenerator.Next(0, Console.WindowWidth);
                newRocks.y = 2;
                newRocks.c = '#'; // трябват повече символи
               
                //for (int i = 0; i < charArray.Length; i++)
                //{
                //    newRocks.c = charArray[i];
                //}

                rocks.Add(newRocks);
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x-1>=0)
                    {
                        userCar.x = userCar.x - 1;
                    }
                }

                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x+3< Console.WindowWidth)
                    {
                        userCar.x = userCar.x + 1;
                    }
                }

            }

            List<Rock> NewList = new List<Rock>();
            char[] charArray = { '!', '@', '#', '$', '%', '^', '&', '*', '+', '+', '!', '+', '#', '$', '%', '^', '+', '+', '.', '+', '!', '@', '#', '$', '%', '^', '&', '*', '.', ';', '!', '@', '#', '$', '%', '^', '&', '*', '.', ';' };
            var random = new Random();

            for (int i = 0; i < rocks.Count; i++)
            {          
                Rock oldRock = rocks[i];
                Rock newRock = new Rock();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = charArray[i];
                //newRock.color = oldRock.color;
                for (var f = 0; f < charArray.Length; f++)
                {
                    newRock.color = (ConsoleColor)random.Next((int)ConsoleColor.Black, (int)ConsoleColor.Yellow);                    
                }

                if (newRock.y == userCar.y && newRock.x == (userCar.x+1))
                {
                    livesCount--;
                    hitted = true;
                    if (livesCount < 0)
                    {
                        PrintStringOnPosition(8, 2, "Game Over!!!", ConsoleColor.Red);
                        PrintStringOnPosition(8, 3, "Your points are: " + points/100, ConsoleColor.Red);
                        PrintStringOnPosition(8, 4, "", ConsoleColor.Red);
                        Environment.Exit(0);
                    }
                }

                if (newRock.y < Console.WindowHeight)
                {
                    NewList.Add(newRock);
                    points++;
                }
            }
            rocks = NewList;
            Console.Clear();

            if (hitted == true)
            {
                rocks.Clear();
            }
            else
            {
                PrintCarOnPosition(userCar.x, userCar.y, userCar.str, userCar.color);
            }
            foreach (Rock rock in rocks)
            {
                PrintObjectOnPosition(rock.x, rock.y, rock.c, rock.color);
            }

            PrintStringOnPosition(8, 1, "Lives:" + livesCount, ConsoleColor.White);

            Thread.Sleep(150);
        }
    }
}

