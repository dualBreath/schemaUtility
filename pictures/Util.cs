using System;
using System.Drawing;
using System.Windows.Forms;

namespace pictures
{
    internal static class Util
    {
        internal static void FilterTextInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        internal static int GetNumber(TextBox textNumber)
        {
            int result;
            if (int.TryParse(textNumber.Text, out result))
            {
                return result;
            } else
            {
                return -1;
            }
        }

        internal static Size CalculateSize(Size originalSize, Size targetSize)
        {
            Size newSize = new Size();
            int mul1 = targetSize.Height * originalSize.Width;
            int mul2 = targetSize.Width * originalSize.Height;

            if (mul1 < mul2)
            {
                newSize.Width = (int)Math.Round((double)mul1 / originalSize.Height);
                newSize.Height = targetSize.Height;
            }
            else
            {
                newSize.Width = targetSize.Width;
                newSize.Height = (int)Math.Round((double)mul2 / originalSize.Width);
            }

            return newSize;
        }
    }
}
