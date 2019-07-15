namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Attribute for Entity DDD classes.  
	/// </summary>
	public class Entity : BaseDomainAttribute
	{
		public Entity(string name, string definition)
			: base(name, definition)
		{
        }

        public Entity(string name, string definition, string module)
            : base(name, definition, module)
        {
        }
    }
}

