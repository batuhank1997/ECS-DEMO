using System;

namespace Game.Scripts.ECS.Core
{
    public readonly struct Archetype : IEquatable<Archetype>
    {
        public readonly int Value;
        
        public static readonly Archetype Invalid = new (0);
        public static readonly Archetype Move = new ((int)ComponentType.Position);
        public static readonly Archetype Rotate = new ((int)ComponentType.Rotation);
        public static readonly Archetype Scale = new ((int)ComponentType.Scale);
        
        
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