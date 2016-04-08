using System.Linq;

namespace Blinker
{
	public class Player : Creature, IMoveable
	{
		public Player(string name, Location location) : base(name, location)
		{
		}

		public void CheckLocationInfo()
		{
			Writer.WriteAction("> You are checking where you are.\n");
			Writer.WriteInfo("I am in the ");
			Writer.WriteLocation(CurrentLocation.Name+"\n"));
			Writer.WriteInfo("It's a "+CurrentLocation.Description+".\n");
		}

		public void CheckLocationExits()
		{
			Writer.WriteAction("> You are checking where you can go from here.\n");
			var index = 0;
			foreach (var exit in CurrentLocation.Exits)
			{
				if (index > 0) Writer.WriteInfo(", ");
				Writer.WriteLocation(exit.Name);
				index++;
			}
			Writer.WriteInfo("\n");
		}

		public void CheckWhoIsThere()
		{
			Writer.WriteAction("> You take a quick look.\n");
			if (CurrentLocation.NpcList.Any())
			{
				Writer.WriteInfo("You see ");
				var index = 0;
				foreach (var npc in CurrentLocation.NpcList)
				{
					if (index > 0) Writer.WriteInfo(", ");
					Writer.WriteDialog(npc.Name);
					if(!npc.IsAlive())
						Writer.WriteInfo("(dead)");
					index++;
				}
				Writer.WriteInfo(" there.\n");
			}
			else
			{
				Writer.WriteInfo("The location is empty.\n");
			}
		}

		public void CheckPickupableItemsThere()
		{
			Writer.WriteAction("> You take a look around you.\n");
			if (CurrentLocation.PickupableItemList.Any())
			{
				Writer.WriteInfo("You see ");
				var index = 0;
				foreach (var i in CurrentLocation.PickupableItemList)
				{
					if (index > 0) Writer.WriteInfo(", ");
					Writer.WriteItem(i.Name);
					index++;
				}
				Writer.WriteInfo(" there.\n");
			}
			else
			{
				Writer.WriteInfo("You don't see any pickupable items there.\n");
			}
		}

		public void CheckInventory()
		{
			Writer.WriteAction("> You are checking your inventory. Available items:\n");
			var index = 0;
			foreach (var item in Items)
			{
				if (index > 0) Writer.WriteInfo(", ");
				Writer.WriteItem(item.Name);
				index++;
			}
			if(Items.Count == 0)
				Writer.WriteInfo("nothing");
			Writer.WriteAction("\n");
		}

		public void CheckItemDetails(Item item)
		{
			Writer.WriteAction("> You take a look at ");
			Writer.WriteItem(item.Name+"\n");
			Writer.WriteInfo("It's "+item.Description+".\n");
			if (item is Weapon)
			{
				var weapon = item as Weapon;
				Writer.WriteInfo("It has "+weapon.AttackValue+" attack points.\n");
			}
		}

		public void MoveTo(Location targetLocation)
		{
			if (targetLocation != CurrentLocation)
			{
				if (CurrentLocation.Exits.Contains(targetLocation))
				{
					Writer.WriteAction("> You are moving from ");
					Writer.WriteLocation(CurrentLocation.Name);
					Writer.WriteAction(" to ");
					Writer.WriteLocation(targetLocation.Name+"\n\n");
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

		public void TalkTo(Npc npc)
		{
			if (CurrentLocation.NpcList.Contains(npc))
			{
				if (npc.IsAlive())
				{
					Writer.WriteAction("> You talk to "+npc.Name+".\n");
					npc.Greet();
				}
				else
				{
					Writer.WriteAction("> Cannot talk. ");
					Writer.WriteDialog(npc.Name);
					Writer.WriteAction(" is dead.\n\n");
				}
			}
			else
			{
				Writer.WriteAction("> Cannot talk. ");
				Writer.WriteDialog(npc.Name);
				Writer.WriteAction(" is not in ");
				Writer.WriteInfo(CurrentLocation.Name+"\n\n");

			}
		}

		public void PickUpItem(PickupableItem item)
		{
			Writer.WriteAction("> You picked up ");
			Writer.WriteItem(item.Name+"\n\n");
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

		public void Attack(Creature target)
		{
			Writer.WriteAction("> You are trying to attack the target.\n");
			AttackTarget(target);
		}

		public new void EquipWeapon(Item weapon)
		{
			Writer.WriteAction("> You are trying to equip a weapon.\n");
			if (Items.Contains(weapon))
			{
				base.EquipWeapon(weapon);
			}
			else
			{
				Writer.WriteInfo("You don't have this item.\n");
			}
		}

		public new void UnequipWeapon(Item weapon)
		{
			Writer.WriteAction("> You are trying to unequip a weapon.\n");
			if (Items.Contains(weapon))
			{
				base.UnequipWeapon(weapon);
			}
			else
			{
				Writer.WriteInfo("You don't have this item.\n");
			}
		}
	}
}