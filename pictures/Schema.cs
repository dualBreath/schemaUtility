using System;
using System.Drawing;
using System.Windows.Forms;

namespace pictures
{
    class Schema : AbstractImage
    {
        private ComboBox selector;
        private PictureBox preview;
        private int scale;
        private Size processingSize;
        private Size windowSize;
        private Size imageBoxSize;
        private int selection;
        private Form windowControl;
        private Action onCloseAction;
        private Action<DrawParameters> OnRedraw;
        private Action<Point> SynchronizePosition;
        private volatile bool isCursorHidden;
        private Point currentPosition;

        internal Schema(String name, Size size, Bitmap image, Action onCloseAction, Action<DrawParameters> OnRedraw, Action<Point> SynchronizePosition)
        {
            this.onCloseAction = onCloseAction;
            this.OnRedraw = OnRedraw;
            this.SynchronizePosition = SynchronizePosition;

            if (size.Height > size.Width)
            {
                processingSize.Height = 100;
                processingSize.Width = 70;
                windowSize.Height = 438;
                windowSize.Width = 312;
                imageBoxSize.Height = 400;
                imageBoxSize.Width = 300;
            } else
            {
                processingSize.Height = 70;
                processingSize.Width = 100;
                windowSize.Height = 336;
                windowSize.Width = 414;
                imageBoxSize.Height = 300;
                imageBoxSize.Width = 400;
            }
            
            base.Create(name, size, image, OnClose);
            this.picture.MouseDoubleClick += new MouseEventHandler(this.picture_MouseDoubleClick);
            this.picture.MouseEnter += new EventHandler(this.picture_MouseEnter);
            this.picture.MouseLeave += new EventHandler(this.picture_MouseLeave);
            this.picture.MouseMove += new MouseEventHandler(this.picture_MouseMove);
            this.picture.Paint += new PaintEventHandler(this.picture_Paint);
            selection = -1;
        }

        private void picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (windowControl == null)
            {
                windowControl = new Form
                {
                    Size = windowSize,
                    FormBorderStyle = FormBorderStyle.FixedSingle
                };
                MaximizeForm(windowControl);

                selector = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DataSource = new int[] { 2, 4, 8, 16 },
                    Visible = true
                };
                selector.SelectionChangeCommitted += new EventHandler(selector_SelectionChangeCommitted);

                preview = new PictureBox
                {
                    Size = imageBoxSize,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = false
                };
                preview.MouseClick += new MouseEventHandler(this.preview_MouseClick);

                windowControl.Controls.Add(preview);
                windowControl.Controls.Add(selector);
                windowControl.Show();
            }
        }

        private void preview_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                selector.Visible = true;
                preview.Visible = false;
                selection = -1;
                OnRedraw(new DrawParameters(scale, selection));
                MaximizeForm(windowControl);
            }
            if (e.Button == MouseButtons.Left)
            {
                selection = ImageUtils.GetSelectedSquare(preview.Width, preview.Height, e.X, e.Y, scale);
                var img = ImageUtils.UpdatePreviewImage(processingSize.Width, processingSize.Height, selection, scale, e.X, e.Y);
                preview.Image = img;
                preview.Refresh();
                OnRedraw(new DrawParameters(scale, selection));
            }
        }

        private void selector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String number = selector.Text;
            int.TryParse(number, out scale);
            if (scale > 0 && scale < 17)
            {
                selector.Visible = false;
                MinimizeForm(windowControl);
                var img = ImageUtils.UpdatePreviewImage(processingSize.Width, processingSize.Height, selection, scale);
                preview.Image = img;
                preview.Visible = true;
                preview.Refresh();
            } else
            {
                MessageBox.Show("Приближение не возможно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinimizeForm(Form form)
        {
            form.Text = "Выберите сегмент";
        }

        private void MaximizeForm(Form form)
        {
            form.Text = "Выберите разбиение";
            form.ControlBox = false;
        }

        private void OnClose()
        {
            if (windowControl != null)
            {
                windowControl.Close();
            }
            onCloseAction();
        }

        private void picture_MouseEnter(object sender, System.EventArgs e)
        {
            Cursor.Hide();
            isCursorHidden = true;
        }

        private void picture_MouseLeave(object sender, System.EventArgs e)
        {
            Cursor.Show();
            isCursorHidden = false;
            SynchronizePosition(new Point(-1, -1));
            this.picture.Invalidate();
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (isCursorHidden)
            {
                ImageUtils.DrawCross(e, currentPosition);
            }
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCursorHidden)
            {
                currentPosition = picture.PointToClient(Control.MousePosition);
                this.picture.Invalidate();
                SynchronizePosition(picture.PointToClient(Control.MousePosition));
            }
        }
    }
}
