namespace Blinker
{
	public class Weapon : PickupableItem
	{
		public int AttackValue;

		public Weapon(string name, string description, Creature creature, int attackValue) : base(name, description, creature)
		{
			AttackValue = attackValue;
		}

		public Weapon(string name, string description, Location location, int attackValue) : base(name, description, location)
		{
			AttackValue = attackValue;
		}
	}
}