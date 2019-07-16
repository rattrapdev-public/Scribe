using System;
using System.Collections.Generic;
using System.Text;

namespace RattrapDev.Scribe.Compose
{
    public interface IFileLoader
    {
        IEnumerable<Type> GetTypesFromAssembly(string assemblyFile);
    }
}
