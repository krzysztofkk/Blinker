using System;
using System.Collections.Generic;

namespace Blinker.Entity
{
	public abstract class Creature
	{
		static readonly Random Random = new Random();
		protected Creature(string name, Location location)
		{
			Name = name;
			Health = 100;
			CurrentLocation = location;
			Strength = 10;
		}

		public string Name { get; private set; }

		public int Health { get; protected set; }

		public int Strength { get; private set; }

		public Location CurrentLocation { get; protected set; }

		public List<string> ReactionList { get; set; } = new List<string> {"..."};

		public List<PickupableItem> Items { get; set; } = new List<PickupableItem>(); 

		public Weapon EquipedWeapon { get; private set; }

		public bool IsAlive()
		{
			return (Health > 0);
		}

		private void ReceiveDamage(int amount)
		{
			if (IsAlive())
			{
				Health -= amount;
				if (IsAlive())
				{
					var reaction = ReactionList[Random.Next(ReactionList.Count)];
					Writer.WriteDialog(string.Format("{0}: {1}\n", Name, reaction));
				}
				if (!IsAlive())
				{
					Writer.WriteDialog(Name);
					Writer.WriteActionHostile(" has been killed.\n");
				}
			}
			else
			{
				Writer.WriteDialog(Name);
				Writer.WriteInfo(" is dead already.\n");
			}
		}

		protected int CalculateHit()
		{
			var rnd = Random.Next(-Strength/2, Strength/2);
			if (EquipedWeapon != null)
				return Strength + EquipedWeapon.AttackValue + rnd;
			return Strength + rnd;
		}

		protected void AttackTarget(Creature target)
		{
			var amount = CalculateHit();
			if (IsAlive())
			{
				Writer.WriteActionHostile("Target ");
				Writer.WriteDialog(target.Name);
				Writer.WriteActionHostile(" suffers "+amount+" damage from ");
				Writer.WriteDialog(Name);
				Writer.WriteActionHostile("'s attack with ");
				if(EquipedWeapon != null)
					Writer.WriteItem(EquipedWeapon.Name+".\n");
				else
					Writer.WriteActionHostile("bare hands.\n");
				target.ReceiveDamage(amount);
			}
		}

		protected void EquipWeapon(Item weapon)
		{
			if (Items.Contains((PickupableItem)weapon))
			{
				if (weapon is Weapon)
				{
					if (EquipedWeapon != null)
						UnequipWeapon(EquipedWeapon);
					EquipedWeapon = (Weapon)weapon;
					Writer.WriteDialog(Name);
					Writer.WriteInfo(" equips ");
					Writer.WriteItem(weapon.Name+"\n\n");
				}
				else
				{
					Writer.WriteInfo("Cannot equip that.\n\n");
				}
			}
		}

		protected void UnequipWeapon(Item weapon)
		{
			if (EquipedWeapon == weapon)
			{
				EquipedWeapon = null;
				Writer.WriteDialog(Name);
				Writer.WriteInfo(" unequips ");
				Writer.WriteItem(weapon.Name+"\n\n");
			}
		}
	}
}