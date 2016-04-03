using System;
using System.Collections.Generic;
using System.Linq;

namespace Blinker
{
	public static class GameManager
	{
		public static Player player;
		private static Location startingLocation;
		private static bool gameStarted;

		private static List<Location> locations = new List<Location>();
		private static List<Creature> creatures = new List<Creature>();
		private static List<Item> items = new List<Item>();   

		public static void Run()
		{
			if(gameStarted == false)
				ShowMenu();
			while (true)
				Play();

		}

		public static void Initialize()
		{
			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");
			Initializer.ConnectLocations(room, anotherRoom);
			startingLocation = room;

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
			Console.WriteLine("1. Start new game");
			Console.WriteLine("2. Load game");
			Console.WriteLine("3. Display info");
			Console.WriteLine("4. Exit");
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
			Initialize();
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
				default:
					Console.WriteLine("Wrong option");
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
			string parameter;

			switch (option)
			{
				case 1:
					player.CheckLocationExits();
					Console.WriteLine("Where do you want to go?");
					parameter = Console.ReadLine();
					var location = locations.Find(x => x.Name == parameter);
					if (location != null)
					{
						player.Move(location);
						Console.ReadKey();
					}
					break;
				case 2:
					player.CheckWhoIsThere();
					Console.WriteLine("Who do you want to talk to?");
					parameter = Console.ReadLine();
					var npc = creatures.Find(x => x.Name == parameter);
					if (npc != null)
					{
						player.TalkTo((Npc)npc);
						Console.ReadKey();
					}
					break;
				case 3:
					player.CheckWhoIsThere();
					Console.WriteLine("Who do you want to attack?");
					parameter = Console.ReadLine();
					var creature = creatures.Find(x => x.Name == parameter);
					if (creature != null)
					{
						player.Attack(creature);
						Console.ReadKey();
					}
					break;
				case 4:
					player.CheckPickupableItemsThere();
					Console.WriteLine("What do you want to pick up?");
					parameter = Console.ReadLine();
					var pickedItem = items.Find(x => x.Name == parameter);
					if (pickedItem != null)
					{
						player.PickUpItem((PickupableItem)pickedItem);
						Console.ReadKey();
					}
					break;
				case 5:
					player.CheckMyItems();
					Console.WriteLine("What do you want to drop?");
					parameter = Console.ReadLine();
					var droppedItem = items.Find(x => x.Name == parameter);
					if (droppedItem != null)
					{
						player.ThrowOutItem((PickupableItem)droppedItem);
						Console.ReadKey();
					}
					break;
				case 6:
					player.CheckMyItems();
					Console.WriteLine("What do you want to equip?");
					parameter = Console.ReadLine();
					var equippedItem = items.Find(x => x.Name == parameter);
					if (equippedItem != null)
					{
						player.EquipWeapon((Weapon)equippedItem);
						Console.ReadKey();
					}
					break;
				case 7:
					Console.WriteLine("What do you want to unequip?");
					parameter = Console.ReadLine();
					var unequippedItem = items.Find(x => x.Name == parameter);
					if (unequippedItem != null)
					{
						player.UnequipWeapon((Weapon)unequippedItem);
						Console.ReadKey();
					}
					break;
				default:
					Console.WriteLine("Wrong option");
					break;
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
			Console.ReadKey();
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