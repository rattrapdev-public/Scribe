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

        public DomainEvent(string name, string definition, string module)
            : base(name, definition, module)
        {
        }
    }
}

