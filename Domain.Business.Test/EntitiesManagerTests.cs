using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public void CtorNullParameter()
        {
            new EntitiesManager(null, null);
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
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

    }
}
