using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace Blinker
{
	public class Location
	{
		private string _name;
		private string _description;

		public Location(string name, string description)
		{
			_name = name;
			_description = description;
		}

		public List<Location> Exits = new List<Location>();
		public List<Creature> Creatures = new List<Creature>();

		public string Name { get; private set; }
		public string Description { get; private set; }

		//gonna move that method to Player class soon
		public void CheckLocation()
		{
			 Writer.WriteInfo(string.Format("I am in a {0}. {1}", Name, Description));
		}

		//this one too
		public void WhoIsThere()
		{
			if (Creatures.Any())
			{
				Writer.WriteInfo("You can see ");
				foreach (Creature c in Creatures)
					Writer.WriteDialog("["+c.Name+"]"+", ");
				Writer.WriteInfo("there.\n");
			}
			else
			{
				Writer.WriteInfo("The room is empty.");
			}

		}
	}
}