using System;
using System.Runtime.InteropServices;

internal class Program
{
    static void Print()
    {
        Console.Clear();
        Console.Write("  {0} | {1} | {2} \n -----------\n  {3} | {4} | {5} \n -----------\n  {6} | {7} | {8} \n",field[0,0],field[0,1],field[0,2],field[1,0],field[1,1],field[1,2],field[2,0],field[2,1],field[2,2]);
    }
    static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
    static void Main(string[] args)
    {
        bool ended = false;
        while (!ended)
        {
            Print();
            bool xis = false;
            while (!xis)
            {
                Console.Write("x=");
                int x = Convert.ToInt16(Console.ReadLine());
                if (x > 0 && x < 4)
                {
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
                int x = Convert.ToInt16(Console.ReadLine());
                if (x > 0 && x < 4)
                {
                    yis = true;
                }
                else
                {
                    Console.WriteLine("choose y between 1 and 3");
                }
            }
        }
    }
}