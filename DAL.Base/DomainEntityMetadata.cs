using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public abstract class DomainEntityMetadata : DomainEntity, IDomainEntityMetadata
    {
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
    }
}