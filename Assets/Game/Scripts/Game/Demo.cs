using Game.Scripts.ECS.Core;
using Game.Scripts.ECS.Core.Managers;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class Demo : MonoBehaviour
    {
        private void Start()
        {
            var ecsManager = new ECSManager();


            for (var i = 0; i < 1024; i++)
            {
                var posComponent = new PositionComponent(new float3(i, 0, 0));
            
                var entity = ecsManager.CreateEntity(posComponent);
            }
        }
    }
}