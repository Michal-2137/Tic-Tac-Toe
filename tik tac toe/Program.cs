using System.Net.Sockets;
using CompassModKit.Utilities.ConsoleUtil;

internal class Program
{
    #region Variables and Classes

        static string wintext = "";
        static string winner = "";
        private static bool[,] choose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] field = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static short x;
        static short y;
        static bool ended = false;
        static Random random = new Random();
        static short SelectedMode = 1;
        static string bot = "O", player = "X";
        class Move
        {
            public int row, col;
        };

        #endregion
        
    
    //This function prints board
    static void Print()
    {
        Console.Clear();
        Console.Write("  ");
        if (choose[0,0])
        {
            ConsoleUtil.Write(field[0,0]);
        }
        else
        {
            Console.Write(field[0,0]);
        }
        Console.Write(" | ");
        if (choose[0,1])
        {
            ConsoleUtil.Write(field[0,1]);
        }
        else
        {
            Console.Write(field[0,1]);
        }
        Console.Write(" | ");
        if (choose[0,2])
        {
            ConsoleUtil.Write(field[0,2]);
        }
        else
        {
            Console.Write(field[0,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (choose[1,0])
        {
            ConsoleUtil.Write(field[1,0]);
        }
        else
        {
            Console.Write(field[1,0]);
        }
        Console.Write(" | ");
        if (choose[1,1])
        {
            ConsoleUtil.Write(field[1,1]);
        }
        else
        {
            Console.Write(field[1,1]);
        }
        Console.Write(" | ");
        if (choose[1,2])
        {
            ConsoleUtil.Write(field[1,2]);
        }
        else
        {
            Console.Write(field[1,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (choose[2,0])
        {
            ConsoleUtil.Write(field[2,0]);
        }
        else
        {
            Console.Write(field[2,0]);
        }
        Console.Write(" | ");
        if (choose[2,1])
        {
            ConsoleUtil.Write(field[2,1]);
        }
        else
        {
            Console.Write(field[2,1]);
        }
        Console.Write(" | ");
        if (choose[2,2])
        {
            ConsoleUtil.Write(field[2,2]);
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
    }
    
    
    //With this function bot on medium mode moves
    static void MediumBotMove()
    {
        bool placed = false;
        void check(string sign, string sign2)
        {
            short i = 0;
            while (i < 3 && !placed)
            {
                short counter2 = 0;
                short counter = 0;
                for (short j=0;j<3;j++)
                {
                    if (field[i,j] == sign)
                    {
                        counter++;
                    }

                    if (field[i,j] == sign2)
                    {
                        counter2++;
                    }
                }
                
                if (counter == 2 && counter2 == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i,j] == " ")
                        {
                            field[i, j] = "O";
                            placed = true;
                        }
                    }
                }
                i++;
            }
            i = 0;
            while (i < 3 && !placed)
            {
                short counter2 = 0;
                short counter = 0;
                for (short j = 0; j < 3; j++)
                {
                    if (field[j, i] == sign)
                    {
                        counter++;
                    }

                    if (field[j, i] == sign2)
                    {
                        counter2++;
                    }
                }
                if (counter == 2 && counter2 == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[j, i] == " ")
                        {
                            field[j, i] = "O";
                            placed = true;
                        }
                    }
                }
                i++;
            }

            if (!placed)
            {
                string[] arr = { field[0, 0], field[1, 1], field[2, 2] };
                Pablo(true);
                if (!placed)
                {
                    arr[0] = field[0, 2];
                    arr[2] = field[2, 0];
                    Pablo(false);
                }

                void Pablo(bool f)
                {
                    short counter = 0;
                    short counter2 = 0;
                    foreach (string a in arr)
                    {
                        if (a == sign)
                        {
                            counter++;
                        }

                        if (a == sign2)
                        {
                            counter2++;
                        }
                    }

                    if (counter == 2 && counter2 == 0)
                    {
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (arr[j] == " ")
                            {
                                arr[j] = "O";
                                placed = true;
                            }
                        }
                    }

                    field[1, 1] = arr[1];
                    if (f)
                    {
                        field[0, 0] = arr[0];
                        field[2, 2] = arr[2];
                    }
                    else
                    {
                        field[0, 2] = arr[0];
                        field[2, 0] = arr[2];
                    }
                }
            }
        }
        check("O", "X");
        if (!placed) 
        {
            check("X", "O");
        }
        if (!placed)
        {
            EasyBotMove();
        }
    }


    //With this function bot on hard mode moves
    static void HardBotMove()
    {
        Boolean IsMovesLeft(string [,]field)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (field[i, j] == " ")
                        return true; 
            return false;
        }
        int Evaluate(string [,]b)
        {
            for (int row = 0; row < 3; row++)
            {
                if (b[row, 0] == b[row, 1] &&
                    b[row, 1] == b[row, 2])
                {
                    if (b[row, 0] == bot)
                        return +10;
                    else if (b[row, 0] == player)
                        return -10;
                }
            }
            for (int col = 0; col < 3; col++)
            {
                if (b[0, col] == b[1, col] &&
                    b[1, col] == b[2, col])
                {
                    if (b[0, col] == bot)
                        return +10;
         
                    else if (b[0, col] == player)
                        return -10;
                }
            }
            if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2])
            {
                if (b[0, 0] == bot)
                    return +10;
                else if (b[0, 0] == player)
                    return -10;
            }
            if (b[0, 2] == b[1, 1] && b[1, 1] == b[2, 0])
            {
                if (b[0, 2] == bot)
                    return +10;
                else if (b[0, 2] == player)
                    return -10;
            }
            return 0;
        }
        int MiniMax(string [,]field, int depth, Boolean isMax)
        {
            int score = Evaluate(field);
            if (score == 10)
                return score;
            if (score == -10)
                return score;
            if (IsMovesLeft(field) == false)
                return 0;
            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i, j] == " ")
                        {
                            field[i, j] = bot;
                            best = Math.Max(best, MiniMax(field, depth + 1, !isMax));
                            field[i, j] = " ";
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i, j] == " ")
                        {
                            field[i, j] = player;
                            best = Math.Min(best, MiniMax(field, depth + 1, !isMax));
                            field[i, j] = " ";
                        }
                    }
                }
                return best;
            }
        }
        Move FindBestMove(string [,]field)
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row = -1;
            bestMove.col = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == " ")
                    {
                        field[i, j] = bot;
                        int moveVal = MiniMax(field, 0, false);
                        field[i, j] = " ";
                        if (moveVal > bestVal)
                        {
                            bestMove.row = i;
                            bestMove.col = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            return bestMove;
        }
        Move bestMove = FindBestMove(field);
        field[bestMove.row, bestMove.col] = bot;
    }
    
    
    //This function checks if someone won
    static void WinCheck()
    {
        void end()
        {
            wintext = $"the winner is {winner}!";
            ended = true;
        }

        for (int i = 0; i < 3; i++)
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
                ConsoleUtil.WriteLine("easy mode");
            }
            else
            {
                Console.WriteLine("easy mode");
            }
            if (SelectedMode == 2)
            {
                ConsoleUtil.WriteLine("medium mode");
            }
            else
            {
                Console.WriteLine("medium mode");
            }
            if (SelectedMode == 3)
            {
                ConsoleUtil.WriteLine("hard mode");
            }
            else
            {
                Console.WriteLine("hard mode");
            }
            if (SelectedMode == 4)
            {
                ConsoleUtil.WriteLine("2 players mode");
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
        Thread.Sleep(1000);
        Console.WriteLine("Press anything to continue");
        Console.ReadKey();
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
                Thread.Sleep(1000);
                WinCheck();
            }
        }
        Print();
        Console.ReadKey();
    }
}