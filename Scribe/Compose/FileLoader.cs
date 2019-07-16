using System;
using System.Collections.Generic;
using System.Reflection;

namespace RattrapDev.Scribe.Compose
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<Type> GetTypesFromAssembly(string assemblyFile)
        {
            var dll = Assembly.LoadFile(assemblyFile);
            return dll.GetExportedTypes();
        }
    }
}
