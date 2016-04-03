using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			Initializer.DisplayInfo();

			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");
			Initializer.ConnectLocations(room, anotherRoom);

			var player = new Player("PlayerName", anotherRoom);

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", player);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", player);
			var item3 = new PickupableItem("stone", "tiny, gray stone", room);
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle", room);
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank", room);
			var wpn1 = new Weapon("knife", "sharp knife with wooden handle", player, 25);

			player.EquipedWeapon = wpn1;

			var john = new Npc("John", "I'm busy right now.", room);
			john.ReactionList.AddMany("What the hell?", "Stop it!");
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			dave.ReactionList.AddMany("Ugh!", "Argh...", "Ouch!");


			player.CheckMyItems();

			player.CheckLocationInfo();
			player.CheckLocationExits();
			player.CheckWhoIsThere();
			player.TalkTo(john);


			player.Move(room);

			player.CheckLocationInfo();
			player.CheckLocationExits();
			player.CheckPickupableItemsThere();
			player.CheckWhoIsThere();

			player.TalkTo(john);
			player.TalkTo(dave);
			player.TalkTo(john);

			player.PickUpItem(item4);
			player.CheckMyItems();
			player.CheckPickupableItemsThere();

			player.ThrowOutItem(item2);
			player.CheckMyItems();
			player.CheckPickupableItemsThere();

			player.Move(room);

			player.Attack(john);
			dave.Attack(john);
			player.Attack(john);
			player.Attack(john);
			dave.Attack(john);

			player.Attack(dave);

			player.CheckWhoIsThere();



			Console.ReadKey();
		}
	}
}
