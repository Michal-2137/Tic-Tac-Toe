using System.Reflection.Metadata;
using CompassModKit.Utilities.ConsoleUtil;
using CompassModKit.Lists;

internal class Program
{
    #region Variables and Classes

        static string sign = "X";
        static string starts = "you 1st";
        static bool playerstarts = true;
        static string endtext = "";
        private static bool[,] chose = {{false, false, false}, {false, false, false}, {false, false, false}};
        static string[,] fields = {{" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "}};
        static bool ended = false;
        static Random random = new Random();
        static string mode = "easy";
        static string bot = "O", player = "X";
        class Move
        {
            public int y, x;
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
        Console.WriteLine(endtext);
    }
    
    
    //This function let player move
    static void PlayerMove(string sign)
    {
        Move move = new Move();
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
                        move.x = choseX;
                        move.y = choseY;
                        choosen = true;
                        break;
                }
            }
            chose[choseY, choseX] = false;
            if (fields[move.y, move.x] == " ")
            {
                fields[move.y, move.x] = sign;
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
        int x;
        int y;
        bool botis = false;
        while (!botis)
        {
            x = random.Next(0, 3);
            y = random.Next(0, 3);
            if (fields[y, x] == " ")
            {
                fields[y, x] = bot;
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
                int counter = 0;
                int counter2 = 0;
                int counter3 = 0;
                int counter4 = 0;
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
                    if (fields[j,i] == sign)
                    {
                        counter3++;
                    }

                    if (fields[j,i] == sign2)
                    {
                        counter4++;
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

                if (counter3 == 2 && counter4 == 0)
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
                                arr[j] = bot;
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
        Check(bot, player);
        if (!placed) 
        {
            Check(player, bot);
        }
        if (!placed)
        {
            EasyBotMove();
        }
    }


    //With this function bot on hard mode moves
    static void HardBotMove()
    {
        int MiniMax(string [,]fields, bool isMax)
        {
            int score = Evaluate(fields);
            if (score == 1)
                return score;
            if (score == -1)
                return score;
            if (IsMovesLeft(fields) == false)
                return 0;
            if (isMax)
            {
                int best = -100;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (fields[i, j] == " ")
                        {
                            fields[i, j] = bot;
                            best = Math.Max(best, MiniMax(fields, !isMax));
                            fields[i, j] = " ";
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 100;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (fields[i, j] == " ")
                        {
                            fields[i, j] = player;
                            best = Math.Min(best, MiniMax(fields, !isMax));
                            fields[i, j] = " ";
                        }
                    }
                }
                return best;
            }
        }
        Move FindBestMove(string [,]fields)
        {
            int bestValue = -100;
            Move bestMove = new Move();
            bestMove.y = -1;
            bestMove.x = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (fields[i, j] == " ")
                    {
                        fields[i, j] = bot;
                        int moveValue = MiniMax(fields, false);
                        fields[i, j] = " ";
                        if (moveValue > bestValue)
                        {
                            bestMove.y = i;
                            bestMove.x = j;
                            bestValue = moveValue;
                        }
                    }
                }
            }
            return bestMove;
        }
        Move bestMove = FindBestMove(fields);
        fields[bestMove.y, bestMove.x] = bot;
    }
    
    
    //This function checks if there are empty fields
    static bool IsMovesLeft(string [,]fields)
    {
        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (fields[i, j] == " ")
                return true; 
        return false;
    }
    
    
    //This function checks if someone got 3 in row
    static int Evaluate(string [,]b)
    {
        for (int i = 0; i < 3; i++)
        {
            if (b[i, 0] == b[i, 1] && b[i, 1] == b[i, 2])
            {
                if (b[i, 0] == bot)
                    return +1;
                else if (b[i, 0] == player)
                    return -1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (b[0, i] == b[1, i] && b[1, i] == b[2, i])
            {
                if (b[0, i] == bot)
                    return +1;
         
                else if (b[0, i] == player)
                    return -1;
            }
        }
        if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2])
        {
            if (b[0, 0] == bot)
                return +1;
            else if (b[0, 0] == player)
                return -1;
        }
        if (b[0, 2] == b[1, 1] && b[1, 1] == b[2, 0])
        {
            if (b[0, 2] == bot)
                return +1;
            else if (b[0, 2] == player)
                return -1;
        }
        return 0;
    }
    
    
    //This function checks if someone won
    static void WinCheck()
    {
        switch (Evaluate(fields))
        {
            case -1:
                endtext = "You won!";
                ended = true;
                break;
            case 1:
                endtext = "You lost!";
                ended = true;
                break;
        }
        if (!IsMovesLeft(fields) && !ended)
        {
            endtext = "Draw!";
            ended = true;
        }
        Print();
    }

    
    //This function chooses game mode
    static void Menu()
    {
        bool chosen = false;
        void ChooseGameMode()
        {
            string[] gamemodes = { "easy bot", "medium bot", "hard mode", "2 players" };
            switch(Lists.CreateList("Choose Game Mode", gamemodes))
            {
                case 0:
                    mode = "easy";
                    break;
                case 1:
                    mode = "medium";
                    break;
                case 2:
                    mode = "hard";
                    break;
                case 3:
                    mode = "2 players";
                    break;
            }
        }
        void ChooseYourSign()
        {
            string[] signs = { "You play as: X", "You play as: O" };
            switch (Lists.CreateList("Choose your sign", signs))
            {
                case 0:
                    sign = "X";
                    player = "X";
                    bot = "O";
                    break;
                case 1:
                    sign = "O";
                    player = "O";
                    bot = "X";
                    break;
            }
        }
        
        void ChooseWhoStarts()
        {
            string[] starting = { "You first", "Opponent first" };
            switch (Lists.CreateList("Who starts?", starting))
            {
                case 0:
                    starts = "you 1st";
                    break;
                case 1:
                    starts = "opponent 1st";
                    break;
            }
        }

        while (!chosen)
        {
            string[] menu = { "Play!", $"Choose your game mode. ({mode})", $"Choose your sign. ({sign})", $"Choose who starts. ({starts})" };
            switch (Lists.CreateList("MENU", menu))
            {
                case 0:
                    chosen = true;
                    break;
                case 1:
                    ChooseGameMode();
                    break;
                case 2:
                    ChooseYourSign();
                    break;
                case 3:
                    ChooseWhoStarts();
                    break;
            }
        }
    }
    

    
    static void Main(string[] args)
    {
        Play();

        void Play()
        {
            endtext = "";
            ended = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fields[i, j] = " ";
                }
            }
            Menu();
            Console.WriteLine("You can play with arrows/wasd and enter/spacebar");
            Thread.Sleep(1000);
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
            if (starts == "opponent 1st")
            {
                playerstarts = false;
            }

            while (!ended)
            { 
                if (playerstarts)
                {
                    PlayerMove(player);
                }
                else
                {
                    playerstarts = true;
                }
                WinCheck();
                if (!ended)
                {
                    switch (mode)
                    {
                        case "easy":
                            EasyBotMove();
                            break;
                        case "medium":
                            MediumBotMove();
                            break;
                        case "hard":
                            HardBotMove();
                            break;
                        case "2 players":
                            PlayerMove(bot);
                            break;
                    }
                    Thread.Sleep(1000);
                    WinCheck();
                }
            }

            Print();
            Console.ReadKey();
        }

        bool exit = false;
        while (!exit)
        {
            string[] restart = { "Restart", "Exit" };
            switch (Lists.CreateList("Want to play again?", restart))
            {
                case 0:
                    Play();
                    break;
                case 1:
                    exit = true;
                    break;
            }
        }
    }
}