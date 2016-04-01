namespace Blinker
{
	public abstract class Creature
	{
		private Location _currentLocation;

		protected Creature(string name, Location location)
		{
			Name = name;
			Health = 100;
			_currentLocation = location;
		}

		public string Name { get; private set; }

		public int Health { get; private set; }

		public Location CurrentLocation
		{
			get {  return _currentLocation; }
			set
			{
				_currentLocation.Creatures.Remove(this);
				_currentLocation = value;
				_currentLocation.Creatures.Add(this);
			}
		}

		public bool IsAlive()
		{
			return (Health > 0);
		}
	}
}