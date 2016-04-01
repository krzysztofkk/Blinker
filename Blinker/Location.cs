using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace Blinker
{
	public class Location
	{

		public Location(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public List<Location> Exits = new List<Location>();
		public List<Creature> Creatures = new List<Creature>();

		public string Name { get; set; }
		public string Description { get; set; }

		//gonna move that method to Player class soon
		public void CheckLocation()
		{
			 Writer.WriteInfo(string.Format("I am in the [{0}].\nIt's a {1}\n\n", Name, Description));
		}

		//this one too
		public void WhoIsThere()
		{
			if (Creatures.Any())
			{
				Writer.WriteInfo("You see ");
				foreach (Creature c in Creatures)
					Writer.WriteDialog("["+c.Name+"]"+", ");
				Writer.WriteInfo("there.\n\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.\n\n");
			}

		}
	}
}