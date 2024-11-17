namespace Game.Scripts.ECS.Component.Base
{
    public enum ComponentType : ulong
    {
        Invalid = 0,
        Position = 1 << 0, // 0000 0001 (1)
        Rotation = 1 << 1, // 0000 0010 (2)
        Scale = 1 << 2,    // 0000 0100 (4)
        Render = 1 << 3,   // 0000 1000 (8)
    }
}