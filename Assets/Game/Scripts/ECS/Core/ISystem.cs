using System.Collections.Generic;

namespace Game.Scripts.ECS.Core
{
    public interface ISystem
    {
        void Update(List<Chunk> chunkList, float deltaTime);
    }
}