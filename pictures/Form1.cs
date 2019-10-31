using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace pictures
{
    public partial class Form1 : Form
    {
        private ImagesStore store;
        private Size size;

        public Form1()
        {
            InitializeComponent();
            store = new ImagesStore();
        }

        private void buttonSelectShema_Click(object sender, EventArgs e)
        {
            if (openFileSchema.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    store.Schema = new Bitmap(openFileSchema.FileName);
                    schemaImage.Image = store.GetCopyOfSchema();

                    double scale = Math.Min(800.0 / store.Schema.Width, 600.0 / store.Schema.Height);
                    int newWidth = (int)(store.Schema.Width * scale);
                    int newHeight = (int)(store.Schema.Height * scale);

                    textBoxWidth.Text = newWidth.ToString();
                    textBoxHeight.Text = newHeight.ToString();
                    schemaImage.Refresh();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void buttonSelectReal_Click(object sender, EventArgs e)
        {
            if (openFileReal.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    store.RealImage = new Bitmap(openFileReal.FileName);
                    realImage.Image = store.GetCopyOfRealImage();
                    realImage.Refresh();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void textBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.FilterTextInput(sender, e);
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.FilterTextInput(sender, e);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            size.Width = Util.GetNumber(textBoxWidth);
            size.Height = Util.GetNumber(textBoxHeight);

            if (size.Width < 1 || size.Height < 1)
            {
                MessageBox.Show("Введите корректные размеры изображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (store.RealImage == null || store.Schema == null)
            {
                MessageBox.Show("Выберите изображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Visible = false;
                WorkingSpace ws = new WorkingSpace(store, size, ShowWindow);
            }
        }

        private void ShowWindow()
        {
            Visible = true;
        }
    }
}
