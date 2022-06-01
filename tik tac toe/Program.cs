using System.Net.Sockets;
using CompassModKit.Utilities.ConsoleUtil;

internal class Program
{
    #region Variables

        static string wintext = "";
        static string winner = "";
        private static bool[,] choose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static short x;
        static short y;
        static bool ended = false;
        static Random random = new Random();
        static short SelectedMode = 1;
    
    #endregion
    
    
    
    //This function prints board
    static void Print()
    {
        Console.Clear();
        Console.Write("  ");
        if (choose[0,0])
        {
            ConsoleUtil.Write(field[0,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,0]);
        }
        Console.Write(" | ");
        if (choose[0,1])
        {
            ConsoleUtil.Write(field[0,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,1]);
        }
        Console.Write(" | ");
        if (choose[0,2])
        {
            ConsoleUtil.Write(field[0,2], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[0,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (choose[1,0])
        {
            ConsoleUtil.Write(field[1,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,0]);
        }
        Console.Write(" | ");
        if (choose[1,1])
        {
            ConsoleUtil.Write(field[1,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,1]);
        }
        Console.Write(" | ");
        if (choose[1,2])
        {
            ConsoleUtil.Write(field[1,2], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[1,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (choose[2,0])
        {
            ConsoleUtil.Write(field[2,0], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[2,0]);
        }
        Console.Write(" | ");
        if (choose[2,1])
        {
            ConsoleUtil.Write(field[2,1], ConsoleColor.Black, ConsoleColor.White);
        }
        else
        {
            Console.Write(field[2,1]);
        }
        Console.Write(" | ");
        if (choose[2,2])
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
        bool placed = false;
        while (!placed)
        {
            short chooseX = 0;
            short chooseY = 0;
            bool choosen = false;
            while (!choosen)
            {
                choose[chooseY, chooseX] = true;
                Print();
                choose[chooseY, chooseX] = false;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (chooseY > 0)
                        {
                            chooseY--;
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (chooseY < 2)
                        {
                            chooseY++;
                        }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (chooseX > 0)
                        {
                            chooseX--;
                        }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (chooseX < 2)
                        {
                            chooseX++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        x = chooseX;
                        y = chooseY;
                        choosen = true;
                        break;
                }
            }
            choose[chooseY, chooseX] = false;
            if (field[y, x] == " ")
            {
                field[y, x] = sign;
                placed = true;
            }
            else
            {
                Console.WriteLine("choose empty field");
                Thread.Sleep(1000);
            }
            Print();
        }
    }
    
    
    //With this function bot on easy mode moves
    static void EasyBotMove()
    {
        Thread.Sleep(1000);
        int botX;
        int botY;
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
    
    
    //With this function bot on medium mode moves
    static void MediumBotMove()
    {
        int botX;
        int botY;
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
    
    
    //With this function bot on hard mode moves
    static void HardBotMove()
    {
        int botX;
        int botY;
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

    
    //This function chooses game mode
    static void ChooseGameMode()
    {
        bool end = false;
        while (!end)
        {
            Console.Clear();
            if (SelectedMode == 1)
            {
                ConsoleUtil.WriteLine("easy mode", ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("easy mode");
            }
            if (SelectedMode == 2)
            {
                ConsoleUtil.WriteLine("medium mode (not working)", ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("medium mode (not working)");
            }
            if (SelectedMode == 3)
            {
                ConsoleUtil.WriteLine("hard mode not working", ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("hard mode not working");
            }
            if (SelectedMode == 4)
            {
                ConsoleUtil.WriteLine("2 players mode", ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("2 players mode");
            }
            
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (SelectedMode > 1)
                    {
                        SelectedMode--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (SelectedMode < 4)
                    {
                        SelectedMode++;
                    }
                    break;
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    end = true;
                    break;
            }
        }
        Console.Clear();
    }
    

    
    static void Main(string[] args)
    {
        ChooseGameMode();
        Console.WriteLine("You can play with arrows/wasd and enter/spacebar");
        Thread.Sleep(5000);
        while (!ended)
        {
            PlayerMove("X");
            WinCheck();
            if (!ended) {
                switch (SelectedMode)
                {
                    case 1:
                        EasyBotMove();
                        break;
                    case 2:
                        MediumBotMove();
                        break;
                    case 3:
                        HardBotMove();
                        break;
                    case 4:
                        PlayerMove("O");
                        break;
                }
                WinCheck();
            }
        }
        Print();
        Console.ReadKey();
    }
}