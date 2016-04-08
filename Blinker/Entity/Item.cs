namespace Blinker.Entity
{
	public class Item
	{
		public Item(string name)
		{
			Name = name;
		}

		public Item(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public string Name { get; set; }
		public string Description { get; set; }
	}
}