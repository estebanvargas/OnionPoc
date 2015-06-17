using System;
using System.Collections.Generic;
using Domain.Criteria;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Entities;
using Trintech.Cadency.DataAccess.Core;
using Trintech.Cadency.Utility;
using Trintech.Cadency.Utility.Exceptions;
using MyDomain = Domain.Models;

namespace Infrastructure.Data.Repositories
{
    public class EntityRepository : Repository, IEntityRepository
    {
        const string FUNCTION_NAME = "dbo.fnGetEntityList";

        public EntityRepository(ITrintechExceptionManager exceptionManager)
            : base(exceptionManager)
        {
        }

        public IReadOnlyList<MyDomain.Entity> GetEntityList(EntityCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }

            var parameters = new Dictionary<string, object>
                    {
                        {"@userName", criteria.UserName},
                        {"@closePeriodId", criteria.ClosePeriodId},
                        {"@closeDayMapId", criteria.CloseDayMapId},
                        {"@periodEndDate", criteria.PeriodEndDate}
                    };

            return this.WrapFuncWithExceptionLogging(() =>
            {
                IReadOnlyList<Entity> entities = CadencyOrm.GetByFunction<Entity>(FUNCTION_NAME, parameters);
                var dom = TrintechObjectMapper.Map<Entity, MyDomain.Entity>(entities);
                return dom;
            });
        }
    }
}
