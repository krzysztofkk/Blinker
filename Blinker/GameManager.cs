using System;

namespace Blinker
{
	public static class GameManager
	{
		public static Player player;
		private static Location startingLocation = new Location("Starting Room", "a room where you start your journey");
		private static int gameStarted = 0;

		public static void Run()
		{
			if(gameStarted == 0)
				ShowMenu();
			Play();
		}

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
			ChooseMenuOption();
		}

		public static void ChooseMenuOption()
		{
			var option = ReadOption();
			switch (option)
			{
				case 1:
					NewGame();
					break;
				case 2:
					ShowMenu();
					break;
				case 3:
					DisplayInfo();
					break;
				case 4:
					break;
			}
		}

		public static void NewGame()
		{
			ClearConsole();
			CreateNewPlayer();
		}

		public static void Play()
		{
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Check something");
			Console.WriteLine("2. Do something");
			var option = ReadOption();
			switch (option)
			{
				case 1:
					CheckSomething();
					break;
				case 2:
					DoSomething();
					break;
			}
		}

		public static void CheckSomething()
		{
			Console.WriteLine("What do you want to check?");
			Console.WriteLine("1. Location - info");
			Console.WriteLine("2. Location - who is there");
			Console.WriteLine("3. Location - what items are there");
			Console.WriteLine("4. Location - where can I go from here");
			Console.WriteLine("5. Player - show me my inventory");


		}

		public static void DoSomething()
		{
			Console.WriteLine("What do you want to do?");
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