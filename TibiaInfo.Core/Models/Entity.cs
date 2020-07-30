using System;

namespace TibiaInfo.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}