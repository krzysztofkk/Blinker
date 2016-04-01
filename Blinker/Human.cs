namespace Blinker
{
	public class Human : Creature
	{
		private int _health;


		public Human(int id, string name, Location location, int health) : base(id, name, location)
		{
			_health = health;
		}

		public bool IsAlive()
		{
			return (_health > 0);
		}

		public override void Greet()
		{
			Writer.WriteDialog(string.Format("[{0}]: My name is {1}\n", Name, Name));
		}
	}
}