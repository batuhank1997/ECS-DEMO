namespace Game.Scripts.ECS.Chunks
{
    public readonly struct ChunkId
    {
        public readonly int Value;

        public ChunkId(int value)
        {
            Value = value;
        }
    }
}