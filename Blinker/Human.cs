namespace Blinker
{
	public class Human : Creature
	{
		private int _health;
		private string _greeting;

		public Human(int id, string name, Location location) : base(id, name, location)
		{
			_health = 100;
			_greeting = " ... ";
		}

		public Human(int id, string name, string greeting, Location location) : base(id, name, location)
		{
			_health = 100;
			_greeting = greeting;
		}

		public bool IsAlive()
		{
			return (_health > 0);
		}

		public override void Greet()
		{
			Writer.WriteDialog(string.Format("[{0}]: {1}\n", Name, _greeting));
		}
	}
}