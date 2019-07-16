using System.Collections.Generic;

namespace RattrapDev.Scribe.Compose.Model
{
    public class AggregateRootModel : EntityModel
    {
        public List<string> Entities { get; set; } = new List<string>();
    }
}
