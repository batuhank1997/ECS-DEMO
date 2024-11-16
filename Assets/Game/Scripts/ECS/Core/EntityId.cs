namespace Game.Scripts.ECS.Core
{
    public readonly struct EntityId
    {
        public readonly int Value;

        public EntityId(int value)
        {
            Value = value;
        }
    }
}