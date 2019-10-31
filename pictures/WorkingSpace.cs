using System;
using System.Drawing;

namespace pictures
{
    internal class WorkingSpace
    {
        private ImagesStore store;
        private Size size;
        private RealImage realImage;
        private Schema schema;
        private Action onCloseAction;

        internal WorkingSpace(ImagesStore store, Size size, Action onCloseAction)
        {
            this.store = store;
            this.size = size;
            this.onCloseAction = onCloseAction;
            InitializeControls();
        }

        private void InitializeControls()
        {
            realImage = new RealImage("Изображение", size, store.GetCopyOfRealImage(), CloseSchema);
            schema = new Schema("Схема", size, store.GetCopyOfSchema(), CloseRealImage, Redraw, realImage.SynchronizePosition);
        }

        private void Redraw(DrawParameters parameters)
        {
            schema.Redraw(parameters);
            realImage.Redraw(parameters);
        }

        private void CloseSchema()
        {
            if (!schema.IsClosed())
            {
                schema.Close();
            }
            onCloseAction();
        }

        private void CloseRealImage()
        {
            if (!realImage.IsClosed())
            {
                realImage.Close();
            }
            onCloseAction();
        }
    }
}
