using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using Unity.Mathematics;

namespace Game.Scripts.ECS.System
{
    public class MoveSystem : ISystem
    {
        public void Update(List<Chunk> chunkList, float deltaTime)
        {
            foreach (var chunk in chunkList)
                Execute(chunk.GetComponentsByType<PositionComponent>(), deltaTime);
        }
        
        private void Execute(PositionComponent[] positionComponents, float deltaTime)
        {
            for (var i = 0; i < positionComponents.Length; i++)
                positionComponents[i] = new PositionComponent(positionComponents[i].Value + new float3(0, 0, 1) * deltaTime);
        }
    }
}