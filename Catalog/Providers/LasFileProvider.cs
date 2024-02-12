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
            var lfr = new LasFileReader(path);
            //дальнейшая работа с полученными данными
        }
    }
}