namespace Game.Scripts
{
    public readonly struct GridData
    {
        public readonly int Resolution;
        public readonly float Size;

        public GridData(int resolution, float size)
        {
            Resolution = resolution;
            Size = size;
        }
    }
}