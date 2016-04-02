namespace Blinker
{
	public class PickupableItem : Item, IPickupable
	{

		//add item to player's inventory
		public PickupableItem(string name, string description, Player player) : base(name, description)
		{
			player.Items.Add(this);
		}

		//add item to npc's inventory
		public PickupableItem(string name, string description, Npc npc) : base(name, description)
		{
		}

		//add item to location
		public PickupableItem(string name, string description, Location location) : base(name, description)
		{
			location.PickupableItemList.Add(this);
		}
	}
}