namespace Blinker
{
	public class Npc : Creature
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
			Writer.WriteDialog(string.Format("[{0}]: {1}\n", Name, _greeting));
		}
	}
}