using System;
using System.Collections.Generic;

namespace Game.Scripts.ECS.Chunks
{
    public readonly struct ChunkData
    {
        public readonly Archetype Archetype;
        public readonly Dictionary<Type, Array> Components;
        public readonly int Size;

        public ChunkData(Archetype archetype, Dictionary<Type, Array> components, int size)
        {
            Archetype = archetype;
            Components = components;
            Size = size;
        }
    }
}