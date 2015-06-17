using System.Collections.Generic;
using Domain.Criteria;
using Domain.Models.EntitityOldVersion;

namespace Domain.Interfaces.Business
{
    public interface IEntitiesManager
    {
        List<Entity> GetEntityList(EntityCriteria criteria);
    }
}