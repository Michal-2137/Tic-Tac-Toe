using CompassModKit.Utilities.ConsoleUtil;

internal class Program
{
    #region Variables

        static string wintext = "";
        static string winner = "";
        private static bool[,] chose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static short x;
        static short y;
        static int botX;
        static int botY;
        static bool ended = false;
        static Random random = new Random();
    
    #endregion
    
    
    //With this function bot moves
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
        Print();
    }
    
    
    //This function checks if someone won
    static void WinCheck()
    {
        void end()
        {
            wintext = $"the winner is {winner}!";
            ended = true;
        }

        for (int i = 0; i < 2; i++)
        {
            if (field[i,0] == field[i,1] && field[i,0] == field[i,2] && field[i,0] != " ")
            {
                winner = field[i, 0];
                end();
            }
            if (field[0,i] == field[1,i] && field[0,i] == field[2,i] && field[0,i] != " ")
            {
                winner = field[0, i];
                end();
            }
        }
        if (field[0,0] == field[1,1] && field[0,0] == field[2,2] && field[0,0] != " ")
        {
            winner = field[0, 0];
            end();
        }

        if (field[0,2] == field[1,1] && field[0,2] == field[2,0] && field[0,2] != " ")
        {
            winner = field[0, 2];
            end();
        }
        
        if (!ended)
        {
            bool draw = true;
            foreach (string f in field)
            {
                if (f == " ")
                {
                    draw = false;
                }
            }
            if (draw)
            {
                wintext = "Draw!";
                ended = true;
            }
        }
    }

    
    //This function prints board
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
        Console.WriteLine(wintext);
    }

    
    //This function let player move
    static void PlayerMove(string sign)
    {
        bool choosen = false;
        bool placed = false;
        short choseX = 0;
        short choseY = 0;
        while (!placed)
        {
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
                    case ConsoleKey.Enter:
                        x = choseX;
                        y = choseY;
                        choosen = true;
                        break;
                }
            }
            chose[choseY, choseX] = false;
            if (field[y, x] == " ")
            {
                field[y, x] = sign;
                placed = true;
            }
            else
            {
                Console.WriteLine("choose empty field");
            }
            Print();
        }
    }

    
    static void Main(string[] args)
    {
        while (!ended)
        {
            PlayerMove("X");
            WinCheck();
            if (!ended) {
                Thread.Sleep(1000); 
                BotPlay(); 
                WinCheck();
            }
        }
        Print();
        Console.ReadKey();
    }
}