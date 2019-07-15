using RattrapDev.Scribe.Term;

namespace TestScribe.Store
{
    [ValueObject("Store Metadata", "The metadata about the store including name and website")]
    public class StoreMetadata
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
