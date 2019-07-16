using System.IO;

namespace RattrapDev.Scribe.Publisher
{
    public class GlossaryFileWriter : IGlossaryFileWriter
    {
        public void WriteGlossaryToFile(string fileContents, string outputFile)
        {
            File.WriteAllText(outputFile, fileContents);
        }
    }
}
