using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain.Criteria;
using Domain.Interfaces.Business;
using Domain.Interfaces.Repositories;
using Domain.Models.EntitityOldVersion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Domain.Business.Test
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntitiesManagerTests : BaseManagerTester
    {
        private Mock<IEntityRepository> _mockRepository;
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorNullRepoParameter()
        {
            new EntitiesManager(MockExceptionManager.Object, null);
        }

        protected override void CustomizeTestInitialize()
        {
            _mockRepository = MoqRepository.Create<IEntityRepository>();
            base.CustomizeTestInitialize();
        }

        [TestMethod]
        public void GetEntityListTest()
        {
            IReadOnlyList<Models.Entity> list = new List<Models.Entity>()
            {
                
                new Models.Entity
                {
                    Id = 1,
                    ParentId = null
                },
                new Models.Entity
                {
                    Id = 2,
                    ParentId = 1
                }
            };
            _mockRepository.Setup(r => r.GetEntityList(
                It.IsAny<EntityCriteria>()
                )).Returns(list);
            var system = GivenTheSystemUnderTest<EntitiesManager>(_mockRepository.Object);
            var criteria = new EntityCriteria
            {
                CloseDayMapId = -1,
                ClosePeriodId = -1,
                PeriodEndDate = null,
                UserName = String.Empty
            };
            List<Entity> result = system.GetEntityList(criteria);
            Assert.IsNotNull(result, "result is null");
            Assert.IsTrue(result.Count == 1, "result.Count is not 1");
            var parent = result[0];
            Assert.AreEqual(parent.Id, 1, "parent.id is not 1");
            Assert.AreEqual(parent.Entities.Count(), 1, "children of parent is different than 1");
            var child = parent.Entities.First();
            Assert.AreEqual(child.Id, 2, "first children.id is not 2");

        }

    }
}
