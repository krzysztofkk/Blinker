namespace Blinker
{
	public class Npc : Creature, IMoveable
	{
		private readonly string _greeting;

		public Npc(string name, Location location) : base(name, location)
		{
			_greeting = " ... ";
		}

		public Npc(string name, string greeting, Location location) : base(name, location)
		{
			_greeting = greeting;
		}

		public void Greet()
		{
			Writer.WriteDialog(string.Format("[{0}]: {1}\n\n", Name, _greeting));
		}

		public void Move(Location targetLocation)
		{
			CurrentLocation.NpcList.Remove(this);
			CurrentLocation = targetLocation;
			CurrentLocation.NpcList.Add(this);
		}
	}
}