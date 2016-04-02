namespace Blinker
{
	public static class Initializer
	{
		public static void Init()
		{
		}

		public static void ConnectLocations(Location loc1, Location loc2)
		{
			loc1.Exits.Add(loc2);
			loc2.Exits.Add(loc1);
		}
	}
}