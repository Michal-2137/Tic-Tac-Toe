using CompassModKit.Utilities.ConsoleUtil;
using CompassModKit.Lists;

internal class Program
{
    #region Variables and Classes

        static string wintext = "";
        static string winner = "";
        private static bool[,] chose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] fields = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static int x;
        static int y;
        static bool ended = false;
        static Random random = new Random();
        static int mode = 1;
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
        if (chose[0,0])
        {
            ConsoleUtil.Write(fields[0,0]);
        }
        else
        {
            Console.Write(fields[0,0]);
        }
        Console.Write(" | ");
        if (chose[0,1])
        {
            ConsoleUtil.Write(fields[0,1]);
        }
        else
        {
            Console.Write(fields[0,1]);
        }
        Console.Write(" | ");
        if (chose[0,2])
        {
            ConsoleUtil.Write(fields[0,2]);
        }
        else
        {
            Console.Write(fields[0,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (chose[1,0])
        {
            ConsoleUtil.Write(fields[1,0]);
        }
        else
        {
            Console.Write(fields[1,0]);
        }
        Console.Write(" | ");
        if (chose[1,1])
        {
            ConsoleUtil.Write(fields[1,1]);
        }
        else
        {
            Console.Write(fields[1,1]);
        }
        Console.Write(" | ");
        if (chose[1,2])
        {
            ConsoleUtil.Write(fields[1,2]);
        }
        else
        {
            Console.Write(fields[1,2]);
        }
        Console.Write(" \n ---|---|---\n  ");
        if (chose[2,0])
        {
            ConsoleUtil.Write(fields[2,0]);
        }
        else
        {
            Console.Write(fields[2,0]);
        }
        Console.Write(" | ");
        if (chose[2,1])
        {
            ConsoleUtil.Write(fields[2,1]);
        }
        else
        {
            Console.Write(fields[2,1]);
        }
        Console.Write(" | ");
        if (chose[2,2])
        {
            ConsoleUtil.Write(fields[2,2]);
        }
        else
        {
            Console.Write(fields[2,2]);
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
            int choseX = 0;
            int choseY = 0;
            bool choosen = false;
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
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        x = choseX;
                        y = choseY;
                        choosen = true;
                        break;
                }
            }
            chose[choseY, choseX] = false;
            if (fields[y, x] == " ")
            {
                fields[y, x] = sign;
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
            if (fields[botY, botX] == " ")
            {
                fields[botY, botX] = bot;
                botis = true;
            }
        }
    }
    
    
    //With this function bot on medium mode moves
    static void MediumBotMove()
    {
        bool placed = false;
        void Check(string sign, string sign2)
        {
            int i = 0;
            while (i < 3 && !placed)
            {
                int counter2 = 0;
                int counter = 0;
                for (short j=0;j<3;j++)
                {
                    if (fields[i,j] == sign)
                    {
                        counter++;
                    }

                    if (fields[i,j] == sign2)
                    {
                        counter2++;
                    }
                }
                
                if (counter == 2 && counter2 == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (fields[i,j] == " ")
                        {
                            fields[i, j] = bot;
                            placed = true;
                        }
                    }
                }
                i++;
            }
            i = 0;
            while (i < 3 && !placed)
            {
                int counter2 = 0;
                int counter = 0;
                for (short j = 0; j < 3; j++)
                {
                    if (fields[j, i] == sign)
                    {
                        counter++;
                    }

                    if (fields[j, i] == sign2)
                    {
                        counter2++;
                    }
                }
                if (counter == 2 && counter2 == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (fields[j, i] == " ")
                        {
                            fields[j, i] = bot;
                            placed = true;
                        }
                    }
                }
                i++;
            }

            if (!placed)
            {
                string[] arr = { fields[0, 0], fields[1, 1], fields[2, 2] };
                CheckSlant(true);
                if (!placed)
                {
                    arr[0] = fields[0, 2];
                    arr[2] = fields[2, 0];
                    CheckSlant(false);
                }

                void CheckSlant(bool f)
                {
                    int counter = 0;
                    int counter2 = 0;
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

                    fields[1, 1] = arr[1];
                    if (f)
                    {
                        fields[0, 0] = arr[0];
                        fields[2, 2] = arr[2];
                    }
                    else
                    {
                        fields[0, 2] = arr[0];
                        fields[2, 0] = arr[2];
                    }
                }
            }
        }
        Check("O", "X");
        if (!placed) 
        {
            Check("X", "O");
        }
        if (!placed)
        {
            EasyBotMove();
        }
    }


    //With this function bot on hard mode moves
    static void HardBotMove()
    {
        Boolean IsMovesLeft(string [,]fields)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (fields[i, j] == " ")
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
        int MiniMax(string [,]fields, int depth, Boolean isMax)
        {
            int score = Evaluate(fields);
            if (score == 10)
                return score;
            if (score == -10)
                return score;
            if (IsMovesLeft(fields) == false)
                return 0;
            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (fields[i, j] == " ")
                        {
                            fields[i, j] = bot;
                            best = Math.Max(best, MiniMax(fields, depth + 1, !isMax));
                            fields[i, j] = " ";
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
                        if (fields[i, j] == " ")
                        {
                            fields[i, j] = player;
                            best = Math.Min(best, MiniMax(fields, depth + 1, !isMax));
                            fields[i, j] = " ";
                        }
                    }
                }
                return best;
            }
        }
        Move FindBestMove(string [,]fields)
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row = -1;
            bestMove.col = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (fields[i, j] == " ")
                    {
                        fields[i, j] = bot;
                        int moveVal = MiniMax(fields, 0, false);
                        fields[i, j] = " ";
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
        Move bestMove = FindBestMove(fields);
        fields[bestMove.row, bestMove.col] = bot;
    }
    
    
    //This function checks if someone won
    static void WinCheck()
    {
        void End()
        {
            wintext = $"the winner is {winner}!";
            ended = true;
        }

        for (int i = 0; i < 3; i++)
        {
            if (fields[i,0] == fields[i,1] && fields[i,0] == fields[i,2] && fields[i,0] != " ")
            {
                winner = fields[i, 0];
                End();
            }
            if (fields[0,i] == fields[1,i] && fields[0,i] == fields[2,i] && fields[0,i] != " ")
            {
                winner = fields[0, i];
                End();
            }
        }
        if (fields[0,0] == fields[1,1] && fields[0,0] == fields[2,2] && fields[0,0] != " ")
        {
            winner = fields[0, 0];
            End();
        }

        if (fields[0,2] == fields[1,1] && fields[0,2] == fields[2,0] && fields[0,2] != " ")
        {
            winner = fields[0, 2];
            End();
        }
        
        if (!ended)
        {
            bool draw = true;
            foreach (string f in fields)
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
    static void Menu()
    {
        string[] gamemodes = {"easy bot", "medium bot", "hard mode", "2 players"};
        mode = Lists.CreateList("Choose Game Mode", gamemodes);
    }
    

    
    static void Main(string[] args)
    {
        Menu();
        Console.WriteLine("You can play with arrows/wasd and enter/spacebar");
        Thread.Sleep(1000);
        Console.WriteLine("Press anything to continue");
        Console.ReadKey();
        while (!ended)
        {
            PlayerMove("X");
            WinCheck();
            if (!ended) {
                switch (mode)
                {
                    case 0:
                        EasyBotMove();
                        break;
                    case 1:
                        MediumBotMove();
                        break;
                    case 2:
                        HardBotMove();
                        break;
                    case 3:
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