using System;
using System.Collections.Generic;

namespace Game.Scripts.ECS.Core.Managers
{
    public class Chunk
    {
        public readonly Archetype Archetype;
        
        public readonly Dictionary<Type, Array> Components;

        private readonly int _size;
        
        public Chunk(Archetype archetype, int size = 16)
        {
            Archetype = archetype;
            _size = size;
            
            Components = new Dictionary<Type, Array>(CountBits(archetype.Value));
        }

        private static int CountBits(int number)
        {
            var count = 0;
            
            while (number != 0)
            {
                count += number & 1;
                number >>= 1;
            }
            
            return count;
        }

        public void AddEntity(Entity entity)
        {
            foreach (var component in entity.Components)
            {
                var componentType = component.GetType();
                
                if (!Components.ContainsKey(componentType))
                    Components.Add(componentType, Array.CreateInstance(componentType, _size));
                
                Components[componentType].SetValue(component, entity.Id.Value);
            }
        }
        
        public List<IComponent> GetEntityComponentsByIndex(int entityIndex)
        {
            var entityComponents = new List<IComponent>();
            
            foreach (var component in Components)
                entityComponents.Add((IComponent)component.Value.GetValue(entityIndex));
            
            return entityComponents;
        }
    }
}