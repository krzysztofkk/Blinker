using System.Linq;

namespace Blinker
{
	public class Player : Creature, IMover
	{

		public Player(string name, Location location) : base(name, location)
		{
		}

		public void CheckLocationInfo()
		{
			Writer.WriteInfo(string.Format("I am in the [{0}].\nIt's a {1}.\n\n", CurrentLocation.Name, CurrentLocation.Description));
		}

		public void CheckWhoIsThere()
		{
			if (CurrentLocation.NpcList.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (Npc n in CurrentLocation.NpcList)
					Writer.WriteDialog("[" + n.Name + "]" + ", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.\n\n");
			}

		}

		public void Move(Location targetLocation)
		{
			CurrentLocation = targetLocation;
		}
	}
}