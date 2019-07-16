using NUnit.Framework;
using RattrapDev.Scribe.Compose;
using Shouldly;
using System.Linq;
using TestScribe.Customer;

namespace RattrapDev.Scribe.Tests.Compose
{
    public class FileLoaderTests
    {
        private const string InputAssembly = @"c:/temp/TestScribe.dll";

        [Test]
        public void LoadFile_returns_types()
        {
            var loader = new FileLoader();
            var dllList = loader.GetTypesFromAssembly(InputAssembly).ToList();
            dllList.Any(t => t.Name.Equals(typeof(Customer).Name)).ShouldBeTrue();
        }
    }
}
