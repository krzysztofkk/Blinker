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
			_items = new List<PickupableItem>();
		}

		private List<PickupableItem> _items;

		public string Name { get; private set; }

		public int Health { get; protected set; }

		public Location CurrentLocation { get; protected set; }

		public bool IsAlive()
		{
			return (Health > 0);
		}
	}
}