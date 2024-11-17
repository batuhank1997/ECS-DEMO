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
            var matrices = new Matrix4x4[renderComponents.Length];
            
            for (var i = 0; i < renderComponents.Length; i++)
                matrices[i] = renderComponents[i].RenderData.Matrice4x4;
            
            foreach (var positionComponent in renderComponents)
            {
                Graphics.DrawMeshInstanced(
                    positionComponent.RenderData.Mesh,
                    0,
                    positionComponent.RenderData.Material,
                    matrices);
            }
        }
    }
}