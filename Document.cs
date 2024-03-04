using lasReader.Features;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lasReader
{
    //Статичный метод для хранения текущих данных
    //
    public static class Document
    {
        public static Form MainForm { get; set; }
        private static string m_Name;
        public static string Name 
        {
            get => m_Name;
            set
            {
                m_Name = value;
                MainForm.Text = m_Name;
            }
        }

        private static IFeature s_Feature;
        public static IFeature Feature
        {
            get => s_Feature;
            set
            {
                s_Feature = value;
                    //При изменении IFeature переотрисовывает картинку
                    //RefreshRender()
            }
        }
        public static void Open()
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Все файлы|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;
                    var datasets = Factory.SourceProvidersFactory;

                    foreach (var dataset in datasets)
                    {
                        if (dataset.CanOpen(selectedFileName))
                        {
                            Name = Path.GetFileName(selectedFileName);
                            dataset.Open(selectedFileName);
                            break;
                        }
                    }
                }
            }
            Render();
        }
        private static void Render()
        {
            //Вывод полученного
            string message = string.Empty;
            if (Feature is IWell w)
            {
                message = "Version\n";
                foreach (var a in w.VersionDatas)
                {
                    message += a.ToString() + "\n";
                }
                message = "\nWell\n";
                foreach (var a in w.WellDatas)
                {
                    message += a.ToString() + "\n";
                }
                message = "\nParameter\n";
                foreach (var a in w.ParameterDatas)
                {
                    message += a.ToString() + "\n";
                }
                message = "\nCurve\n";
                foreach (var a in w.CurveDatas)
                {
                    message += a.ToString() + "\n";
                }
            }
            MessageBox.Show(message);
        }
        public static void Clear()
        {
            Feature?.Clear();
        }
    }
}