namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Attribute for DDD Value Object classes.
	/// </summary>
	public class ValueObject : BaseDomainAttribute
	{
		public ValueObject(string name, string definition)
			: base(name, definition)
		{
		}

        public ValueObject(string name, string definition, string module)
            : base(name, definition, module)
        {
        }
	}
}

