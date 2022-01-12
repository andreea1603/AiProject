using System;

namespace DomainLayer.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
