using System;
using System.Diagnostics.CodeAnalysis;
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
        public void TestMethod1()
        {
            var criteria = new EntityCriteria();
            var result = SystemUnderTest.GetEntityList(criteria);
        }
    }
}
