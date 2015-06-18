using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trintech.Cadency.Utility.Exceptions;


namespace Domain.Business.Test
{
    [ExcludeFromCodeCoverage]
    public class ManagerBaseTss : ManagerBase
    {
        public ManagerBaseTss(ITrintechExceptionManager exceptionManager) : base(exceptionManager)
        {
        }
    }
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ManagerBaseTests : BaseManagerTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionManagerNullTests()
        {
            new ManagerBaseTss(null);
        }
    }
}
