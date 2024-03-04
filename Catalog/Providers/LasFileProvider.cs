using lasReader.Features;
using System.IO;

namespace lasReader.Catalog.Providers
{
    public class LasFileProvider : ISourceProvider
    {
        public bool CanOpen(string path)
        {
            return path.EndsWith(".las");
        }

        public void Open(string path)
        {
            Document.Clear();
            Document.Feature = new Well();
            new LasFileReader(path);
        }
    }
}