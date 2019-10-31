using System.Drawing;

namespace pictures
{
    internal class ImagesStore
    {
        internal Bitmap Schema { get; set; }
        internal Bitmap RealImage { get; set; }

        public ImagesStore() { }

        public Bitmap GetCopyOfSchema()
        {
            return new Bitmap(Schema);
        }
        public Bitmap GetCopyOfRealImage()
        {
            return new Bitmap(RealImage);
        }
    }
}
