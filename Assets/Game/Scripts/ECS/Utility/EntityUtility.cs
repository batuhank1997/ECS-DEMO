using Game.Scripts.ECS.Core;

namespace Game.Scripts.ECS.Utility
{
    public static class EntityUtility
    {
        public static bool HasSameArchetypeWith(this Entity entity, Entity other)
        {
            return entity.Archetype.Equals(other.Archetype);
        }

        public static bool HasComponent(this Entity entity, ComponentType componentType)
        {
            return (entity.Archetype.Value & (int)componentType) != 0;
        }
    }
}