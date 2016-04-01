namespace Blinker
{
	public class Human : Creature
	{
		private int _health;
		private readonly string _name;

		public Human(int id, Location location, int health, string name) : base(id, location)
		{
			_health = health;
			_name = name;
		}

		public bool IsAlive()
		{
			return (_health > 0);
		}

		public override void Greet()
		{
			Writer.WriteDialog(string.Format("My name is {0}", _name));
		}
	}
}