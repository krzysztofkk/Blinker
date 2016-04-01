using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var room = new Location("Small Room", "Rather small room with some people in there.");
			var john = new Human(1, "John", room, 100);
			var dave = new Human(2, "Dave", room, 100);
			room.Creatures.Add(john);
			room.Creatures.Add(dave);

			john.Greet();
			room.WhoIsThere();


			Console.ReadKey();
		}
	}
}
