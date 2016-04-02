using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var room = new Location("Small Room", "tiny room with some people in there");
			var anotherRoom = new Location("Big room", "huge, cold room");

			var player = new Player("Test", room);

			var john = new Npc("John", "I'm busy right now.", room);
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			room.NpcList.Add(john);
			room.NpcList.Add(dave);

			john.Greet();
			dave.Greet();
			john.Greet();

			room.NpcList.Remove(dave);
			anotherRoom.NpcList.Add(dave);


			Console.ReadKey();
		}
	}
}
