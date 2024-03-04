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
            Document.Open();
        }

        private void Grid_pictureBox_SizeChanged(object sender, EventArgs e)
        {
            Graphics g = Grid_pictureBox.CreateGraphics();
            Pen pen = new Pen(Color.Black);

            int cellWidth = 20;
            int cellHeight = 20;

            for (int x = 0; x < Grid_pictureBox.Width; x += cellWidth)
            {
                g.DrawLine(pen, x, 0, x, Grid_pictureBox.Height);
            }

            for (int y = 0; y < Grid_pictureBox.Height; y += cellHeight)
            {
                g.DrawLine(pen, 0, y, Grid_pictureBox.Width, y);
            }
        }
    }
}
