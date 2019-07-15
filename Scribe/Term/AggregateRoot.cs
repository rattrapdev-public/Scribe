namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Attribute for Aggregate Root DDD classes.
	/// </summary>
	public class AggregateRoot : Entity
	{
		public AggregateRoot(string name, string definition)
			: base(name, definition)
		{
		}
	}
}

