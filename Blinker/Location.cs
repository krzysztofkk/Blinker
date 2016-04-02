﻿using System.Collections.Generic;

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
		private List<Npc> _npcList = new List<Npc>();
		private List<Item> _items = new List<Item>();
		private List<PickupableItem> _pickupableItems = new List<PickupableItem>();
		 
		public List<Npc> NpcList
		{
			get { return _npcList; }
			set { _npcList = value; }
		}

		public string Name { get; set; }
		public string Description { get; set; }

	}
}