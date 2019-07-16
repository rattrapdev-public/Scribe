using System.Collections.Generic;

namespace RattrapDev.Scribe.Compose.Model
{
    public class Module
    {
        public string Name { get; set; }
        public List<AggregateRootModel> Aggregates { get; set; } = new List<AggregateRootModel>();
        public List<EntityModel> Entities { get; set; } = new List<EntityModel>();
        public List<ValueObjectModel> ValueObjects { get; set; } = new List<ValueObjectModel>();
        public List<DomainEventModel> DomainEvents { get; set; } = new List<DomainEventModel>();
        public List<DomainServiceModel> DomainServices { get; set; } = new List<DomainServiceModel>();
     }
}
