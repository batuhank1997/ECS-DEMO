using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using UnityEngine;

namespace Game.Scripts.ECS.System
{
    public class RotateSystem : ISystem
    {
        public void Update(List<Chunk> chunkList, float deltaTime)
        {
            for (var i = 0; i < chunkList.Count; i++)
                Execute(chunkList[i].GetComponentsByType<RotationComponent>(), deltaTime);
        }
        
        private void Execute(RotationComponent[] rotationComponents, float deltaTime)
        {
            for (var i = 0; i < rotationComponents.Length; i++)
                rotationComponents[i] = new RotationComponent(rotationComponents[i].Value * Quaternion.Euler(Vector3.up * (deltaTime * 50)));
        }
    }
}