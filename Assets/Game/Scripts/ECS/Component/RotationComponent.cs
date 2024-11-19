using Game.Scripts.ECS.Component.Base;
using UnityEngine;

namespace Game.Scripts.ECS.Component
{
    public struct RotationComponent : IComponent
    {
        public ComponentType Type => ComponentType.Rotation;
        
        public Quaternion Value;
        
        public RotationComponent(Quaternion value)
        {
            Value = value;
        }
    }
}