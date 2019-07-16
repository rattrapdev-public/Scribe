using System;
using System.Collections.Generic;
using System.Text;

namespace RattrapDev.Scribe.Compose
{
    public class AggregateRootModel : EntityModel
    {
        public List<string> Entities { get; set; } = new List<string>();
    }
}
