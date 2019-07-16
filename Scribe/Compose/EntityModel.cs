using System;
using System.Collections.Generic;
using System.Text;

namespace RattrapDev.Scribe.Compose
{
    public class EntityModel
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<string> ValueObjects { get; set; } = new List<string>();
        public List<CommandMethodModel> CommandMethods { get; set; } = new List<CommandMethodModel>();
    }
}
