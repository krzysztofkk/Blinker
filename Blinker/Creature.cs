using System.Collections.Generic;

namespace Blinker
{
	public abstract class Creature
	{
		protected Creature(string name, Location location)
		{
			Name = name;
			Health = 100;
			CurrentLocation = location;
			Items = new List<PickupableItem>();
		}

		public List<PickupableItem> Items { get; protected set; } 

		public string Name { get; private set; }

		public int Health { get; protected set; }

		public Location CurrentLocation { get; protected set; }

		public bool IsAlive()
		{
			return (Health > 0);
		}
	}
}