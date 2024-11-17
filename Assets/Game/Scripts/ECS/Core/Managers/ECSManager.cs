using System.Collections.Concurrent;
using System.Collections.Generic;
using Game.Scripts.ECS.Chunks;
using Game.Scripts.ECS.Component;
using Game.Scripts.ECS.Entity;

namespace Game.Scripts.ECS.Core.Managers
{
    //TODO :::: BREAK INTO CHUNK MANAGER AND ENTITY MANAGER
    public class ECSManager
    {
        private readonly Dictionary<Archetype, List<Chunk>> _chunkListsByArchetype = new ();
        private readonly ConcurrentDictionary<EntityId, Entity.Entity> _entities = new ();

        //TODO :::: MOVE TO ENTITY FACTORY
        public Entity.Entity CreateEntity(params IComponent[] componentTypes)
        {
            var entity = new Entity.Entity(componentTypes);
            AddToBelongingChunk(entity);
            _entities.TryAdd(entity.Data.Id, entity);
            
            return entity;
        }
        
        public List<Chunk> GetChunksByArchetype(Archetype archetype)
        {
            return _chunkListsByArchetype[archetype];
        }

        public Entity.Entity GetEntityById(EntityId id)
        {
            return _entities.GetValueOrDefault(id);
        }

        private void AddToBelongingChunk(Entity.Entity entity)
        {
            if (_chunkListsByArchetype.TryGetValue(entity.Data.Archetype, out var chunkList))
            {
                var lastChunk = chunkList[^1];
                
                if (!lastChunk.TryAddEntity(entity))
                    CreateNewChunk(entity.Data.Archetype).TryAddEntity(entity);    
            }
            else
                CreateNewChunk(entity.Data.Archetype).TryAddEntity(entity);
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