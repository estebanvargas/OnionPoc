using System;
using System.Diagnostics.CodeAnalysis;
using Infrastructure.Data.Repositories;
using Moq;
using ServiceStack.OrmLite;
using Trintech.Cadency.DataAccess.Core;
using Trintech.Cadency.Utility.Exceptions;
using Trintech.TestHelpers;

namespace Infrastructure.Data.Tests.Repositories
{
    [ExcludeFromCodeCoverage]
    public class BaseRepositoryTester<TRepository> : MockableTest
        where TRepository : Repository
    {
        protected Mock<ICadencyOrm> MockOrm { get; set; }
        protected Mock<ITrintechExceptionManager> MockExceptionManager { get; set; }
        protected TRepository SystemUnderTest { get; set; }

        protected override void CustomizeTestInitialize()
        {
            MockOrm = MoqRepository.Create<ICadencyOrm>();

            CadencyOrm.Initialize(MockOrm.Object);

            MockExceptionManager = MoqRepository.Create<ITrintechExceptionManager>();

            SystemUnderTest = Activator.CreateInstance(typeof(TRepository), MockExceptionManager.Object) as TRepository;

            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;

            base.CustomizeTestInitialize();
        }
    }
}