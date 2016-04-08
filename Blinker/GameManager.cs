using System;
using System.Collections.Generic;
using Blinker.Entity;

namespace Blinker
{
	public static class GameManager
	{
		private static Player _player;
		private static Location _startingLocation;
		private static bool _gameStarted;

		private static readonly List<Location> Locations = new List<Location>();
		private static readonly List<Creature> Creatures = new List<Creature>();
		private static readonly List<Item> Items = new List<Item>();  
		private static readonly List<Objective> Objectives = new List<Objective>(); 

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
			// ReSharper disable once FunctionNeverReturns
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
			Console.WriteLine(" G. Go somewhere\t\t1. Location info");
			Console.WriteLine(" T. Talk to someone\t\t2. Who is here");
			Console.WriteLine(" A. Attack someone\t\t3. What items are there");
			Console.WriteLine(" P. Pick up item\t\t4. Where can I go from here");
			Console.WriteLine(" D. Drop item\t\t\t5. My inventory");
			Console.WriteLine(" E. Equip item\t\t\t6. Inspect item");
			Console.WriteLine(" U. Unequip item\t\t7. Tasks to do");
			BreakLine();
		}

		private static void ExecuteAction(char option)
		{
			//ShowActionMenu();
			//var option = ReadOption();
			string parameter;

			switch (option)
			{
				case 'G':
					ShowActionMenu();
					_player.CheckLocationExits();
					BreakLine();
					Console.WriteLine("Where do you want to go?");
					parameter = Console.ReadLine();
					var location = Locations.Find(x => x.Name == parameter);
					if (location != null)
					{
						ShowActionMenu();
						_player.MoveTo(location);
					}
					else
						ShowError();
					break;
				case 'T':
					ShowActionMenu();
					_player.CheckWhoIsThere();
					BreakLine();
					Console.WriteLine("Who do you want to talk to?");
					parameter = Console.ReadLine();
					var npc = Creatures.Find(x => x.Name == parameter);
					if (npc != null)
					{
						ShowActionMenu();
						_player.TalkTo((Npc)npc);
					}
					else
						ShowError();
					break;
				case 'A':
					ShowActionMenu();
					_player.CheckWhoIsThere();
					BreakLine();
					Console.WriteLine("Who do you want to attack?");
					parameter = Console.ReadLine();
					var creature = Creatures.Find(x => x.Name == parameter);
					if (creature != null)
					{
						ShowActionMenu();
						_player.Attack(creature);
					}
					else
						ShowError();
					break;
				case 'P':
					ShowActionMenu();
					_player.CheckPickupableItemsThere();
					BreakLine();
					Console.WriteLine("What do you want to pick up?");
					parameter = Console.ReadLine();
					var pickedItem = Items.Find(x => x.Name == parameter);
					if (pickedItem != null)
					{
						ShowActionMenu();
						_player.PickUpItem((PickupableItem)pickedItem);
					}
					else
						ShowError();
					break;
				case 'D':
					ShowActionMenu();
					_player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to drop?");
					parameter = Console.ReadLine();
					var droppedItem = Items.Find(x => x.Name == parameter);
					if (droppedItem != null)
					{
						ShowActionMenu();
						_player.ThrowOutItem((PickupableItem)droppedItem);
					}
					else
						ShowError();
					break;
				case 'E':
					ShowActionMenu();
					_player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to equip?");
					parameter = Console.ReadLine();
					var equippedItem = Items.Find(x => x.Name == parameter);
					if (equippedItem != null)
					{
						ShowActionMenu();
						_player.EquipWeapon(equippedItem);
					}
					else
						ShowError();
					break;
				case 'U':
					ShowActionMenu();
					_player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to unequip?");
					parameter = Console.ReadLine();
					var unequippedItem = Items.Find(x => x.Name == parameter);
					if (unequippedItem != null)
					{
						ShowActionMenu();
						_player.UnequipWeapon(unequippedItem);
					}
					else
						ShowError();
					break;
				case '1':
					ShowActionMenu();
					_player.CheckLocationInfo();
					break;
				case '2':
					ShowActionMenu();
					_player.CheckWhoIsThere();
					break;
				case '3':
					ShowActionMenu();
					_player.CheckPickupableItemsThere();
					break;
				case '4':
					ShowActionMenu();
					_player.CheckLocationExits();
					break;
				case '5':
					ShowActionMenu();
					_player.CheckInventory();
					break;
				case '6':
					ShowActionMenu();
					_player.CheckInventory();
					BreakLine();
					Console.WriteLine("What do you want to inspect?");
					parameter = Console.ReadLine();
					var selectedItem = Items.Find(x => x.Name == parameter);
					if (selectedItem != null)
					{
						ShowActionMenu();
						_player.CheckItemDetails(selectedItem);
					}
					else
						ShowError();
					break;
				case '7':
					ShowActionMenu();
					_player.CheckObjectiveList();
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
			_player = new Player(name, _startingLocation, Objectives);
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
			//4 OBJECTIVE
			//objective schema: Objectiove(name, description, ObjectiveType.type)
			//PART II
			//1. add your locations, items, npcs and objectives to lists (locations, creatures, items, objectives)
			//2. remember to set _startingLocation
			//## END MANUAL ##

			//LOCATIONS

			//roads
			var junction = new Location("junction", "junction where north street, south street and east street cross");
			var northStreet = new Location("north street", "calm, wide street");
			var southStreet = new Location("south street", "calm, wide street");
			var eastStreet = new Location("east street", "quiet, narrow street");

			//grocery shop
			var groceryShop = new Location("grocery shop", "big grocery shop with shelves full of fruit and vegetables");
			var groceryShopBackOffice = new Location("back office", "small back office with some boxes");

			//playground
			var playground = new Location("playground", "abandoned children playground");

			//villa
			var houseHall = new Location("house entrance", "house hall with some hangers and a big mirror on the wall");
			var houseGarage = new Location("garage", "empty garage with intensive petrol smell");
			var houseLivingRoom = new Location("living room", "living room with coffe table, sofa and tv hanged on the wall");
			var houseKitchen = new Location("kitchen", "old style kitchen with wooden furniture");
			var houseToilet = new Location("toilet", "small toilet with tiny bathhub");
			var houseBackyard = new Location("backyard", "huge, neglected garden, full of ferns and apple trees");
			var houseAlcove = new Location("alcove", "wooden alcove with gardening tools");

			//CONNECTIONS
			ConnectLocations(junction, northStreet);
			ConnectLocations(junction, southStreet);
			ConnectLocations(junction, eastStreet);

			ConnectLocations(groceryShop, groceryShopBackOffice);

			ConnectLocations(houseHall, houseGarage);
			ConnectLocations(houseHall, houseLivingRoom);
			ConnectLocations(houseHall, houseBackyard);
			ConnectLocations(houseLivingRoom, houseKitchen);
			ConnectLocations(houseLivingRoom, houseToilet);
			ConnectLocations(houseBackyard, houseAlcove);

			ConnectLocations(northStreet, groceryShop);
			ConnectLocations(eastStreet, groceryShop);
			ConnectLocations(eastStreet, playground);
			ConnectLocations(eastStreet, houseHall);
			ConnectLocations(southStreet, houseBackyard);

			_startingLocation = junction;

			//ITEMS

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", northStreet);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", northStreet);
			var item3 = new PickupableItem("foil bag", "transparent, yellow foil bag", junction);
			var item4 = new PickupableItem("stub", "cigarette stub", southStreet);
			var item5 = new PickupableItem("apple", "fresh, green apple", groceryShop);
			var item6 = new PickupableItem("banana", "slightly brown banana", groceryShop);
			var item7 = new PickupableItem("tomato", "blood-red tomato", groceryShop);
			var item8 = new PickupableItem("lime", "fresh lime", groceryShop);
			var item9 = new PickupableItem("doll", "very old, destroyed doll", playground);
			var item10 = new PickupableItem("coat", "slightly worn, brown leather coat", houseHall);
			var item11 = new Weapon("umbrella", "a yellow umbrella with steel tip", houseHall, 2);
			var item12 = new PickupableItem("sneakers", "sport sneakers", houseHall);
			var item13 = new PickupableItem("bowl", "ceramic bowl", houseLivingRoom);
			var item14 = new PickupableItem("newspaper", "black and white newspaper", houseLivingRoom);
			var item15 = new PickupableItem("watch", "expensive silver watch", houseLivingRoom);
			var item16 = new PickupableItem("book", "thick adventure book with blue cover", houseLivingRoom);
			var item17 = new Weapon("butcher knife", "a big, heavy butcher knife", houseKitchen, 25);
			var item18 = new PickupableItem("milk", "carton of milk", houseKitchen);
			var item19 = new PickupableItem("toilet paper", "a roll of toilet paper", houseToilet);
			var item20 = new PickupableItem("toothbrush", "used, blue toothbrush");
			var item21 = new PickupableItem("stone", "tiny, gray stone", houseBackyard);
			var item22 = new PickupableItem("empty bottle", "empty irish beer bottle", houseBackyard);
			var item23 = new Weapon("baseball bat", "wooden bat used in baseball", houseBackyard, 12);
			var item24 = new PickupableItem("wooden plank", "long, sharp wooden plank", houseAlcove);
			var item25 = new Weapon("long broom", "long, old broom", houseAlcove, 3);
			var item26 = new Weapon("small broom", "short, brown broom", houseAlcove, 2);
			var item27 = new Weapon("wrench", "steel wrench", houseGarage, 4);

			//NPCS

			var shopkeeper = new Npc("Shopkeeper", "Welcome in my store! Sorry but I'm busy right now.", groceryShop);
			shopkeeper.ReactionList.AddMany("What the hell?", "Stop it!", "What are you doing?", "Stop hitting me!");

			var dave = new Npc("Dave", "Hello! What do you need?", eastStreet);
			dave.ReactionList.AddMany("Ugh!", "Argh...", "Ouch!", "That hurts!");

			var cutthroat = new Npc("Cutthroat", "Go away. Now.", southStreet);

			var hooker = new Npc("Hooker", "Oh hello. I can't talk with at the moment, come back later.", southStreet);
			hooker.ReactionList.AddMany("Please stop!", "Don't kill me!", "Why?");

			var janitor = new Npc("Janitor", "I am a janitor. I'm busy.", houseAlcove);
			janitor.ReactionList.AddMany("Ouch, that hurts!", "Please, stop it.", "Why are you doing that?");

			var john = new Npc("John", "Give me a rest, I'm tired.", houseBackyard);
			john.ReactionList.AddMany("Stop it now!", "Dude...", "Argh!");

			var stranger = new Npc("Stranger", "...", playground);

			var groceryClient = new Npc("Client", "I'm talking with right now, please wait.", groceryShop);

			//OBJECTIVES
			var getKnife = new Objective("get butcher knife", "search the area for butcher knife", ObjectiveType.Have);
			var killCutthroat = new Objective("kill Cutthroat", "find and kill Cutthroat", ObjectiveType.Kill);


			// ## LISTS ##

			Locations.AddMany(
				northStreet,
				junction,
				southStreet,
				eastStreet,
				groceryShop,
				groceryShopBackOffice,
				playground,
				houseHall,
				houseGarage,
				houseLivingRoom,
				houseKitchen,
				houseToilet,
				houseBackyard,
				houseAlcove
				);

			Creatures.AddMany(
				shopkeeper,
				dave,
				john,
				cutthroat,
				hooker,
				janitor,
				stranger,
				groceryClient
				);

			Items.AddMany(
				item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11,
				item12, item13, item14, item15, item16, item17, item18, item19, item20, item21,
				item22, item23, item24, item25, item26, item27
				);

			Objectives.AddMany(
				getKnife,
				killCutthroat
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