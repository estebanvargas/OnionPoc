using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Criteria;
using Infrastructure.Data.Entities;
using Trintech.Cadency.DataAccess.Core;

namespace Infrastructure.Data.Repositories
{
    public class EntityRepository
    {
        const string FUNCTION_NAME = "dbo.fnGetEntityList";

        public IReadOnlyList<Entity> GetEntityListTable(EntityCriteria criteria)
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

            return entities;
        }
    }
}
