namespace Blinker
{
	public abstract class Creature
	{
		private int _id;
		private string _name;
		private Location _currentLocation;

		protected Creature(int id, string name, Location location)
		{
			_id = id;
			_name = name;
			_currentLocation = location;
		}

		public string Name
		{
			get { return _name; }
			private set { _name = value; }
		}

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

		public abstract void Greet();
	}
}