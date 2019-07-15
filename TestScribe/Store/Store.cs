using RattrapDev.Scribe.Term;
using System.Collections.Generic;

namespace TestScribe.Store
{
    [AggregateRoot("Store", "A place where Store Items can be purchased")]
    public class Store
    {
        public StoreMetadata Metadata { get; set; }
        public Inventory Inventory { get; set; }

        [CommandMethod("Process Transaction", "Add items to the inventory that have been purchased")]
        public void ProcessTransaction(IEnumerable<StoreItem> items) { }
    }
}
