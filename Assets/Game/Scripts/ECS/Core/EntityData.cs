using System.Collections.Generic;

namespace Game.Scripts.ECS.Core
{
    public readonly struct EntityData
    {
        public readonly EntityId Id;
        public readonly Archetype Archetype;

        public readonly IReadOnlyList<IComponent> Components;

        public EntityData(EntityId id, Archetype archetype, IReadOnlyList<IComponent> components)
        {
            Id = id;
            Archetype = archetype;
            Components = components;
        }
    }
}