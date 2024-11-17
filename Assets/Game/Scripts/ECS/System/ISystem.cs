using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;

namespace Game.Scripts.ECS.System
{
    public interface ISystem
    {
        void Update(List<Chunk> chunkList, float deltaTime);
    }
}