using AutoFixture;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.Scribe.Compose;
using RattrapDev.Scribe.Compose.Model;
using RattrapDev.Scribe.Publisher;
using Shouldly;
using System;
using System.IO;

namespace RattrapDev.Scribe.Tests.Publisher.Integration
{
    public class JsonGlossaryPublishingServiceIntegrationTests
    {
        private const string InputAssembly = @"TestScribe.dll";

        [Test]
        public void Publish_publishes_file_to_GlossaryFileWriter()
        {
            // Arrange

            var directory = Directory.GetCurrentDirectory() + "/../../../../Sample/";
            var outputFile = directory + "output.json";
            var sut = new JsonGlossaryPublishingService();
            var inputModel = new GlossaryInputModel { DomainAssemblyFile = directory + InputAssembly, GlossaryOutputFile = outputFile };

            // Act

            sut.Publish(inputModel);

            // Assert

            var outputContents = File.ReadAllText(outputFile);
            outputContents.Contains("Customer").ShouldBeTrue();
        }
    }
}
