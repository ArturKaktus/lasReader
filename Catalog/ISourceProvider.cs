namespace lasReader.Catalog
{
    public interface ISourceProvider
    {
        /// <summary>
        /// Проверка доступности
        /// </summary>
        bool CanOpen(string path);

        /// <summary>
        /// Открытие
        /// </summary>
        void Open(string path);

    }
}