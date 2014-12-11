using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace motDet
{
    public partial class programSettings : Form
    {
        public static bool useOpeningFilter = true;// 1     -Order in save file
        public static bool useEdgesFilter = true;// 2

        public static Point minRequiredBlobSize = new Point(15,15); // 3, 4

        private Bitmap exampleFrame;
        private int startX = 0;
        private int startY = 0;

        public programSettings(Bitmap testFrame)
        {
            InitializeComponent();
            KeyPreview = true;
            if (testFrame != null)
            {
                exampleFrame = (Bitmap)testFrame.Clone();
                pictureBox1.Image = exampleFrame;
            }

            edgesFilterBox.Checked = useEdgesFilter;
            openingFilterBox.Checked = useOpeningFilter;
           // minRequiredBlobSize = new Point(15, 15);
            xSize.Text = minRequiredBlobSize.X.ToString();
            ySize.Text = minRequiredBlobSize.Y.ToString();

            startX = (pictureBox1.Width / 2) - (minRequiredBlobSize.X / 2);
            startY = (pictureBox1.Height / 2) - (minRequiredBlobSize.Y / 2);
        }

        private void edgesFilterBox_CheckedChanged(object sender, EventArgs e)
        {
            useEdgesFilter = edgesFilterBox.Checked;
        }

        private void openingFilterBox_CheckedChanged(object sender, EventArgs e)
        {
            useOpeningFilter = openingFilterBox.Checked;
        }

        private void requiredSizeSubmit_Click(object sender, EventArgs e)
        {
            minRequiredBlobSize = new Point(Convert.ToInt32(xSize.Text), Convert.ToInt32(ySize.Text));
            startX = (pictureBox1.Width / 2) - (minRequiredBlobSize.X / 2);
            startY = (pictureBox1.Height / 2) - (minRequiredBlobSize.Y / 2);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(startX, startY, minRequiredBlobSize.X, minRequiredBlobSize.Y));
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X - (minRequiredBlobSize.X / 2) > 0)
                startX = e.X - (minRequiredBlobSize.X / 2);
            if (e.Y - (minRequiredBlobSize.Y / 2) > 0)
                startY = e.Y - (minRequiredBlobSize.Y / 2);
            pictureBox1.Refresh();
        }


        private void programSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                minRequiredBlobSize.Y++;
            if (e.KeyCode == Keys.S)
                minRequiredBlobSize.Y--;
            if (e.KeyCode == Keys.D)
                minRequiredBlobSize.X++;
            if (e.KeyCode == Keys.A)
                minRequiredBlobSize.X--;

            xSize.Text = minRequiredBlobSize.X.ToString();
            ySize.Text = minRequiredBlobSize.Y.ToString();

            pictureBox1.Refresh();
        }
    }
}
