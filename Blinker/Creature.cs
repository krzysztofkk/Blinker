﻿using System;
using System.Collections.Generic;

namespace Blinker
{
	public abstract class Creature
	{
		static Random _random = new Random();
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

		public Weapon EquipedWeapon { get; set; }

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
					var reaction = ReactionList[_random.Next(ReactionList.Count)];
					Writer.WriteDialog(string.Format("{0}: {1}\n\n", Name, reaction));
				}
				if (!IsAlive())
				{
					Writer.WriteDialog(string.Format("{0}", Name));
					Writer.WriteActionHostile(" has been killed.\n\n");
				}
			}
			else
			{
				Writer.WriteDialog(string.Format("{0}", Name));
				Writer.WriteInfo(" is dead already.\n\n");
			}
		}

		protected int CalculateHit()
		{
			if (EquipedWeapon != null)
				return Strength + EquipedWeapon.AttackValue;
			return Strength;
		}

		protected void AttackTarget(Creature target)
		{
			var amount = CalculateHit();
			if (IsAlive())
			{
				Writer.WriteActionHostile("Target ");
				Writer.WriteDialog(string.Format("{0}", target.Name));
				Writer.WriteActionHostile(string.Format(" suffers {0} damage from ", amount));
				Writer.WriteDialog(string.Format("{0}", Name));
				Writer.WriteActionHostile("'s attack with ");
				if(EquipedWeapon != null)
					Writer.WriteItem(EquipedWeapon.Name+".\n");
				else
					Writer.WriteActionHostile("bare hands.\n");
				target.ReceiveDamage(amount);
			}
		}
	}
}