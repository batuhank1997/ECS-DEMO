using Game.Scripts.ECS.Component.Base;
using Unity.Mathematics;

namespace Game.Scripts.ECS.Component
{
    public struct ScaleComponent : IComponent
    {
        public ComponentType Type => ComponentType.Scale;
        
        public float3 Value;
        
        public ScaleComponent(float3 value)
        {
            Value = value;
        }
    }
}