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

			var item1 = new PickupableItem("wallet", "leather wallet, almost empty");
			var item2 = new PickupableItem("keys", "couple of keys on a keychain");
			var item3 = new PickupableItem("stone", "tiny, gray stone");
			var item4 = new PickupableItem("empty bottle", "empty irish beer bottle");
			var item5 = new PickupableItem("wooden plank", "long, sharp wooden plank");
			player.Items.Add(item1);
			player.Items.Add(item2);

			var john = new Npc("John", "I'm busy right now.", room);
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			room.NpcList.Add(john);
			room.NpcList.Add(dave);
			room.PickupableItemList.Add(item3);
			room.PickupableItemList.Add(item4);
			room.PickupableItemList.Add(item5);

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
