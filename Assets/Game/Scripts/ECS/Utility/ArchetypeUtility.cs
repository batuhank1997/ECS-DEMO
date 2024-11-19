using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component.Base;

namespace Game.Scripts.ECS.Utility
{
    public static class ArchetypeUtility
    {
        public static List<ComponentType> GetComponentTypesByArcheType(int archetype)
        {
            var componentTypes = new List<ComponentType>();

            for (var i = 0; i < 32; i++)
            {
                var componentType = (ComponentType)(1 << i);

                if ((archetype & (int)componentType) != 0)
                    componentTypes.Add(componentType);
            }

            return componentTypes;
        }
        
        public static bool IsArchetypeHasComponent(Archetype archetype, ComponentType componentType)
        {
            return (archetype.Value & new Archetype((int)componentType).Value) != 0;
        }
    }
}