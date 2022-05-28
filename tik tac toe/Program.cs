internal class Program
{
    #region Variables
        static string winner = "error";
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
        Console.Write("   1   2   3  x\n1  {0} | {1} | {2} \n  ---|---|---\n2  {3} | {4} | {5} \n  ---|---|---\n3  {6} | {7} | {8} \ny\n\n",field[0,0],field[0,1],field[0,2],field[1,0],field[1,1],field[1,2],field[2,0],field[2,1],field[2,2]);
    }

    static void GetPlayerInput()
    {
        bool xis = false;
        while (!xis)
        {
            Console.Write("x=");
            short.TryParse(Console.ReadLine(), out x);
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
            short.TryParse(Console.ReadLine(), out y);
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
    }
    
    static void Main(string[] args)
    {
        while (!ended)
        {
            Print();
            GetPlayerInput();
            if(field[y,x] == " ")
            {
                field[y, x] = "X";
                WinCheck();
                if (!ended)
                {
                    Print();
                    Thread.Sleep(1000);
                    BotPlay();
                    WinCheck();
                }
            }
            else
            {
                Console.WriteLine("choose empty field");
                Thread.Sleep(1000);
            }
        }
        Print();
        Console.WriteLine($"The winner is {winner}");
        Console.ReadKey();
    }
}