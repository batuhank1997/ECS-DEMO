using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using UnityEngine;

namespace Game.Scripts.ECS.System
{
    public class RenderSystem : ISystem
    {
        public void Update(List<Chunk> chunkList, float deltaTime)
        {
            foreach (var chunk in chunkList)
                Execute(chunk.GetComponentsByType<RenderComponent>(), deltaTime);
        }
        
        private void Execute(RenderComponent[] renderComponents, float deltaTime)
        {
            foreach (var positionComponent in renderComponents)
            {
                Graphics.DrawMeshInstanced(
                    positionComponent.RenderData.Mesh,
                    0,
                    positionComponent.RenderData.Material,
                    positionComponent.RenderData.Matrices);
            }
        }
    }
}