using CompassModKit.Utilities.ConsoleUtil;

internal class Program
{
    #region Variables
        static string winner = "error";
        private static bool[,] chose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static short x;
        static short y;
        static int botX;
        static int botY;
        static bool ended = false;
        static Random random = new Random();
    
    #endregion
    
    static void BotPlay()
    {
        bool botis = false;
        while (!botis)
        {
            botX = random.Next(0, 3);
            botY = random.Next(0, 3);
            if (field[botY, botX] == " ")
            {
                field[botY, botX] = "O";
                botis = true;
            }
        }
    }
    static void WinCheck()
    {
        for (int i = 0; i < 2; i++)
        {
            if (field[i,0] == field[i,1] && field[i,0] == field[i,2] && field[i,0] != " ")
            {
                winner = field[i, 0];
                ended = true;
            }
            if (field[0,i] == field[1,i] && field[0,i] == field[2,i] && field[0,i] != " ")
            {
                winner = field[0, i];
                ended = true;
            }
        }
        if (field[0,0] == field[1,1] && field[0,0] == field[2,2] && field[0,0] != " ")
        {
            winner = field[0, 0];
            ended = true;
        }

        if (field[0,2] == field[1,1] && field[0,2] == field[2,0] && field[0,2] != " ")
        {
            winner = field[0, 2];
            ended = true;
        }
    }

    static void Print()
    {
        Console.Clear();
        Console.Write("  ");
        if (chose[0,0])
        {
            ConsoleUtil.Write(field[0,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,0]);
        }
        Console.Write(" | ");
        if (chose[0,1])
        {
            ConsoleUtil.Write(field[0,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,1]);
        }
        Console.Write(" | ");
        if (chose[0,2])
        {
            ConsoleUtil.Write(field[0,2], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (chose[1,0])
        {
            ConsoleUtil.Write(field[1,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,0]);
        }
        Console.Write(" | ");
        if (chose[1,1])
        {
            ConsoleUtil.Write(field[1,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,1]);
        }
        Console.Write(" | ");
        if (chose[1,2])
        {
            ConsoleUtil.Write(field[1,2], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (chose[2,0])
        {
            ConsoleUtil.Write(field[2,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[2,0]);
        }
        Console.Write(" | ");
        if (chose[2,1])
        {
            ConsoleUtil.Write(field[2,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[2,1]);
        }
        Console.Write(" | ");
        if (chose[2,2])
        {
            ConsoleUtil.Write(field[2,2], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[2,2]);
        }
        Console.Write(" \n\n");
    }

    static void GetPlayerInput()
    {
        bool choosen = false;
        short choseX = 0;
        short choseY = 0;
        while (!choosen)
        {
            chose[choseY, choseX] = true;
            Print();
            chose[choseY, choseX] = false;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (choseY > 0)
                    {
                        choseY--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (choseY < 2)
                    {
                        choseY++;
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (choseX > 0)
                    {
                        choseX--;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (choseX < 2)
                    {
                        choseX++;
                    }
                    break;
                case  ConsoleKey.Enter:
                    x = choseX;
                    y = choseY;
                    choosen = true;
                    break;
            }
        }
        chose[choseY, choseX] = false;
    }

    static bool PlaceXorO()
    {
        if (field[y, x] == " ")
        {
            field[y, x] = "X";
            return true;
        }
        else
        {
            Console.WriteLine("choose empty field");
            return false;
        }
    }
    
    static void Main(string[] args)
    {
        while (!ended)
        {
            Print();
            GetPlayerInput();
            if (PlaceXorO())
            {
                Print();
                Thread.Sleep(1000);
                WinCheck();
                BotPlay();
                WinCheck();
            }
            else
            {
                Thread.Sleep(1500);
            }
        }
        Print();
        Console.WriteLine($"The winner is {winner}");
        Console.ReadKey();
    }
}