using Game.Scripts.ECS.Component.Base;
using Unity.Mathematics;

namespace Game.Scripts.ECS.Component
{
    public class PositionComponent : IComponent
    {
        public ComponentType Type => ComponentType.Position;
        
        public float3 Value;
        
        public PositionComponent(float3 value)
        {
            Value = value;
        }
    }
}