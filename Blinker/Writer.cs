using System;

namespace Blinker
{
	public static class Writer
	{
		public static void WriteDialog(string content)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(content);
			Console.ResetColor();
		}

		public static void WriteAction(string content)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(content);
			Console.ResetColor();
		}

		public static void WriteInfo(string content)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(content);
			Console.ResetColor();
		}
	}
}