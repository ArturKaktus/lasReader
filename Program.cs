using System;
using System.Windows.Forms;

namespace lasReader
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            Document.MainForm = form;

            Application.Run(form);
           
        }
    }
}
