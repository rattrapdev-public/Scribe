namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Attribute for DDD Domain Event classes.
	/// </summary>
	public class DomainEvent : BaseDomainAttribute
	{
		public DomainEvent(string name, string definition)
			: base(name, definition)
		{
		}
	}
}

