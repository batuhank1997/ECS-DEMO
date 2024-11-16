namespace Game.Scripts.ECS.Core
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