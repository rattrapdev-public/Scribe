using System;

namespace RattrapDev.Scribe.Term
{
	/// <summary>
	/// Base domain class used by other implementations.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public abstract class BaseDomainAttribute : Attribute
	{
		internal BaseDomainAttribute(string name)
			: this(name, string.Empty) 
		{ 
		}

		internal BaseDomainAttribute(string name, string definition)
		{
			Name = name;
			Definition = definition;
		}

		/// <summary>
		/// Gets or sets the Name of the class in long form.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the definitions of the Domain class.
		/// </summary>
		public string Definition { get; private set; }
	}
}

