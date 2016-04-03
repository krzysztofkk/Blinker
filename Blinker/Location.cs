using System.Collections.Generic;

namespace Blinker
{
	public class Location
	{
		public Location(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public List<Location> Exits = new List<Location>();
		public List<Item> Items { get; set; } = new List<Item>();

		public List<Npc> NpcList { get; set; } = new List<Npc>();

		public List<PickupableItem> PickupableItemList { get; set; } = new List<PickupableItem>();

		public string Name { get; set; }
		public string Description { get; set; }
	}
}