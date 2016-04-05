using System;

namespace Blinker
{
	public class Npc : Creature, IMoveable
	{
		private readonly string _greeting;

		public Npc(string name, Location location) : base(name, location)
		{
			_greeting = " ... ";
			location.NpcList.Add(this);
			ReactionList.Clear();
			ReactionList.Add("Argh!");
		}

		public Npc(string name, string greeting, Location location) : base(name, location)
		{
			_greeting = greeting;
			ReactionList.Clear();
			ReactionList.Add("Argh!");
			MoveTo(location);
		}

		public void Greet()
		{
			Writer.WriteDialog(string.Format("{0}: {1}\n", Name, _greeting));
		}

		public void MoveTo(Location targetLocation)
		{
			CurrentLocation.NpcList.Remove(this);
			CurrentLocation = targetLocation;
			CurrentLocation.NpcList.Add(this);
		}

		public void Attack(Creature target)
		{
			Writer.WriteAction(string.Format("> {0} tries to attack {1}.\n", Name, target.Name));
			AttackTarget(target);
		}

		public new void EquipWeapon(Item weapon)
		{
			Writer.WriteAction(String.Format("> {0} is trying to equip a weapon.\n", Name));
			if (Items.Contains((PickupableItem)weapon))
			{
				base.EquipWeapon(weapon);
			}
			else
			{
				Writer.WriteInfo("Failed.\n\n");
			}
		}

		public new void UnequipWeapon(Item weapon)
		{
			Writer.WriteAction(string.Format("> {0} is trying to unequip a weapon.\n", Name));
			if (Items.Contains((PickupableItem)weapon))
			{
				base.UnequipWeapon(weapon);
			}
			else
			{
				Writer.WriteInfo("Failed.\n\n");
			}
		}
	}
}