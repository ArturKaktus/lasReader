using lasReader.Features;

namespace lasReader
{
    //Статичный метод для хранения текущих данных
    //
    public static class Document
    {
        private static IFeature s_Feature;
        public static IFeature Feature
        {
            get => s_Feature;
            set
            {
                if (value == null && s_Feature != value)
                {
                    s_Feature = value;
                    //При изменении IFeature переотрисовывает картинку
                    //RefreshRender()
                }
            }
        }
    }
}