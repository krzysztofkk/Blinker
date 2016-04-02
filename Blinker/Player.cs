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
			Writer.WriteAction("> You are checking where you are.\n");
			Writer.WriteInfo("I am in the ");
			Writer.WriteLocation(string.Format("{0}\n", CurrentLocation.Name));
			Writer.WriteInfo(string.Format("It's a {0}.\n\n", CurrentLocation.Description));
		}

		public void CheckLocationExits()
		{
			Writer.WriteAction("> You are checking where you can go from here.\n");
			foreach(var exit in CurrentLocation.Exits)
				Writer.WriteLocation(exit.Name+", ");
			Writer.WriteInfo("\n\n");
		}

		public void CheckWhoIsThere()
		{
			Writer.WriteAction("> You take a quick look at the room.\n");
			if (CurrentLocation.NpcList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (var npc in CurrentLocation.NpcList)
					Writer.WriteDialog(npc.Name+", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.\n\n");
			}
		}

		public void CheckPickupableItemsThere()
		{
			Writer.WriteAction("> You take a look around you.\n");
			if (CurrentLocation.PickupableItemList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (var i in CurrentLocation.PickupableItemList)
					Writer.WriteItem(i.Name+ ", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("You don't see any pickupable items there.\n\n");
			}
		}

		public void CheckMyItems()
		{
			Writer.WriteAction("> You are checking your inventory. Available items:\n");
			foreach (var item in Items)
				Writer.WriteItem(item.Name+", ");
			Writer.WriteAction("\n\n");
		}

		public void Move(Location targetLocation)
		{
			if (targetLocation != CurrentLocation)
			{
				if (CurrentLocation.Exits.Contains(targetLocation))
				{
					Writer.WriteAction("> You are moving from ");
					Writer.WriteLocation(string.Format("{0}", CurrentLocation.Name));
					Writer.WriteAction(" to ");
					Writer.WriteLocation(string.Format("{0}\n\n", targetLocation.Name));
					CurrentLocation = targetLocation;
				}
				else
				{
					Writer.WriteAction("> You cannot go there.\n\n");
				}
			}
			else
			{
				Writer.WriteAction("> You are in that location already.\n\n");
			}
		}

		public void TalkTo(Npc someone)
		{
			if (CurrentLocation.NpcList.Contains(someone))
			{
				if (someone.IsAlive())
				{
					Writer.WriteAction(string.Format("> You talk to {0}.\n", someone.Name));
					someone.Greet();
				}
				else
				{
					Writer.WriteAction("> Cannot talk. ");
					Writer.WriteDialog(string.Format("{0}", someone.Name));
					Writer.WriteAction(" is dead.\n\n");
				}
			}
			else
			{
				Writer.WriteAction("> Cannot talk. ");
				Writer.WriteDialog(string.Format("{0}", someone.Name));
				Writer.WriteAction(" is not in ");
				Writer.WriteInfo(string.Format("{0}\n\n", CurrentLocation.Name));

			}
		}

		public void PickUpItem(PickupableItem item)
		{
			Writer.WriteAction("> You picked up ");
			Writer.WriteItem(string.Format("{0}\n\n", item.Name));
			CurrentLocation.PickupableItemList.Remove(item);
			Items.Add(item);
		}

		public void ThrowOutItem(PickupableItem item)
		{
			Writer.WriteAction("> You threw out ");
			Writer.WriteItem(string.Format("{0}\n\n", item.Name));
			Items.Remove(item);
			CurrentLocation.PickupableItemList.Add(item);
		}

		public void Attack(Creature target, int amount)
		{
			Writer.WriteAction("> You are trying to attack the target.\n");
			AttackTarget(target, amount);
		}
	}
}