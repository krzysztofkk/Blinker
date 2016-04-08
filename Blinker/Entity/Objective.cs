namespace Blinker.Entity
{
	public class Objective
	{
		//private int _id;
		public string Name;
		public string Description;
		public ObjectiveType Type;
		public bool IsCompleted;

		public Objective(string name, string description, ObjectiveType type)
		{
			Name = name;
			Description = description;
			Type = type;
			IsCompleted = false;
		}
	}
}