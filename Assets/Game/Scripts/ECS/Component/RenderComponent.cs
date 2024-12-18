﻿using Game.Scripts.ECS.Component.Base;
using UnityEngine;

namespace Game.Scripts.ECS.Component
{
    public struct RenderComponent : IComponent
    {
        public ComponentType Type => ComponentType.Render;
        
        public RenderData RenderData;
        
        public RenderComponent(RenderData renderData)
        {
            RenderData = renderData;
        }
    }
    
    public readonly struct RenderData
    {
        public readonly Mesh Mesh;
        public readonly Material Material;
        public readonly Matrix4x4 Matrix4x4;

        public RenderData(Mesh mesh, Material material, Matrix4x4 matrix4X4)
        {
            Mesh = mesh;
            Material = material;
            Matrix4x4 = matrix4X4;
        }
    }
}