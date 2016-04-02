namespace Blinker
{
	public class Player : Creature, IMover
	{

		public Player(string name, Location location) : base(name, location)
		{
			
		}


		public void Move(Location targetLocation)
		{
			CurrentLocation = targetLocation;
		}
	}
}