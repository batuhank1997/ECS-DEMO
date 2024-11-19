using System;
using Game.Scripts.ECS.Component.Base;

namespace Game.Scripts.ECS.Chunks
{
    public readonly struct Archetype : IEquatable<Archetype>
    {
        public readonly int Value;
        
        #region  Predefined Archetypes
        
        // Single component archetypes
        
        public static readonly Archetype Invalid = new (0);
        public static readonly Archetype Position = new ((int)ComponentType.Position);
        public static readonly Archetype Rotate = new ((int)ComponentType.Rotation);
        public static readonly Archetype Scale = new ((int)ComponentType.Scale);
        public static readonly Archetype Render = new ((int)ComponentType.Render | Position.Value | Rotate.Value | Scale.Value);
        
        // Multi component archetypes
        
        
        #endregion
        
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