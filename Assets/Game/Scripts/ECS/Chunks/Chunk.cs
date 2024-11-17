using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Entities;
using Game.Scripts.ECS.Utility;

namespace Game.Scripts.ECS.Chunks
{
    public readonly struct Chunk
    {
        public readonly ChunkData Data;
        
        public Chunk(Archetype archetype, int size = 16)
        {
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

        public bool TryAddEntity(Entity entity)
        {
            var arr = Data.Components[entity.Data.Components[0].GetType()];
            var lastElement = arr.GetValue(arr.Length - 1);
            
            if (lastElement != null)
                return false;

            foreach (var component in entity.Data.Components)
            {
                var componentType = component.GetType();
                
                if (!Data.Components.ContainsKey(componentType))
                    Data.Components.Add(componentType, Array.CreateInstance(componentType, Data.Size));
               
                Data.Components[componentType].SetValue(component, entity.Data.Id.Value % Data.Size);
            }
            
            return true;
        }
        
        public List<IComponent> GetEntityComponentsByIndex(int entityIndex)
        {
            var entityComponents = new List<IComponent>();
            
            foreach (var component in Data.Components)
                entityComponents.Add((IComponent)component.Value.GetValue(entityIndex));
            
            return entityComponents;
        }

        public T[] GetComponentsByType<T>() where T : IComponent
        {
            return Data.Components[typeof(T)] as T[];
        }
    }
}