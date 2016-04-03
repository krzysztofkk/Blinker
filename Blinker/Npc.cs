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
			Move(location);
		}

		public void Greet()
		{
			Writer.WriteDialog(string.Format("{0}: {1}\n\n", Name, _greeting));
		}

		public void Move(Location targetLocation)
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
	}
}