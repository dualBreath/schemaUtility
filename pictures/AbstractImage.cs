using System;
using System.Drawing;
using System.Windows.Forms;

namespace pictures
{
    internal abstract class AbstractImage
    {
        protected PictureBox picture;
        private Action onCloseAction;
        private Form window;
        private bool isClosed;
        private Bitmap originalImage;

        internal void Create(String name, Size size, Bitmap image, Action onCloseAction)
        {
            this.onCloseAction = onCloseAction;
            originalImage = image;
            window = new Form
            {
                Text = name,
                Size = size
            };
            picture = new PictureBox
            {
                Size = size,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = originalImage
            };
            window.Controls.Add(picture);
            window.FormClosed += new FormClosedEventHandler(window_FormClosed);
            window.FormBorderStyle = FormBorderStyle.FixedSingle;
            window.Show();
        }

        internal void Close()
        {
            if (!isClosed)
            {
                isClosed = true;
                window.Close();
            }
        }

        internal bool IsClosed()
        {
            return isClosed;
        }

        internal void Redraw(DrawParameters parameters)
        {
            int scale = parameters.Scale;
            int selection = parameters.Selection;

            if (scale == 0 || selection == -1)
            {
                picture.Image = originalImage;
            } else
            {
                Bitmap copyImage = new Bitmap(originalImage);
                Rectangle rect = ImageUtils.GetSelectedRectangle(copyImage.Width, copyImage.Height, scale, selection);
                copyImage = copyImage.Clone(rect, copyImage.PixelFormat);
                picture.Image = copyImage;
            }
            picture.Refresh();
        }

        private void window_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
            onCloseAction();
        }
    }
}
