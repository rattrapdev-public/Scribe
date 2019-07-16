namespace RattrapDev.Scribe.Publisher
{
    public interface IGlossaryFileWriter
    {
        void WriteGlossaryToFile(string fileContents, string outputFile);
    }
}
