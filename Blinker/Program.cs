using System;
using System.Data;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			GameManager.ShowMenu();

			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");
			Initializer.ConnectLocations(room, anotherRoom);

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", GameManager.player);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", GameManager.player);
			var item3 = new PickupableItem("stone", "tiny, gray stone", room);
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle", room);
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank", room);
			var wpn1 = new Weapon("knife", "sharp knife with wooden handle", GameManager.player, 25);

			var john = new Npc("John", "I'm busy right now.", room);
			john.ReactionList.AddMany("What the hell?", "Stop it!");
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			dave.ReactionList.AddMany("Ugh!", "Argh...", "Ouch!");
			var wpn2 = new Weapon("baseball bat", "used, old baseball bat", john, 7);


			GameManager.player.CheckMyItems();

			GameManager.player.EquipWeapon(wpn1);

			GameManager.player.CheckLocationInfo();
			GameManager.player.CheckLocationExits();
			GameManager.player.CheckWhoIsThere();
			GameManager.player.TalkTo(john);


			GameManager.player.Move(room);

			GameManager.player.CheckLocationInfo();
			GameManager.player.CheckLocationExits();
			GameManager.player.CheckPickupableItemsThere();
			GameManager.player.CheckWhoIsThere();

			GameManager.player.TalkTo(john);
			GameManager.player.TalkTo(dave);
			GameManager.player.TalkTo(john);

			GameManager.player.PickUpItem(item4);
			GameManager.player.CheckMyItems();
			GameManager.player.CheckPickupableItemsThere();

			GameManager.player.ThrowOutItem(item2);
			GameManager.player.CheckMyItems();
			GameManager.player.CheckPickupableItemsThere();

			GameManager.player.Move(room);

			john.EquipWeapon(wpn2);
			GameManager.player.Attack(john);
			dave.Attack(john);
			GameManager.player.Attack(john);
			GameManager.player.Attack(john);
			dave.Attack(john);

			GameManager.player.UnequipWeapon(wpn1);
			GameManager.player.EquipWeapon(wpn2);
			GameManager.player.UnequipWeapon(wpn2);

			GameManager.player.Attack(dave);

			dave.EquipWeapon(wpn1);
			dave.UnequipWeapon(wpn1);

			GameManager.player.CheckWhoIsThere();


			Console.ReadKey();
		}
	}
}
