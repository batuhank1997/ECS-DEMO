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

            var posComponent = new PositionComponent(new float3(1, 2, 3));
            
            var entity = ecsManager.CreateEntity(posComponent);
            
            Debug.Log($"Position: {entity.GetComponent<PositionComponent>().Value}");
        }
    }
}