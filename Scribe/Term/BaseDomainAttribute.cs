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
            : this(name, definition, string.Empty)
		{
        }

        internal BaseDomainAttribute(string name, string definition, string module)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name must be provided");
            }

            Name = name;
            Definition = definition;
            Module = module;
        }

        /// <summary>
        /// Gets or sets the Name of the class in long form.
        /// </summary>
        public string Name { get; private set; }

		/// <summary>
		/// Gets the definition of the Domain class.
		/// </summary>
		public string Definition { get; private set; }

        /// <summary>
        /// Gets the module of the Domain class.
        /// </summary>
        public string Module { get; private set; }
    }
}

