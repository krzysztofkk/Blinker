using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var room = new Location("Small Room", "small room with some people in there.");
			var john = new Npc("John", "I'm busy right now.", room);
			var dave = new Npc("Dave", "Hello! What do you need?", room);
			room.Creatures.Add(john);
			room.Creatures.Add(dave);

			room.CheckLocation();
			room.WhoIsThere();
			john.Greet();
			dave.Greet();
			john.Greet();


			Console.ReadKey();
		}
	}
}
