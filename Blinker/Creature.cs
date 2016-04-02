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
		}

		public string Name { get; private set; }

		public int Health { get; protected set; }

		public Location CurrentLocation { get; protected set; }

		public List<string> ReactionList { get; set; } = new List<string> {"..."};

		public bool IsAlive()
		{
			return (Health > 0);
		}

		public void ReceiveDamage(int amount)
		{
			if (IsAlive())
			{
				Health += amount;
				//gonna move it to player.AttackTarget(target) method
				//Writer.WriteActionHostile(string.Format("Target receives {0} damage.\n", amount));
				var reaction = ReactionList.PickRandom();
				Writer.WriteDialog(string.Format("{0}: {1}\n\n", Name, reaction));
			}

		}
	}
}