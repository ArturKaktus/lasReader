using lasReader.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lasReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuOpenFile_Click(object sender, EventArgs e)
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
                            dataset.Open(selectedFileName);
                            break;
                        }
                    }
                }
            }
        }
    }
}
