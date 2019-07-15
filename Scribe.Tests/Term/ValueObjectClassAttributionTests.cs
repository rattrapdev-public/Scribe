using NUnit.Framework;
using RattrapDev.Scribe.Term;

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
			Assert.That(valueObjectTerm.Name, Is.EqualTo("Value"));
			Assert.That(valueObjectTerm.Definition, Is.EqualTo("Definition"));
		}

		[ValueObject("Value", "Definition")]
		private class TestValueObject 
		{
		}
	}
}

