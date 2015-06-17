using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using Domain.Criteria;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Infrastructure.Data.Tests.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntityRepositoryTest : BaseRepositoryTester<EntityRepository>
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EntityRepoNullParameter()
        {
            new EntityRepository(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEntityListNullCriteria()
        {
            var actual = SystemUnderTest.GetEntityList(null);
        }

        [TestMethod] public void GetEntityListTest()
        {
            var functionName = "dbo.fnGetEntityList";

            var criteria = new EntityCriteria()
            {
                UserName = string.Empty,
                CloseDayMapId = -1,
                ClosePeriodId = -1,
                PeriodEndDate = null
            };

            var parameters = new Dictionary<string, object>
            {
                {"@userName", criteria.UserName},
                {"@closePeriodId", criteria.ClosePeriodId},
                {"@closeDayMapId", criteria.CloseDayMapId},
                {"@periodEndDate", criteria.PeriodEndDate}
            };

            var entityList = GivenAListOfEntities() as IReadOnlyList<Entities.Entity>;

            MockOrm.Setup(orm => orm.GetByFunction<Entities.Entity>(functionName, parameters)).Returns(entityList);

            var actual = SystemUnderTest.GetEntityList(criteria);

            Assert.IsNotNull(actual);
            ValidateEntities(actual, entityList);
        }

        private void ValidateEntities(IReadOnlyList<Domain.Models.Entity> actual, IReadOnlyList<Entities.Entity> expected)
        {
            Assert.AreEqual(expected[0].CreatedDate, actual[0].CreatedDate, "EntityRepositoryTest: CreatedDate is not equal");
            Assert.AreEqual(expected[0].ClosePeriodId, actual[0].ClosePeriodId, "EntityRepositoryTest: ClosePeriodId is not equal");
            Assert.AreEqual(expected[0].DefinitionId, actual[0].DefinitionId, "EntityRepositoryTest: DefinitionId is not equal");
            Assert.AreEqual(expected[0].ParentId, actual[0].ParentId, "EntityRepositoryTest: ParentId is not equal");
            Assert.AreEqual(expected[0].PublishingSourceId, actual[0].PublishingSourceId, "EntityRepositoryTest: PublishingSourceId is not equal");
            Assert.AreEqual(expected[0].TaskTreeId, actual[0].TaskTreeId, "EntityRepositoryTest: TaskTreeId is not equal");
            Assert.AreEqual(expected[0].CallbackParams, actual[0].CallbackParams, "EntityRepositoryTest: CallbackParams is not equal");
            Assert.AreEqual(expected[0].CallbackUrl, actual[0].CallbackUrl, "EntityRepositoryTest: CallbackUrl is not equal");
            Assert.AreEqual(expected[0].Name, actual[0].Name, "EntityRepositoryTest: Name is not equal");
            Assert.AreEqual(expected[0].Number, actual[0].Number, "EntityRepositoryTest: Number is not equal");
            Assert.AreEqual(expected[0].RecordStatus, actual[0].RecordStatus, "EntityRepositoryTest: RecordStatus is not equal");
            Assert.AreEqual(expected[0].RowVersion, actual[0].RowVersion, "EntityRepositoryTest: RowVersion is not equal");
        }

        private List<Entities.Entity> GivenAListOfEntities()
        {
            var list = new List<Entities.Entity>();

            var entitie = new Entities.Entity()
            {
                CreatedDate = new DateTime(12,1,2),
                ClosePeriodId = -1,
                DefinitionId  = -1,
                ParentId = -1,
                PublishingSourceId = -1,
                TaskTreeId = -1,
                CallbackParams = string.Empty,
                CallbackUrl = string.Empty,
                Name = string.Empty,
                Number = string.Empty,
                RecordStatus = string.Empty,
                RowVersion = string.Empty
            };

            list.Add(entitie);
            return list;
        }
    }
}
