using System;

namespace Blinker
{
	public static class GameManager
	{
		private static Player player;
		private static Location startingLocation = new Location("Starting Room", "a room where you start your journey");

		public static void ClearConsole()
		{
			Console.Clear();
		}

		public static int ReadOption()
		{
			int option = Int32.Parse(Console.ReadLine());
			return option;
		}

		public static void ShowMenu()
		{
			ClearConsole();
			Console.WriteLine("\t\t# BLINKER #");
			Console.WriteLine("\t1. Start new game");
			Console.WriteLine("\t2. Load game");
			Console.WriteLine("\t3. Display info");
			Console.WriteLine("\t4. Exit");
		}

		public static void NewGame()
		{
			ClearConsole();
			CreateNewPlayer();
		}

		public static void DisplayInfo()
		{
			ClearConsole();
			Writer.WriteLog("# INFO:\n");
			Writer.WriteInfo("Text");
			Writer.WriteInfo(" - an information message (i.e room description)\n");
			Writer.WriteAction("Text");
			Writer.WriteInfo(" - commited action (i.e picked up item, moved to another location)\n");
			Writer.WriteActionHostile("Text");
			Writer.WriteInfo(" - hostile action (i. e fight)\n");
			Writer.WriteDialog("Text");
			Writer.WriteInfo(" - a dialog/npc\n");
			Writer.WriteLocation("Text");
			Writer.WriteInfo(" - a location (where you can possibly go)\n");
			Writer.WriteItem("Text");
			Writer.WriteInfo(" - an item (might be pickupable)\n");
			Writer.WriteLog("# END INFO\n\n");
		}

		public static void CreateNewPlayer()
		{
			ClearConsole();
			Console.WriteLine("Write your name:");
			var name = Console.ReadLine();
			player = new Player(name, startingLocation);
		}
	}
}