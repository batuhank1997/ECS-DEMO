using System;

namespace Game.Scripts.ECS.Core
{
    public readonly struct Archetype : IEquatable<Archetype>
    {
        public readonly int Value;
        
        public Archetype(int value)
        {
            Value = value;
        }

        public bool Equals(Archetype other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Archetype other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}