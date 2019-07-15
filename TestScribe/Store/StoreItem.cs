using RattrapDev.Scribe.Term;

namespace TestScribe.Store
{
    [ValueObject("Store Item", "An item available for purchase")]
    public class StoreItem
    {
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
