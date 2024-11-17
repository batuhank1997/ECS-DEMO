namespace Game.Scripts.ECS.Entity
{
    public readonly struct EntityId
    {
        public static int IdValue = 0;
        
        public readonly int Value;

        public EntityId(int value)
        {
            Value = value;
        }
    }
}