using NUnit.Framework;
using RattrapDev.Scribe.Term;
using Shouldly;

namespace RattrapDev.Scribe.Tests
{
	[TestFixture]
	public class ValueObjectClassAttributionTests
	{
		[Test]
		public void Attribution_sets_name_and_definition()
		{
			var attributes = typeof(TestValueObject).GetCustomAttributes(true);
			var valueObjectTerm = (ValueObject)attributes[0];
            valueObjectTerm.Name.ShouldBe("Value");
            valueObjectTerm.Definition.ShouldBe("Definition");
            valueObjectTerm.Module.ShouldBe("Module");
        }

		[ValueObject("Value", "Definition", "Module")]
		private class TestValueObject 
		{
		}
	}
}

