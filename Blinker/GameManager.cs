using System;
using System.Collections.Generic;

namespace Blinker
{
	public static class GameManager
	{
		public static Player player;
		private static Location startingLocation;
		private static bool gameStarted;

		private static List<Location> locations;
		private static List<Creature> creatures;
		private static List<Item> items;   

		public static void Run()
		{
			if(gameStarted == false)
				ShowMenu();
			while (true)
				Play();

		}

		public static void Init()
		{
			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");
			Initializer.ConnectLocations(room, anotherRoom);

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", room);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", room);
			var item3 = new PickupableItem("stone", "tiny, gray stone", room);
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle", room);
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank", room);
			var wpn1 = new Weapon("knife", "sharp knife with wooden handle", room, 25);

			var john = new Npc("John", "I'm busy right now.", room);
			john.ReactionList.AddMany("What the hell?", "Stop it!");
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			dave.ReactionList.AddMany("Ugh!", "Argh...", "Ouch!");
			var wpn2 = new Weapon("baseball bat", "used, old baseball bat", john, 7);

			locations.AddMany(
				room,
				anotherRoom
				);

			creatures.AddMany(
				john,
				dave
				);

			items.AddMany(
				item1,
				item2,
				item3,
				item4,
				item5,
				wpn1,
				wpn2
				);
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
			gameStarted = true;
		}

		public static void Play()
		{
			ClearConsole();
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
			ClearConsole();
			Console.WriteLine("What do you want to check?");
			Console.WriteLine("1. Location - info");
			Console.WriteLine("2. Location - who is there");
			Console.WriteLine("3. Location - what items are there");
			Console.WriteLine("4. Location - where can I go from here");
			Console.WriteLine("5. Player - show me my inventory");
			var option = ReadOption();
			switch (option)
			{
				case 1:
					player.CheckLocationInfo();
					Console.ReadKey();
					break;
				case 2:
					player.CheckWhoIsThere();
					Console.ReadKey();
					break;
				case 3:
					player.CheckPickupableItemsThere();
					Console.ReadKey();
					break;
				case 4:
					player.CheckLocationExits();
					Console.ReadKey();
					break;
				case 5:
					player.CheckMyItems();
					Console.ReadKey();
					break;
			}
		}

		public static void DoSomething()
		{
			ClearConsole();
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Go somewhere");
			Console.WriteLine("2. Talk to someone");
			Console.WriteLine("3. Attack someone");
			Console.WriteLine("4. Pick up item");
			Console.WriteLine("5. Throw out item");
			Console.WriteLine("6. Equip item");
			Console.WriteLine("7. Unequip item");
			var option = ReadOption();
			Console.WriteLine("Type target:");
			var parameter = Console.ReadLine();
			switch (option)
			{
				//case 1:
					//var taget = 
					//player.Move(Location);
			}
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