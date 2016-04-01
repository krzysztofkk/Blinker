using System;
using System.Text;

namespace Blinker
{
	public static class Writer
	{
		public static void WriteDialog(string content)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(content);
			Console.ResetColor();
		}

		public static void WriteAction(string content)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(content);
			Console.ResetColor();
		}

		public static void WriteInfo(string content)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(content);
			Console.ResetColor();
		}
	}
}