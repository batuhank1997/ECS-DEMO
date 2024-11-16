using System;
using System.Collections.Generic;

namespace Game.Scripts.ECS.Core
{
    public class Entity
    {
        public readonly EntityId Id;
        public readonly Archetype Archetype;

        public readonly IReadOnlyList<IComponent> Components;

        public Entity(EntityId id, params IComponent[] baseComponents)
        {
            Id = id;
            Components = new List<IComponent>(baseComponents);
            Archetype = new Archetype(SetArchetype());
        }
        
        private int SetArchetype()
        {
            var archetypeValue = 0;
            
            foreach (var component in Components)
                archetypeValue += (int)component.Type;
            
            return archetypeValue;
        }
        
        public T GetComponent<T>() where T : IComponent
        {
            foreach (var component in Components)
                if (component is T tComponent)
                    return tComponent;

            throw new InvalidOperationException($"Component of type {typeof(T)} does not exist on entity {Id.Value}");
        }

        public bool HasComponent(ComponentType componentType)
        {
            return (Archetype.Value & (int)componentType) != 0;
        }
        
        public bool HasSameArchetypeWith(Entity other)
        {
            return Archetype.Equals(other.Archetype);
        }
    }
}