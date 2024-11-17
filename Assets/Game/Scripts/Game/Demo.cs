using System;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Core.Managers;
using Game.Scripts.ECS.System;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;
        
        private ECSManager _ecsManager;
        private MoveSystem _moveSystem;
        private RenderSystem _renderSystem;
        
        private void Start()
        {
            _ecsManager = new ECSManager();
            _moveSystem = new MoveSystem();
            _renderSystem = new RenderSystem();

            for (var i = 0; i < 1024; i++)
            {
                var matrix = new Matrix4x4();
                
                matrix.SetTRS(new Vector3(i, i, i), Quaternion.identity, Vector3.one);
                
                // var posComponent = new PositionComponent(new float3(i, 0, 0));
                var renderComponent = new RenderComponent(new RenderData(_mesh, _material, matrix));
                
                _ecsManager.CreateEntity(renderComponent);
            }
        }

        private void Update()
        {
            UpdateSystems(Time.deltaTime);
        }

        private void UpdateSystems(float deltaTime)
        {
            _moveSystem.Update(_ecsManager.GetChunksByArchetype(Archetype.Move), deltaTime);
            _renderSystem.Update(_ecsManager.GetChunksByArchetype(Archetype.Render), deltaTime);
        }
    }
}