using System;
using System.Collections.Generic;

namespace Blinker
{
	public static class GameManager
	{
		public static Player Player;
		private static Location _startingLocation;
		private static bool _gameStarted;

		private static List<Location> locations = new List<Location>();
		private static List<Creature> creatures = new List<Creature>();
		private static List<Item> items = new List<Item>();   

		public static void Run()
		{
			Console.ForegroundColor = ConsoleColor.White;
			while (_gameStarted == false)
				ShowMainMenu();
			while (true)
				Play();
			// ReSharper disable once FunctionNeverReturns
		}

		//right now it's obsolete, gonna keep it though
		private static void Play()
		{
			ClearConsole();
			Console.ForegroundColor = ConsoleColor.White;
			ExecuteAction();
		}

		private static void StartNewGame()
		{
			ClearConsole();
			Initialize();
			CreateNewPlayer();
			_gameStarted = true;
		}

		private static void ClearConsole()
		{
			Console.Clear();
		}

		private static int ReadOption()
		{
			int option;
			Int32.TryParse(Console.ReadLine(), out option);
			return option;
		}

		private static void ShowMainMenu()
		{
			ClearConsole();
			BreakLine();
			Console.WriteLine(" 1. Start new game");
			Console.WriteLine(" 2. Load game");
			Console.WriteLine(" 3. Display info");
			Console.WriteLine(" 4. Exit");
			BreakLine();
			ExecuteMainMenuAction();
		}

		private static void BreakLine()
		{
			Console.WriteLine("-------------------------------------------------------------------");
		}

		private static void ExecuteMainMenuAction()
		{
			var option = ReadOption();
			switch (option)
			{
				case 1:
					StartNewGame();
					break;
				case 2:
					ShowMainMenu();
					break;
				case 3:
					ShowHelp();
					break;
				case 4:
					break;
			}
		}

		private static void ShowActionMenu()
		{
			ClearConsole();
			BreakLine();
			Console.WriteLine("\t\tWhat do you want to do?");
			Console.WriteLine(" 1. Go somewhere\t\t7. Unequip item");
			Console.WriteLine(" 2. Talk to someone\t\t8. Check location info");
			Console.WriteLine(" 3. Attack someone\t\t9. Check who is here");
			Console.WriteLine(" 4. Pick up item\t\t10. Check what items are there");
			Console.WriteLine(" 5. Throw out item\t\t11. Check where can I go from here");
			Console.WriteLine(" 6. Equip item\t\t\t12. Check my inventory");
			BreakLine();
		}

		/*private static void ShowActionMenu()
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
			Console.WriteLine("8. Check location info");
			Console.WriteLine("9. Check who is here");
			Console.WriteLine("10. Check what items are there");
			Console.WriteLine("11. Check where can I go from here");
			Console.WriteLine("12. Check my inventory");
		}*/

		private static void ExecuteAction()
		{
			ShowActionMenu();
			var option = ReadOption();
			string parameter;

			switch (option)
			{
				case 1:
					Player.CheckLocationExits();
					Console.WriteLine("Where do you want to go?");
					parameter = Console.ReadLine();
					var location = locations.Find(x => x.Name == parameter);
					if (location != null)
					{
						ShowActionMenu();
						Player.MoveTo(location);
						Console.ReadKey();
					}
					break;
				case 2:
					Player.CheckWhoIsThere();
					Console.WriteLine("Who do you want to talk to?");
					parameter = Console.ReadLine();
					var npc = creatures.Find(x => x.Name == parameter);
					if (npc != null)
					{
						ShowActionMenu();
						Player.TalkTo((Npc)npc);
						Console.ReadKey();
					}
					break;
				case 3:
					Player.CheckWhoIsThere();
					Console.WriteLine("Who do you want to attack?");
					parameter = Console.ReadLine();
					var creature = creatures.Find(x => x.Name == parameter);
					if (creature != null)
					{
						ShowActionMenu();
						Player.Attack(creature);
						Console.ReadKey();
					}
					break;
				case 4:
					Player.CheckPickupableItemsThere();
					Console.WriteLine("What do you want to pick up?");
					parameter = Console.ReadLine();
					var pickedItem = items.Find(x => x.Name == parameter);
					if (pickedItem != null)
					{
						ShowActionMenu();
						Player.PickUpItem((PickupableItem)pickedItem);
						Console.ReadKey();
					}
					break;
				case 5:
					Player.CheckInventory();
					Console.WriteLine("What do you want to drop?");
					parameter = Console.ReadLine();
					var droppedItem = items.Find(x => x.Name == parameter);
					if (droppedItem != null)
					{
						ShowActionMenu();
						Player.ThrowOutItem((PickupableItem)droppedItem);
						Console.ReadKey();
					}
					break;
				case 6:
					Player.CheckInventory();
					Console.WriteLine("What do you want to equip?");
					parameter = Console.ReadLine();
					var equippedItem = items.Find(x => x.Name == parameter);
					if (equippedItem != null)
					{
						ShowActionMenu();
						Player.EquipWeapon(equippedItem);
						Console.ReadKey();
					}
					break;
				case 7:
					Console.WriteLine("What do you want to unequip?");
					parameter = Console.ReadLine();
					var unequippedItem = items.Find(x => x.Name == parameter);
					if (unequippedItem != null)
					{
						ShowActionMenu();
						Player.UnequipWeapon(unequippedItem);
						Console.ReadKey();
					}
					break;
				case 8:
					Player.CheckLocationInfo();
					Console.ReadKey();
					break;
				case 9:
					Player.CheckWhoIsThere();
					Console.ReadKey();
					break;
				case 10:
					Player.CheckPickupableItemsThere();
					Console.ReadKey();
					break;
				case 11:
					Player.CheckLocationExits();
					Console.ReadKey();
					break;
				case 12:
					Player.CheckInventory();
					Console.ReadKey();
					break;
				default:
					Console.WriteLine("Wrong option");
					break;
			}
		}

