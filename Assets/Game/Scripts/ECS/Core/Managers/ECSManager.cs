using System.Collections.Generic;

namespace Game.Scripts.ECS.Core.Managers
{
    public class ECSManager
    {
        private int _nextEntityId = 0;
        private readonly Dictionary<Archetype, List<Chunk>> _chunkListsByArchetype = new ();
        
        public Entity CreateEntity(params IComponent[] componentTypes)
        {
            var entity = new Entity(new EntityId(_nextEntityId++), componentTypes);
            AddToBelongingChunk(entity);
            
            return entity;
        }

        private void AddToBelongingChunk(Entity entity)
        {
            if (_chunkListsByArchetype.TryGetValue(entity.Archetype, out var chunkList))
            {
                var lastChunk = chunkList[^1];
                
                if (!lastChunk.TryAddEntity(entity))
                    CreateNewChunk(entity.Archetype).TryAddEntity(entity);    
            }
            else
                CreateNewChunk(entity.Archetype).TryAddEntity(entity);
        }

        private Chunk CreateNewChunk(Archetype archetype)
        {
            var newChunk = new Chunk(archetype);

            if (_chunkListsByArchetype.TryGetValue(archetype, out var chunkList))
                chunkList.Add(newChunk);
            else
                _chunkListsByArchetype.Add(archetype, new List<Chunk> { newChunk });
            
            return newChunk;
        }

        public bool TryGetChunkListByArchetype(Archetype entityArchetype, out List<Chunk> chunkList)
        {
            return _chunkListsByArchetype.TryGetValue(entityArchetype, out chunkList);
        }
    }
}