using System;
using System.Collections.Generic;
using Domain.Criteria;
using Domain.Interfaces;
using Infrastructure.Data.Entities;
using Trintech.Cadency.DataAccess.Core;

namespace Infrastructure.Data.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        const string FUNCTION_NAME = "dbo.fnGetEntityList";

       IReadOnlyList<Domain.Models.Entity> IEntityRepository.GetEntityListTable(EntityCriteria criteria)
        {
            IReadOnlyList<Entity> entities = null;

            try
            {
                if (criteria == null)
                {
                    //initialize criteria
                }

                entities = CadencyOrm.GetByFunction<Entity>(FUNCTION_NAME, new Dictionary<string, object>());
            }
            catch (Exception ex)
            {
                //
            }

            return null;
        }

        
       
    }
}
