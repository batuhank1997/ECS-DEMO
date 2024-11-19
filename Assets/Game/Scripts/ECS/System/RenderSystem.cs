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
                Execute(
                    chunk.GetComponentsByType<RenderComponent>(), 
                    chunk.GetComponentsByType<PositionComponent>(),
                    chunk.GetComponentsByType<RotationComponent>(), 
                    chunk.GetComponentsByType<ScaleComponent>(), deltaTime);
        }
        
        private void Execute(RenderComponent[] renderComponents, PositionComponent[] positionComponents, RotationComponent[] rotationComponents, ScaleComponent[] scaleComponents, float deltaTime)
        {
            var matrices = new Matrix4x4[renderComponents.Length];
            
            for (var i = 0; i < renderComponents.Length; i++)
                matrices[i] = Matrix4x4.TRS(positionComponents[i].Value, rotationComponents[i].Value, scaleComponents[i].Value);

            for (var i = 0; i < renderComponents.Length; i++)
            {
                renderComponents[i] = new RenderComponent(new RenderData(renderComponents[i].RenderData.Mesh, renderComponents[i].RenderData.Material, matrices[i]));
                Graphics.DrawMeshInstanced(renderComponents[i].RenderData.Mesh, 0, renderComponents[i].RenderData.Material, matrices);
            }
        }
    }
}