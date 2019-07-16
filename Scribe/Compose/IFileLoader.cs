using System;
using System.Collections.Generic;

namespace RattrapDev.Scribe.Compose
{
    public interface IFileLoader
    {
        IEnumerable<Type> GetTypesFromAssembly(string assemblyFile);
    }
}
