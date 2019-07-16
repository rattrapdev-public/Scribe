using System.Collections.Generic;

namespace RattrapDev.Scribe.Compose.Model
{
    public class CommandMethodModel
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public List<string> Events { get; set; }
    }
}
