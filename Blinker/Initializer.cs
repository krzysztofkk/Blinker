namespace Blinker
{
	public static class Initializer
	{
		public static void Init()
		{
		}

		public static void DisplayInfo()
		{
			Writer.WriteLog("# INFO:\n");
			Writer.WriteInfo("Text");
			Writer.WriteInfo(" - an information message (i.e room description)\n");
			Writer.WriteAction("Text");
			Writer.WriteInfo(" - commited action (i.e picked up item, moved to another location\n");
			Writer.WriteDialog("Text");
			Writer.WriteInfo(" - a non player character\n");
			Writer.WriteLocation("Text");
			Writer.WriteInfo(" - a location (where you can possibly go)");
			Writer.WriteItem("Text");
			Writer.WriteInfo(" - an item (might be pickupable)\n");
			Writer.WriteLog("# END INFO\n\n");

		}

		public static void ConnectLocations(Location loc1, Location loc2)
		{
			loc1.Exits.Add(loc2);
			loc2.Exits.Add(loc1);
		}
	}
}