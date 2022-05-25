using System;
using System.Runtime.InteropServices;

internal class Program
{
    static void BotPlay()
    {
        bool botis = false;
        while (!botis)
        {
            botX = r.Next(0, 2);
            botY = r.Next(0, 2);
            if (field[botY, botX] == " ")
            {
                field[botY, botX] = "O";
                botis = true;
            }
        }
    }
    static void WinCheck()
    {
        Console.WriteLine("checked");
    }

    static void Print()
    {
        Console.Clear();
        Console.Write("   1   2   3  x\n1  {0} | {1} | {2} \n  ---|---|---\n2  {3} | {4} | {5} \n  ---|---|---\n3  {6} | {7} | {8} \ny\n\n",field[0,0],field[0,1],field[0,2],field[1,0],field[1,1],field[1,2],field[2,0],field[2,1],field[2,2]);
    }
    static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
    static int x;
    static int y;
    static int botX;
    static int botY;
    static bool ended = false;
    static Random r = new Random();
    static void Main(string[] args)
    {
        while (!ended)
        {
            Print();
            bool xis = false;
            while (!xis)
            {
                Console.Write("x=");
                x = Convert.ToInt16(Console.ReadLine());
                if (x > 0 && x < 4)
                {
                    x--;
                    xis = true;
                }
                else
                {
                    Console.WriteLine("choose x between 1 and 3");
                }
            }
            bool yis = false;
            while (!yis)
            {
                Console.Write("y=");
                y = Convert.ToInt16(Console.ReadLine());
                if (y > 0 && y < 4)
                {
                    y--;
                    yis = true;
                }
                else
                {
                    Console.WriteLine("choose y between 1 and 3");
                }
            }
            if(field[y,x] == " ")
            {
                field[y, x] = "X";
                WinCheck();
                if (!ended)
                {
                    Print();
                    Thread.Sleep(1500);
                    BotPlay();
                    WinCheck();
                }
            }
            else
            {
                Console.WriteLine("choose empty field");
                Console.ReadKey();
            }
        }
    }
}