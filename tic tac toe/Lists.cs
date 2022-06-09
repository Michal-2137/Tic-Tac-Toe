using CompassModKit.Utilities.ConsoleUtil;
namespace CompassModKit.Lists
{
    public static class Lists
    {
        public static int CreateList(string title, string[] elements)
        {
            bool chosen = false;
            int chose = 0;
            while (!chosen)
            {
                Console.WriteLine(title);
                for (int i = 0; i < title.Length; i++)
                {
                    Console.Write("~");
                }
                Console.Write("\n");
                for (int i = 0; i < elements.Length; i++)
                {
                    if (chose == i)
                    {
                        ConsoleUtil.WriteLine(elements[i]);
                    }
                    else
                    {
                        Console.WriteLine(elements[i]);
                    }
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (chose > 0)
                        {
                            chose--;
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (chose < elements.Length-1)
                        {
                            chose++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        chosen = true;
                        break;
                }
                Console.Clear();
            }
            return chose;
        }
    }
}
