using System;

namespace Blinker
{
	class Program
	{
		static void Main(string[] args)
		{
			var room = new Location();
			var john = new Human(1, room, 100, "John");
			var dave = new Human(2, room, 100, "Dave");

			john.Greet();
			room.WhoIsThere();


			Console.ReadKey();
		}
	}
}
