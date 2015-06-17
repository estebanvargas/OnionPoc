using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Criteria;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Infrastructure.Data.Tests.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntityRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = GivenTheSystemUnderTest();
            var criteria = new EntityCriteria();
            var result = repo.GetEntityListTable(criteria);
        }

        private static IEntityRepository GivenTheSystemUnderTest()
        {
            return new EntityRepository();
        }
    }
}
