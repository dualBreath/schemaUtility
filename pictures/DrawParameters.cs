namespace pictures
{
    internal class DrawParameters
    {
        internal int Scale { get; private set; }
        internal int Selection { get; private set; }

        internal DrawParameters(int scale, int selection)
        {
            Scale = scale;
            Selection = selection;

        }
    }
}
