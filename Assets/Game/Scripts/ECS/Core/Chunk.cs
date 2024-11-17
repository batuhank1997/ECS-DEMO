using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Utility;

namespace Game.Scripts.ECS.Core
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
            Components = new Dictionary<Type, Array>();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var componentTypes = ArchetypeUtility.GetComponentTypesByArcheType(Archetype.Value);

            foreach (var componentType in componentTypes)
            {
                if (ChunkUtility.TryGetTypeObjectByComponentType(componentType, out var type))
                    Components.Add(type, Array.CreateInstance(type, _size));
            }
        }

        public bool TryAddEntity(Entity entity)
        {
            var arr = Components[entity.Components[0].GetType()];
            var lastElement = arr.GetValue(arr.Length - 1);
            
            if (lastElement != null)
                return false;

            foreach (var component in entity.Components)
            {
                var componentType = component.GetType();
                
                if (!Components.ContainsKey(componentType))
                    Components.Add(componentType, Array.CreateInstance(componentType, _size));
               
                Components[componentType].SetValue(component, entity.Id.Value % _size);
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

        public T[] GetComponentsByType<T>() where T : IComponent
        {
            return Components[typeof(T)] as T[];
        }
    }
}