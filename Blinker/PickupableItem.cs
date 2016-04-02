namespace Blinker
{
	public class PickupableItem : Item, IPickupable
	{
		public PickupableItem(string name, string description) : base(name, description)
		{
		}

		//add item to creature's inventory
		public PickupableItem(string name, string description, Creature creature) : base(name, description)
		{
			creature.Items.Add(this);
		}

		//add item to location
		public PickupableItem(string name, string description, Location location) : base(name, description)
		{
			location.PickupableItemList.Add(this);
		}
	}
}