using System;
using System.Drawing;
using System.Windows.Forms;

namespace pictures
{
    internal class RealImage : AbstractImage
    {
        private Point position;
        private bool isUpdate;

        internal RealImage(String name, Size size, Bitmap image, Action onCloseAction)
        {
            base.Create(name, size, image, onCloseAction);
            this.picture.Paint += new PaintEventHandler(this.picture_Paint);
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (isUpdate)
            {
                ImageUtils.DrawCircle(e, position);
                isUpdate = false;
            }
        }

        internal void SynchronizePosition(Point point)
        {
            isUpdate = point.X > -1 && point.Y > -1;
            position = point;
            this.picture.Invalidate();
        }
    }
}
