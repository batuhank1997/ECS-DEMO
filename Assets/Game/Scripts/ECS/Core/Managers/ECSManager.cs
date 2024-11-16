using System.Collections.Generic;

namespace Game.Scripts.ECS.Core.Managers
{
    public class ECSManager
    {
        private int _nextEntityId = 1;
        private readonly Dictionary<Archetype, Chunk> _chunksByArchetype = new ();
        
        public Entity CreateEntity(params IComponent[] componentTypes)
        {
            var entity = new Entity(new EntityId(_nextEntityId++), componentTypes);
            
            AddToBelongingChunk(entity);
            
            return entity;
        }

        private void AddToBelongingChunk(Entity entity)
        {
            if (_chunksByArchetype.TryGetValue(entity.Archetype, out var chunk))
                chunk.AddEntity(entity);
            else
                CreateNewChunk(entity.Archetype).AddEntity(entity);
        }

        private Chunk CreateNewChunk(Archetype archetype)
        {
            var newChunk = new Chunk(archetype);
            _chunksByArchetype.Add(newChunk.Archetype, newChunk);
            return newChunk;
        }
    }
    
    public class Chunk
    {
        public readonly Archetype Archetype;
        
        public readonly List<Entity> Entities;
        
        public Chunk(Archetype archetype, int size = 16)
        {
            Archetype = archetype;
            Entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }
    }
}