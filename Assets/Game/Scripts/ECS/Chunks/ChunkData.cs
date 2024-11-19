using System;
using System.Collections.Generic;

namespace Game.Scripts.ECS.Chunks
{
    public readonly struct ChunkData : IEquatable<ChunkData>
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

        public bool Equals(ChunkData other)
        {
            return Archetype.Equals(other.Archetype) && Equals(Components, other.Components) && Size == other.Size;
        }

        public override bool Equals(object obj)
        {
            return obj is ChunkData other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Archetype, Components, Size);
        }
    }
}