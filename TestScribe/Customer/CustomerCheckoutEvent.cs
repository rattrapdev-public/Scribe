using System;
using System.Collections.Generic;
using RattrapDev.Scribe.Term;
using TestScribe.Store;

namespace TestScribe.Customer
{
    [DomainEvent("Customer Checkout", "An event indicating that the customer has checked out with the given items")]
    public class CustomerCheckoutEvent
    {
        public Name Name { get; set; }
        public DateTime Occurred => DateTime.UtcNow;
        public IEnumerable<StoreItem> PurchasedItems { get; set; }
    }
}
