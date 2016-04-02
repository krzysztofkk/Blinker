using System.Collections.Generic;
using System.Linq;

namespace Blinker
{
	public class Player : Creature, IMoveable
	{
		public Player(string name, Location location) : base(name, location)
		{
			Items = new List<PickupableItem>();
		}

		public List<PickupableItem> Items { get; set; }

		public void CheckLocationInfo()
		{
			Writer.WriteInfo(string.Format("I am in the [{0}].\nIt's a {1}.\n\n", CurrentLocation.Name, CurrentLocation.Description));
		}

		public void CheckWhoIsThere()
		{
			if (CurrentLocation.NpcList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (Npc n in CurrentLocation.NpcList)
					Writer.WriteDialog("[" + n.Name + "]" + ", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.\n\n");
			}

		}

		public void CheckMyItems()
		{
			Writer.WriteAction("You are checking your inventory. Available items:\n");
			foreach (var item in Items)
				Writer.WriteInfo("["+item.Name+"], ");
			Writer.WriteAction("\n\n");
		}

		public void Move(Location targetLocation)
		{
			CurrentLocation = targetLocation;
		}
	}
}