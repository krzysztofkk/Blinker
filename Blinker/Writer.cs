using System;

namespace Blinker
{
	public static class Writer
	{
		public static void WriteDialog(string content)
		{
			Write(content, ConsoleColor.Green);
		}

		public static void WriteAction(string content)
		{
			Write(content, ConsoleColor.Yellow);
		}

		public static void WriteInfo(string content)
		{
			Write(content, ConsoleColor.White);
		}

		public static void WriteLog(string content)
		{
			Write(content, ConsoleColor.Blue);
		}

		public static void Write(string content, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(content);
			Console.ResetColor();

		}
	}
}