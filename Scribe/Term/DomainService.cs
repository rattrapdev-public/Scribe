namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Attribute for DDD Domain Service classes.
	/// </summary>
	public class DomainService : BaseDomainAttribute
	{
		public DomainService(string name, string definition)
			: base(name, definition)
		{
		}
	}
}

