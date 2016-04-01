namespace Blinker
{
	public abstract class Creature
	{
		private int _id;
		private Location _currentLocation;

		protected Creature(int id, Location location)
		{
			_id = id;
			_currentLocation = location;
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