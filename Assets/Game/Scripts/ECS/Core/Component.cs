using System.Numerics;
using Unity.Mathematics;

namespace Game.Scripts.ECS.Core
{
    public class PositionComponent : IComponent
    {
        public ComponentType Type { get; }
        public float3 Value;
        
        public PositionComponent(float3 value)
        {
            Type = ComponentType.Position;
            Value = value;
        }
    }

    public class RotationComponent : IComponent
    {
        public ComponentType Type { get; }
        public Quaternion Value;
        
        public RotationComponent(Quaternion value)
        {
            Type = ComponentType.Rotation;
            Value = value;
        }
    }

    public class ScaleComponent : IComponent
    {
        public ComponentType Type { get; }
        public float3 Value;
        
        public ScaleComponent(float3 value)
        {
            Type = ComponentType.Scale;
            Value = value;
        }
    }
}