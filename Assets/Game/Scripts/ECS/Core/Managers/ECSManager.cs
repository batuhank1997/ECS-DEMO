using System.Collections.Concurrent;
using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Component.Base;
using Game.Scripts.ECS.Entities;
using Game.Scripts.ECS.Utility;

namespace Game.Scripts.ECS.Core.Managers
{
    //TODO :::: BREAK INTO CHUNK MANAGER AND ENTITY MANAGER
    public class ECSManager
    {
        private readonly Dictionary<Archetype, List<Chunk>> _chunkListsByArchetype = new ();
        private readonly ConcurrentDictionary<EntityId, Entity> _entities = new ();
        
        private readonly List<Chunk> _emptyChunkList = new ();

        //TODO :::: MOVE TO ENTITY FACTORY
        public void CreateEntity(params IComponent[] components)
        {
            var entity = new Entity(components);
            
            AddToBelongingChunk(entity);
            
            _entities.TryAdd(entity.Data.Id, entity);
        }
        
        public List<Chunk> GetChunksByArchetype(Archetype archetype)
        {
            return _chunkListsByArchetype.GetValueOrDefault(archetype, _emptyChunkList);
        }
        
        public List<Chunk> GetChunksWithComponent(ComponentType componentType)
        {
            var chunks = new List<Chunk>();

            foreach (var chunkList in _chunkListsByArchetype.Values)
            {
                foreach (var chunk in chunkList)
                {
                    if (ArchetypeUtility.IsArchetypeHasComponent(chunk.Data.Archetype, componentType))
                        chunks.Add(chunk);
                }
            }

            return chunks;
        }

        public Entity GetEntityById(EntityId id)
        {
            return _entities.GetValueOrDefault(id);
        }

        private void AddToBelongingChunk(Entity entity)
        {
            if (_chunkListsByArchetype.TryGetValue(entity.Data.Archetype, out var chunkList))
            {
                if (!chunkList[^1].IsFull())
                    chunkList[^1].AddEntity(entity);
                else
                    CreateNewChunk(entity.Data.Archetype).AddEntity(entity);    
            }
            else
                CreateNewChunk(entity.Data.Archetype).AddEntity(entity);
        }

        //TODO :::: MOVE TO CHUNK FACTORY
        private Chunk CreateNewChunk(Archetype archetype)
        {
            var newChunk = new Chunk(archetype);

            if (_chunkListsByArchetype.TryGetValue(archetype, out var chunkList))
                chunkList.Add(newChunk);
            else
                _chunkListsByArchetype.Add(archetype, new List<Chunk> { newChunk });
            
            return newChunk;
        }
    }
}