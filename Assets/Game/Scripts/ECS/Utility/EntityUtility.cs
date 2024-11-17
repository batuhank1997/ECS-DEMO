using Game.Scripts.ECS.Component;

namespace Game.Scripts.ECS.Utility
{
    public static class EntityUtility
    {
        public static bool HasSameArchetypeWith(this Entity.Entity entity, Entity.Entity other)
        {
            return entity.Data.Archetype.Equals(other.Data.Archetype);
        }

        public static bool HasComponent(this Entity.Entity entity, ComponentType componentType)
        {
            return (entity.Data.Archetype.Value & (int)componentType) != 0;
        }
    }
}