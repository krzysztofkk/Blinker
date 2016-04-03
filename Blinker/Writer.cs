using System;

namespace Blinker
{
	public static class Writer
	{
		private const ConsoleColor DefaultColor = ConsoleColor.White;

		public static void WriteDialog(string content)
		{
			Write(content, ConsoleColor.Green);
		}

		public static void WriteAction(string content)
		{
			Write(content, ConsoleColor.Yellow);
		}

		public static void WriteActionHostile(string content)
		{
			Write(content, ConsoleColor.Red);
		}

		public static void WriteItem(string content)
		{
			Write(content, ConsoleColor.Magenta);
		}

		public static void WriteLocation(string content)
		{
			Write(content, ConsoleColor.Cyan);
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
			Console.ForegroundColor = DefaultColor;
		}
	}
}