		private static void ShowHelp()
		{
			ClearConsole();
			BreakLine();
			Writer.WriteLog("# INFO:\n");
			Writer.WriteInfo("Text");
			Writer.WriteInfo(" - an information message (i.e room description)\n");
			Writer.WriteAction("Text");
			Writer.WriteInfo(" - commited action (i.e picked up item, moved to another location)\n");
			Writer.WriteActionHostile("Text");
			Writer.WriteInfo(" - hostile action (i.e fight)\n");
			Writer.WriteDialog("Text");
			Writer.WriteInfo(" - a dialog/npc\n");
			Writer.WriteLocation("Text");
			Writer.WriteInfo(" - a location (where you can possibly go)\n");
			Writer.WriteItem("Text");
			Writer.WriteInfo(" - an item (might be pickupable)\n");
			Writer.WriteLog("# END INFO\n\n");
			BreakLine();
			Console.ReadKey();
		}

		private static void CreateNewPlayer()
		{
			ClearConsole();
			BreakLine();
			Console.WriteLine(" Write your name:");
			BreakLine();
			var name = Console.ReadLine();
			if (name == String.Empty)
				name = "PLAYER";
			Player = new Player(name, _startingLocation);
		}

		//this might be used to load "story" from file in the future, right now it's a mess
		private static void Initialize()
		{
			//## MANUAL ##
			//PART I
			//1. LOCATIONS
			//location schema: Location(name, description)
			//connecting two locations: ConnectLocations(loc1, loc2)
			//2. ITEMS
			//item schema: PickupableItem(name, description, location/creature)
			//3. NPC (or creature)
			//npc schema: Npc(name, greeting, location)
			//adding attack reactions: person.ReactionList.Addmany(string, string, string, ...)
			//PART II
			//1. add your locations, items and npcs to lists (locations, creatures, items)
			//2. remember to set _startingLocation
			//## END MANUAL ##

			var room = new Location("small room", "tiny room with some people in there");
			var storageRoom = new Location("storage room", "storage room with some brooms");
			var anotherRoom = new Location("big room", "huge, cold room");
			var garden = new Location("garden", "green, grassy garden with one big tree in the centre");
			ConnectLocations(room, storageRoom);
			ConnectLocations(room, anotherRoom);
			ConnectLocations(anotherRoom, garden);

			_startingLocation = room;

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", garden);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", room);
			var item3 = new PickupableItem("stone", "tiny, gray stone", room);
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle", room);
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank", garden);
			var item6 = new PickupableItem("long broom", "long, old broom", storageRoom);
			var item7 = new PickupableItem("small broom", "short, brown broom", storageRoom);
			var wpn1 = new Weapon("knife", "sharp knife with wooden handle", room, 25);
			var wpn2 = new Weapon("baseball bat", "used, old baseball bat", anotherRoom, 7);

			var john = new Npc("John", "I'm busy right now.", room);
			john.ReactionList.AddMany("What the hell?", "Stop it!", "What are you doing man?", "Stop hitting me!");

			var dave = new Npc("Dave", "Hello! What do you need?", room);
			dave.ReactionList.AddMany("Ugh!", "Argh...", "Ouch!", "That hurts!");

			var andrew = new Npc("Andrew", "Go away.", garden);
			andrew.ReactionList.AddMany("...");

			var janitor = new Npc("Janitor", "I am a janitor.", storageRoom);
			janitor.ReactionList.AddMany("Ouch, that hurts!", "Please, stop it.", "Why are you doing that?");

			locations.AddMany(
				room,
				anotherRoom,
				garden,
				storageRoom
				);

			creatures.AddMany(
				john,
				dave,
				andrew,
				janitor
				);

			items.AddMany(
				item1,
				item2,
				item3,
				item4,
				item5,
				item6,
				item7,
				wpn1,
				wpn2
				);
		}

		private static void ConnectLocations(Location loc1, Location loc2)
		{
			if (!loc1.Exits.Contains(loc2))
				loc1.Exits.Add(loc2);
			if (!loc2.Exits.Contains(loc1))
				loc2.Exits.Add(loc1);
		}
	}
}