﻿using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Component.Base;

namespace Game.Scripts.ECS.Utility
{
    public static class ChunkUtility
    {
        private static readonly IReadOnlyDictionary<ComponentType, Type> _componentTypeToType = new Dictionary<ComponentType, Type>()
        {
            { ComponentType.Invalid, null },
            { ComponentType.Position, typeof(PositionComponent) },
            { ComponentType.Rotation, typeof(RotationComponent) },
            { ComponentType.Scale, typeof(ScaleComponent) },
            { ComponentType.Render, typeof(RenderComponent) },
        };

        public static int CountBits(int number)
        {
            var count = 0;
            
            while (number != 0)
            {
                count += number & 1;
                number >>= 1;
            }
            
            return count;
        }
        
        public static bool TryGetTypeObjectByComponentType(ComponentType componentType, out Type type)
        {
            if (_componentTypeToType.TryGetValue(componentType, out type))
                return true;
            
            throw new NullReferenceException($"Component type {componentType} not found in dictionary.");
        }
    }
}