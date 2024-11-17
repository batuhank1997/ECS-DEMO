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
    }
}