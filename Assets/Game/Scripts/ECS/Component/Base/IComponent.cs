using Game.Scripts.ECS.Component.Base;

namespace Game.Scripts.ECS.Component
{
    public interface IComponent
    {
        public ComponentType Type { get; }
    }
}