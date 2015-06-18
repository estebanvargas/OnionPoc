using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Models.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntityTests
    {
        [TestMethod]
        public void CompareTest()
        {
            var entity = new EntitityOldVersion.Entity
            {
                Number = "number"
            };
            var entity2 = new EntitityOldVersion.Entity
            {
                Number = "number"
            };
            var compareResult = entity.CompareTo(entity2);
            Assert.AreEqual(compareResult, 0);


        }
    }
}
