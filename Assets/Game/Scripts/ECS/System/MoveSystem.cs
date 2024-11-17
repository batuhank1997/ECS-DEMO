using System;
using System.Collections.Generic;
using Game.Scripts.ECS.Core;
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
                positionComponents[i].Value += new float3(1, 0, 0) * deltaTime;
        }
    }
}