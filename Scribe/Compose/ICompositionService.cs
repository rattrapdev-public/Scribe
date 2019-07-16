using RattrapDev.Scribe.Compose.Model;

namespace RattrapDev.Scribe.Compose
{
    public interface ICompositionService
    {
        Glossary CreateGlossary(string domainAssembly);
    }
}
