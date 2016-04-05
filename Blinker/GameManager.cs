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
			ShowActionMenu();
			while (true)
			{
				BreakLine();
				ExecuteAction(ReadOption());
			}

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

		private static char ReadOption()
		{
			Console.Write("KEY: ");
			char option = Console.ReadKey().KeyChar;
			Console.WriteLine("");
			option = char.ToUpper(option);
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

		private static void ShowError()
		{
			ShowActionMenu();
			var colour = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\t\t\tWrong option!");
			Console.ForegroundColor = colour;
			Console.WriteLine(" You pressed wrong key or typed not valid parameter.");
		}

		private static void ExecuteMainMenuAction()
		{
			var option = ReadOption();
			switch (option)
			{
				case '1':
					StartNewGame();
					break;
				case '2':
					ShowMainMenu();
					break;
				case '3':
					ShowHelp();
					break;
				case '4':
					break;
			}
		}

		private static void ShowActionMenu()
		{
			ClearConsole();
			BreakLine();
			Console.WriteLine("\t\tWhat do you want to do?");
			Console.WriteLine(" ## ACT ##\t\t\t## CHECK ##");
			Console.WriteLine(" G. Go somewhere\t\t1. Check location info");
			Console.WriteLine(" T. Talk to someone\t\t2. Check who is here");
			Console.WriteLine(" A. Attack someone\t\t3. Check what items are there");
			Console.WriteLine(" P. Pick up item\t\t4. Check where can I go from here");
			Console.WriteLine(" D. Drop item\t\t\t5. Check my inventory");
			Console.WriteLine(" E. Equip item\t\t\t");
			Console.WriteLine(" U. Unequip item\t\t\t");
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

		private static void ExecuteAction(char option)
		{
			//ShowActionMenu();
			//var option = ReadOption();
			string parameter;

			switch (option)
			{
				case 'G':
					ShowActionMenu();
					Player.CheckLocationExits();
					BreakLine();
					Console.WriteLine("Where do you want to go?");
					parameter = Console.ReadLine();
					var location = locations.Find(x => x.Name == parameter);
					if (location != null)
					{
						ShowActionMenu();
						Player.MoveTo(location);
					}
					else
						ShowError();
					break;
				case 'T':
					ShowActionMenu();
					Player.CheckWhoIsThere();
					BreakLine();
					Console.WriteLine("Who do you want to talk to?");
					parameter = Console.ReadLine();
					var npc = creatures.Find(x => x.Name == parameter);
					if (npc != null)
					{
						ShowActionMenu();
						Player.TalkTo((Npc)npc);
					}
					else
						ShowError();
					break;
				case 'A':
					ShowActionMenu();
					Player.CheckWhoIsThere();
					BreakLine();
					Console.WriteLine("Who do you want to attack?");
					parameter = Console.ReadLine();
					var creature = creatures.Find(x => x.Name == parameter);
					if (creature != null)
					{
						ShowActionMenu();
						Player.Attack(creature);
					}
					else
						ShowError();
					break;
				case 'P':
					ShowActionMenu();
					Player.CheckPickupableItemsThere();
					BreakLine();
					Console.WriteLine("What do you want to pick up?");
					parameter = Console.ReadLine();
					var pickedItem = items.Find(x => x.Name == parameter);
					if (pickedItem != null)
					{
						ShowActionMenu();
						Player.PickUpItem((PickupableItem)pickedItem);
					}
					else
						ShowError();
					break;
				case 'D':
					ShowActionMenu();
					Player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to drop?");
					parameter = Console.ReadLine();
					var droppedItem = items.Find(x => x.Name == parameter);
					if (droppedItem != null)
					{
						ShowActionMenu();
						Player.ThrowOutItem((PickupableItem)droppedItem);
					}
					else
						ShowError();
					break;
				case 'E':
					ShowActionMenu();
					Player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to equip?");
					parameter = Console.ReadLine();
					var equippedItem = items.Find(x => x.Name == parameter);
					if (equippedItem != null)
					{
						ShowActionMenu();
						Player.EquipWeapon(equippedItem);
					}
					else
						ShowError();
					break;
				case 'U':
					ShowActionMenu();
					Player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to unequip?");
					parameter = Console.ReadLine();
					var unequippedItem = items.Find(x => x.Name == parameter);
					if (unequippedItem != null)
					{
						ShowActionMenu();
						Player.UnequipWeapon(unequippedItem);
					}
					else
						ShowError();
					break;
				case '1':
					ShowActionMenu();
					Player.CheckLocationInfo();
					break;
				case '2':
					ShowActionMenu();
					Player.CheckWhoIsThere();
					break;
				case '3':
					ShowActionMenu();
					Player.CheckPickupableItemsThere();
					break;
				case '4':
					ShowActionMenu();
					Player.CheckLocationExits();
					break;
				case '5':
					ShowActionMenu();
					Player.CheckInventory();
					break;
				default:
					ShowActionMenu();
					ShowError();
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