using System.Runtime.CompilerServices;
namespace Core.Logging.ProofOfConcept
{
	public static class Logging_POC
	{
		static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		static string data = Path.Combine(folder, "Tic Tac Toe");
		static string logs = Path.Combine(data, "log.txt");
		public static void Setup()
		{
			
			Directory.CreateDirectory(data);

			using (StreamWriter sw = File.CreateText(logs))
			{
				sw.WriteLine($"[ {DateTime.Now} | Logging_POC ] Clog Started!"); // Clog - Codename for Compass Logger or something...
			}
		}
		public static void Log(string content, [CallerFilePath] string fileName = "", [CallerMemberName] string method = "", [CallerLineNumber] int lineNumber = 0)
		{
			
			
			using (StreamWriter sw = File.AppendText(logs))
			{
				sw.WriteLine($"[ {DateTime.Now} | {Path.GetFileName(fileName)} -> {method}:{lineNumber} ] {content}");
			}
		}
	}
}
