using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var gameManager = new GameManager();
			gameManager.Run();

			Console.ReadKey();
		}
	}
}
