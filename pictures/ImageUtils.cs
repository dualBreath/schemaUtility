using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace pictures
{
    internal class ImageUtils
    {
        private static int pixelSize = 4;
        private static Color green = Color.FromArgb(0, 255, 0);
        private static SolidBrush sbGreen = new SolidBrush(green);
        private static Bitmap crossSmall = new Bitmap(7, 7);
        private static Bitmap cross = new Bitmap(18, 18);
        private static Pen penGreen = new Pen(green);

        static ImageUtils()
        {
            CreateSmallCross();
            CreateSmallCross();            
        }

        internal static int GetSelectedSquare(int width, int height, int x, int y, int scale)
        {
            OrientationHelper orientation = GetOrientationParameters(width, height, scale);

            for (int i = 0; i < orientation.WidthMul; i++)
            {
                for (int j = 0; j < orientation.HeightMul; j++)
                {
                    if (x >= i * orientation.BlockWidth && x <= (i + 1) * orientation.BlockWidth &&
                        y >= j * orientation.BlockHeight && y <= (j + 1) * orientation.BlockHeight)
                    {
                        return i + orientation.WidthMul * j;
                    }
                }
            }
            return -1;
        }

        internal static Bitmap UpdatePreviewImage(int width, int height, int selectedSector, int scale)
        {
            return UpdatePreviewImage(width, height, selectedSector, scale, -1, -1);
        }

        internal static Bitmap UpdatePreviewImage(int width, int height, int selectedSector, int scale, int x, int y)
        {
            OrientationHelper orientation = GetOrientationParameters(width, height, scale);
            var tile = new Bitmap(width, height);
            try
            {
                BitmapData bmd = tile.LockBits(new Rectangle(0, 0, tile.Width, tile.Height), ImageLockMode.ReadOnly, tile.PixelFormat);
                unsafe
                {
                    byte* start = (byte*)bmd.Scan0;
                    for (int j = 0; j < bmd.Height; j++)
                    {
                        byte* row = start + (j * bmd.Stride);
                        for (int i = 0; i < bmd.Width; i++)
                        {
                            Color color = Color.Green;
                            for (int cntX = 0; cntX <= orientation.WidthMul; cntX++)
                            {
                                for (int cntY = 0; cntY <= orientation.HeightMul; cntY++)
                                {
                                    if (i >= cntX * orientation.BlockWidth - 1 && i <= cntX * orientation.BlockWidth + 1 ||
                                        j >= cntY * orientation.BlockHeight - 1 && j <= cntY * orientation.BlockHeight + 1)
                                    {
                                        color = Color.Black;
                                        break;
                                    }
                                }
                            }
                            if (x > -1 && y > -1 && selectedSector != -1 && color == Color.Green &&
                                selectedSector == GetSelectedSquare(width, height, i, j, scale))
                            {
                                color = Color.Red;
                            }
                            SetPixelBGRA(row, i * pixelSize, color);
                        }
                    }
                }

                tile.UnlockBits(bmd);
            }
            catch (InvalidOperationException e)
            {

            }
            return tile;
        }

        internal static Rectangle GetSelectedRectangle(int width, int height, int scale, int selection)
        {
            OrientationHelper orientation = GetOrientationParameters(width, height, scale);
            for (int i = 0; i < orientation.WidthMul; i ++)
            {
                for (int j = 0; j < orientation.HeightMul; j ++)
                {
                    if (i + orientation.WidthMul * j == selection) {
                        return new Rectangle(new Point(i * orientation.BlockWidth, j * orientation.BlockHeight),
                            new Size(orientation.BlockWidth, orientation.BlockHeight));
                    }
                }
            }

            return new Rectangle(new Point(0, 0), new Size(width, height));
        }

        internal static void DrawCircle(PaintEventArgs e, Point point)
        {
            e.Graphics.DrawEllipse(penGreen, point.X - 6, point.Y - 6,
                      12, 12);
        }

        internal static void DrawCross(PaintEventArgs e, Point point)
        {
            e.Graphics.DrawImage(cross, point.X - cross.Width / 2, point.Y - cross.Height / 2);
        }

        private static unsafe void SetPixelBGRA(byte* row, int position, Color color)
        {
            row[position] = color.B; // blue
            row[position + 1] = color.G; // green
            row[position + 2] = color.R; // red
            row[position + 3] = color.A; // alfa
        }

        private static OrientationHelper GetOrientationParameters(int width, int height, int scale)
        {
            int maxMul = 2;
            int minMul = 1;
            int multiplier = scale;
            while ((multiplier /= 2) > 1)
            {
                if (maxMul == minMul)
                {
                    maxMul *= 2;
                }
                else
                {
                    minMul *= 2;
                }
            }
            int hMul = width > height ? minMul : maxMul;
            int wMul = width > height ? maxMul : minMul;

            int hSize = height / hMul;
            int wSize = width / wMul;

            return new OrientationHelper(wSize, hSize, wMul, hMul);
        }

        private static void CreateSmallCross()
        {
            crossSmall.SetPixel(3, 0, green);
            crossSmall.SetPixel(3, 1, green);
            crossSmall.SetPixel(3, 5, green);
            crossSmall.SetPixel(3, 6, green);

            crossSmall.SetPixel(0, 3, green);
            crossSmall.SetPixel(1, 3, green);
            crossSmall.SetPixel(5, 3, green);
            crossSmall.SetPixel(6, 3, green);
        }

        private static void CreateCross()
        {
            cross.SetPixel(8, 0, green);
            cross.SetPixel(8, 1, green);
            cross.SetPixel(8, 2, green);
            cross.SetPixel(8, 3, green);
            cross.SetPixel(8, 4, green);
            cross.SetPixel(8, 5, green);

            cross.SetPixel(9, 0, green);
            cross.SetPixel(9, 1, green);
            cross.SetPixel(9, 2, green);
            cross.SetPixel(9, 3, green);
            cross.SetPixel(9, 4, green);
            cross.SetPixel(9, 5, green);

            cross.SetPixel(8, 11, green);
            cross.SetPixel(8, 12, green);
            cross.SetPixel(8, 13, green);
            cross.SetPixel(8, 14, green);
            cross.SetPixel(8, 15, green);
            cross.SetPixel(8, 16, green);

            cross.SetPixel(9, 11, green);
            cross.SetPixel(9, 12, green);
            cross.SetPixel(9, 13, green);
            cross.SetPixel(9, 14, green);
            cross.SetPixel(9, 15, green);
            cross.SetPixel(9, 16, green);

            cross.SetPixel(0, 8, green);
            cross.SetPixel(1, 8, green);
            cross.SetPixel(2, 8, green);
            cross.SetPixel(3, 8, green);
            cross.SetPixel(4, 8, green);
            cross.SetPixel(5, 8, green);

            cross.SetPixel(0, 9, green);
            cross.SetPixel(1, 9, green);
            cross.SetPixel(2, 9, green);
            cross.SetPixel(3, 9, green);
            cross.SetPixel(4, 9, green);
            cross.SetPixel(5, 9, green);

            cross.SetPixel(11, 8, green);
            cross.SetPixel(12, 8, green);
            cross.SetPixel(13, 8, green);
            cross.SetPixel(14, 8, green);
            cross.SetPixel(15, 8, green);
            cross.SetPixel(16, 8, green);

            cross.SetPixel(11, 9, green);
            cross.SetPixel(12, 9, green);
            cross.SetPixel(13, 9, green);
            cross.SetPixel(14, 9, green);
            cross.SetPixel(15, 9, green);
            cross.SetPixel(16, 9, green);
        }

        private class OrientationHelper
        {
            internal int BlockWidth { get; private set; }
            internal int BlockHeight { get; private set; }
            internal int WidthMul { get; private set; }
            internal int HeightMul { get; private set; }

            internal OrientationHelper(int blockWidth, int blockHeight, int widthMul, int heightMul)
            {
                BlockWidth = blockWidth;
                BlockHeight = blockHeight;
                WidthMul = widthMul;
                HeightMul = heightMul;
            }
        }
    }
}
