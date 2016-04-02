using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");

			var player = new Player("Test", anotherRoom);

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty", player);
			var item2 = new PickupableItem("keys", "couple of keys on a keychain", player);
			var item3 = new PickupableItem("stone", "tiny, gray stone", room);
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle", room);
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank", room);

			var john = new Npc("John", "I'm busy right now.", room);
			var dave = new Npc("Dave", "Hello! What do you need?", room);

			player.CheckMyItems();

			player.CheckLocationInfo();
			player.CheckWhoIsThere();


			player.Move(room);

			player.CheckLocationInfo();
			player.CheckPickupableItemsThere();
			player.CheckWhoIsThere();

			player.TalkTo(john);
			player.TalkTo(dave);
			player.TalkTo(john);


			Console.ReadKey();
		}
	}
}
