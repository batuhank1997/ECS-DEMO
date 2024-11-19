using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Component.Base;
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
        private RotateSystem _rotateSystem;

        private MaterialPropertyBlock _materialPropertyBlock;
        
        private void Start()
        {
            _ecsManager = new ECSManager();
            _moveSystem = new MoveSystem();
            _renderSystem = new RenderSystem();
            _rotateSystem = new RotateSystem();
            _materialPropertyBlock = new MaterialPropertyBlock();
            
            var posComponentArray = new PositionComponent[1024];

            var counter = 0;
            
            for (var i = 0; i < 32; i++)
            {
                for (var j = 0; j < 32; j++)
                {
                    var posComponent = new PositionComponent(new float3(i , j, 0));
                    posComponentArray[counter] = posComponent;
                    counter++;
                }
            }
            
            
            for (var i = 0; i < 1024; i++)
            {
                var posComponent = posComponentArray[i];
                var rotComponent = new RotationComponent(Quaternion.identity);
                var scaleComponent = new ScaleComponent(0.9f);
                
                var renderComponent = new RenderComponent(new RenderData(_mesh, _material, Matrix4x4.TRS(posComponent.Value, rotComponent.Value, scaleComponent.Value)));

                _ecsManager.CreateEntity(renderComponent, posComponent, rotComponent, scaleComponent);
            }
        }

        private void Update()
        {
            UpdateSystems(Time.deltaTime);
        }

        private void UpdateSystems(float deltaTime)
        {
            _rotateSystem.Update(_ecsManager.GetChunksWithComponent(ComponentType.Rotation), deltaTime);
            _renderSystem.Update(_ecsManager.GetChunksByArchetype(Archetype.Render), deltaTime);
        }
    }
}