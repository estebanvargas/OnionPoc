using System.Collections.Generic;
using Domain.Criteria;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IEntityRepository
    {
        IReadOnlyList<Entity> GetEntityList(EntityCriteria criteria);
    }
}
