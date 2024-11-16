using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Utility;
using UnityEditor.Rendering;

namespace Game.Scripts.ECS.Core.Managers
{
    public readonly struct Chunk
    {
        public readonly Archetype Archetype;
        public readonly Dictionary<Type, Array> Components;
        private readonly int _size;
        
        public Chunk(Archetype archetype, int size = 16)
        {
            Archetype = archetype;
            _size = size;
            Components = new Dictionary<Type, Array>(ChunkUtility.CountBits(archetype.Value));
        }

        public bool TryAddEntity(Entity entity)
        {
            if (!Components.TryGetValue(entity.Components[0].GetType(), out var arr))
                return false;

            foreach (var component in entity.Components)
            {
                var componentType = component.GetType();
                
                if (!Components.ContainsKey(componentType))
                    Components.Add(componentType, Array.CreateInstance(componentType, _size));
                
                Components[componentType].SetValue(component, entity.Id.Value);
            }
            
            return true;
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