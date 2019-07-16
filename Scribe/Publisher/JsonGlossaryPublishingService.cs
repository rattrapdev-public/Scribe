using Newtonsoft.Json;
using RattrapDev.Scribe.Compose;
using System;

namespace RattrapDev.Scribe.Publisher
{
    public class JsonGlossaryPublishingService : IGlossaryPublishingService
    {
        private readonly ICompositionService _compositionService;
        private readonly IGlossaryFileWriter _glossaryFileWriter;

        public JsonGlossaryPublishingService()
        {
            _compositionService = new CompositionService(new FileLoader());
            _glossaryFileWriter = new GlossaryFileWriter();
        }

        public JsonGlossaryPublishingService(ICompositionService compositionService, IGlossaryFileWriter glossaryFileWriter)
        {
            _compositionService = compositionService;
            _glossaryFileWriter = glossaryFileWriter;
        }

        public void Publish(GlossaryInputModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.DomainAssemblyFile))
            {
                throw new ArgumentException("The input Domain Assembly must be provided");
            }

            if (string.IsNullOrWhiteSpace(inputModel.GlossaryOutputFile))
            {
                throw new ArgumentException("A valid output file must be provided");
            }

            var glossary = _compositionService.CreateGlossary(inputModel.DomainAssemblyFile);

            var serializedGlossary = JsonConvert.SerializeObject(glossary);

            _glossaryFileWriter.WriteGlossaryToFile(serializedGlossary, inputModel.GlossaryOutputFile);
        }
    }
}
