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
			Writer.WriteAction("You are checking where you are.\n");
			Writer.WriteInfo(string.Format("I am in the [{0}].\nIt's a {1}.\n\n", CurrentLocation.Name, CurrentLocation.Description));
		}

		public void CheckWhoIsThere()
		{
			Writer.WriteAction("You take a quick look at the room.\n");
			if (CurrentLocation.NpcList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (var npc in CurrentLocation.NpcList)
					Writer.WriteDialog("[" + npc.Name + "]" + ", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.\n\n");
			}
		}

		public void CheckPickupableItemsThere()
		{
			Writer.WriteAction("You take a look around you.\n");
			if (CurrentLocation.PickupableItemList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (var i in CurrentLocation.PickupableItemList)
					Writer.WriteInfo("[" + i.Name + "]" + ", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("You don't see any pickupable items there.\n\n");
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
			if (targetLocation != CurrentLocation)
			{
				Writer.WriteAction(string.Format("You are moving from {0} to {1}.\n", CurrentLocation.Name, targetLocation.Name));
				CurrentLocation = targetLocation;
			}
			else
			{
				Writer.WriteAction("You are in that location already.\n");
			}
		}

		public void TalkTo(Npc someone)
		{
			Writer.WriteAction(string.Format("You talk to {0}.\n", someone.Name));
			someone.Greet();
		}

		public void PickUpItem(PickupableItem item)
		{
			Writer.WriteAction("You picked up ");
			Writer.WriteInfo(string.Format("[{0}]\n\n", item.Name));
			CurrentLocation.PickupableItemList.Remove(item);
			Items.Add(item);
		}
	}
}