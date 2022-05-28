namespace CompassModKit.Utilities.ConsoleUtil
{
	public static class ConsoleUtil
    {
	    /// <summary>
	    /// Beefed up version of Console.Write, allows for changing text and background colors.
	    /// </summary>
	    /// <param name="content">Text to print</param>
	    /// <param name="foregroundColor">Color of text</param>
	    /// <param name="backgroundColor">Color of background</param>
	    public static void Write(string content, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
	    {
		    Console.ForegroundColor = foregroundColor;
		    Console.BackgroundColor = backgroundColor;
		    Console.Write(content);
		    Console.ResetColor();
	    }

	    /// <summary>
	    /// Beefed up version of Console.WriteLine, allows for changing text and background colors.
	    /// </summary>
	    /// <param name="content">Text to print</param>
	    /// <param name="foregroundColor">Color of text</param>
	    /// <param name="backgroundColor">Color of background</param>
    	public static void WriteLine(string content, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
		{
			Console.ForegroundColor = foregroundColor;
			Console.BackgroundColor = backgroundColor;
			Console.WriteLine(content);
			Console.ResetColor();
		}
    }
}

