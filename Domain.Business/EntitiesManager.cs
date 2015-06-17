using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Criteria;
using Domain.Interfaces.Business;
using Domain.Interfaces.Repositories;
using Domain.Models.EntitityOldVersion;
using Infrastructure.Data.Repositories;
using Trintech.Cadency.Utility.Exceptions;

namespace Domain.Business
{
    public class EntitiesManager : ManagerBase, IEntitiesManager
    {
        private readonly IEntityRepository _repository;

        public EntitiesManager(ITrintechExceptionManager exceptionManager, IEntityRepository repository)
            : base(exceptionManager)
        {
            
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public List<Entity> GetEntityList(EntityCriteria criteria)
        {
            IReadOnlyList<Models.Entity> list = _repository.GetEntityList(criteria).Distinct().ToList();
            var result = new List<Entity>();

            foreach (var entity in list)
            {
                //We really dont need all the list to be copied again, just the parent ones.
                if (entity.ParentId.HasValue && entity.ParentId.Value > 0)
                {
                    continue;
                }
                //TODO: user automapper for this.
                var bizModel = new Entity
                {
                    Id = entity.Id
                };
                bizModel.Entities = FillChildren(bizModel.Id, list);
                result.Add(bizModel);
            }

            result.Sort();
            return result;
            
        }
        private static IEnumerable<Entity> FillChildren(int parentId, IReadOnlyList<Models.Entity> allEntities)
        {
            var children = new List<Entity>();

            foreach (var entityChildren in allEntities)
            {
                if (entityChildren.ParentId == parentId)
                {
                    var mappedChildren = new Entity
                    {
                        Id = entityChildren.Id,
                        Entities = FillChildren(entityChildren.Id, allEntities)
                    };
                    children.Add(mappedChildren);
                }
            }

            children.Sort();
            return children;

        }
    }
}