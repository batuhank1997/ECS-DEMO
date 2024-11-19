using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Entities;
using Game.Scripts.ECS.Utility;

namespace Game.Scripts.ECS.Chunks
{
    public class Chunk
    {
        public readonly ChunkData Data;

        private int _emptySpace = 0;
        
        public Chunk(Archetype archetype, int size = 16)
        {
            _emptySpace = size;
            Data = new ChunkData(archetype, new Dictionary<Type, Array>(), size);
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var componentTypes = ArchetypeUtility.GetComponentTypesByArcheType(Data.Archetype.Value);

            foreach (var componentType in componentTypes)
            {
                if (ChunkUtility.TryGetTypeObjectByComponentType(componentType, out var type))
                    Data.Components.Add(type, Array.CreateInstance(type, Data.Size));
            }
        }
        
        public void AddEntity(Entity entity)
        {
            foreach (var component in entity.Data.Components)
            {
                var componentType = component.GetType();
                
                if (!Data.Components.ContainsKey(componentType))
                    Data.Components.Add(componentType, Array.CreateInstance(componentType, Data.Size));
               
                Data.Components[componentType].SetValue(component, entity.Data.Id.Value % Data.Size);
            }
            
            _emptySpace--;
        }
        
        public bool IsFull()
        {
            return _emptySpace == 0;
        }

        public T[] GetComponentsByType<T>() where T : IComponent
        {
            return Data.Components[typeof(T)] as T[];
        }
    }
}