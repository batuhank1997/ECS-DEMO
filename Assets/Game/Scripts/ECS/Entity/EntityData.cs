using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;

namespace Game.Scripts.ECS.Entity
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