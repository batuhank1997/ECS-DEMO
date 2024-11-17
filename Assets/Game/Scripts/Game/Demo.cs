using Game.Scripts.ECS.Core;
using Game.Scripts.ECS.Core.Managers;
using Game.Scripts.ECS.System;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class Demo : MonoBehaviour
    {
        private ECSManager _ecsManager;
        private MoveSystem _moveSystem;
        
        private void Start()
        {
            _ecsManager = new ECSManager();
            
            _moveSystem = new MoveSystem();

            for (var i = 0; i < 1024; i++)
            {
                var posComponent = new PositionComponent(new float3(i, 0, 0));
                var entity = _ecsManager.CreateEntity(posComponent);
            }
        }

        private void Update()
        {
            UpdateSystems(Time.deltaTime);
        }

        private void UpdateSystems(float deltaTime)
        {
            _moveSystem.Update(_ecsManager.GetChunksByArchetype(Archetype.Move), deltaTime);
        }
    }
}