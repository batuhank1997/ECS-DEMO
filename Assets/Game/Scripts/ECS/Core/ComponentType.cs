namespace Game.Scripts.ECS.Core
{
    public enum ComponentType : ulong
    {
        Invalid = 0,
        Position = 1 << 0, // 0000 0001 (1)
        Rotation = 1 << 1, // 0000 0010 (2)
        Scale = 1 << 2,    // 0000 0100 (4)
    }
}