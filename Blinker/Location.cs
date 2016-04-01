using System.Collections.Generic;

namespace Blinker
{
	public class Location
	{
		private int _id;
		public string Name;
		public string Description;

		public List<Location> Exits = new List<Location>();
		public List<Creature> Creatures = new List<Creature>();

		public void WhoIsThere()
		{
			foreach(Creature c in Creatures)
				if (c is Human)
				{
					c.Greet();
				}
						
		}
	}
}