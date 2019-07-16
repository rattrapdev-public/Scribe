using NUnit.Framework;
using RattrapDev.Scribe.Compose;
using Shouldly;
using System.IO;
using System.Linq;
using TestScribe.Customer;

namespace RattrapDev.Scribe.Tests.Compose
{
    public class FileLoaderTests
    {
        private const string InputAssembly = @"TestScribe.dll";

        [Test]
        public void LoadFile_returns_types()
        {
            var loader = new FileLoader();
            var directory = Directory.GetCurrentDirectory() + "/../../../../Sample/";
            var dllList = loader.GetTypesFromAssembly(directory + InputAssembly).ToList();
            dllList.Any(t => t.Name.Equals(typeof(Customer).Name)).ShouldBeTrue();
        }
    }
}
