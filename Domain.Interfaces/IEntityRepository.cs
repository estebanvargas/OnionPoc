using System.Collections.Generic;
using Domain.Criteria;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEntityRepository
    {
        IReadOnlyList<Entity> GetEntityListTable(EntityCriteria criteria);
    }
}