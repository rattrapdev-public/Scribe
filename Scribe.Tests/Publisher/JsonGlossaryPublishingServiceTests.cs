using AutoFixture;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.Scribe.Compose;
using RattrapDev.Scribe.Compose.Model;
using RattrapDev.Scribe.Publisher;
using Shouldly;
using System;

namespace RattrapDev.Scribe.Tests.Publisher
{
    public class JsonGlossaryPublishingServiceTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Publish_invalid_DomainAssemblyFile_throws_exception(string invalidDomainAssembly)
        {
            var inputModel = new GlossaryInputModel { DomainAssemblyFile = invalidDomainAssembly, GlossaryOutputFile = "output.json" };

            var sut = new JsonGlossaryPublishingService();

            Should.Throw<ArgumentException>(() => sut.Publish(inputModel));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Publish_invalid_GlossaryOutputFile_throws_exception(string invalidGlossaryOutputFile)
        {
            var inputModel = new GlossaryInputModel { DomainAssemblyFile = "c:/temp/dll", GlossaryOutputFile = invalidGlossaryOutputFile };

            var sut = new JsonGlossaryPublishingService();

            Should.Throw<ArgumentException>(() => sut.Publish(inputModel));
        }

        [Test]
        public void Publish_publishes_file_to_GlossaryFileWriter()
        {
            // Arrange

            var fixture = new Fixture();
            var glossary = fixture.Create<Glossary>();
            var serializedGlossary = JsonConvert.SerializeObject(glossary);
            var inputModel = fixture.Create<GlossaryInputModel>();

            var compositionService = Substitute.For<ICompositionService>();
            compositionService.CreateGlossary(Arg.Any<string>()).Returns(glossary);

            string glossaryOutput = string.Empty;
            var fileWriter = Substitute.For<IGlossaryFileWriter>();
            fileWriter.WriteGlossaryToFile(Arg.Do<string>(s => glossaryOutput = s), Arg.Any<string>());

            var sut = new JsonGlossaryPublishingService(compositionService, fileWriter);

            // Act

            sut.Publish(inputModel);

            // Assert

            glossaryOutput.ShouldBe(serializedGlossary);
        }
    }
}
