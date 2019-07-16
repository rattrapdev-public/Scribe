using RattrapDev.Scribe.Term;
using System.Collections.Generic;
using System.Linq;

namespace RattrapDev.Scribe.Compose.Model
{
    public class Glossary
    {
        public List<Module> Modules { get; set; } = new List<Module>();

        public Module CreateOrGetModuleFrom(BaseDomainAttribute term)
        {
            if (!Modules.Any(m => m.Name == term.Name))
            {
                Modules.Add(new Module { Name = term.Module });
            }

            return Modules.First(m => m.Name == term.Module);
        }
    }
}
