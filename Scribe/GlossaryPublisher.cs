using RattrapDev.Scribe.Publisher;

namespace RattrapDev.Scribe
{
    public static class GlossaryPublisher
    {
        public static void WriteGlossary(string domainAssembly, string outputFile)
        {
            var publisher = new JsonGlossaryPublishingService();

            var inputModel = new GlossaryInputModel { DomainAssemblyFile = domainAssembly, GlossaryOutputFile = outputFile };

            publisher.Publish(inputModel);
        }
    }
}
