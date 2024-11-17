using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;

namespace Game.Scripts.ECS.Entities
{
    public class Entity
    {
        public readonly EntityData Data;
        
        public Entity(params IComponent[] baseComponents)
        {
            var list = new List<IComponent>(baseComponents);
            Data = new EntityData(new EntityId(EntityId.IdValue++), new Archetype(SetArchetype(list)), list);
        }
        
        private int SetArchetype(List<IComponent> components)
        {
            var archetypeValue = 0;
            
            foreach (var component in components)
                archetypeValue += (int)component.Type;
            
            return archetypeValue;
        }
    }
}