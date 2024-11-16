using System.Collections.Generic;

namespace Game.Scripts.ECS.Core.Managers
{
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