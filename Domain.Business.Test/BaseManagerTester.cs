using System;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Trintech.Cadency.Utility.Exceptions;
using Trintech.TestHelpers;

namespace Domain.Business.Test
{
    [ExcludeFromCodeCoverage]
    public class BaseManagerTester : MockableTest
    {
        protected Mock<ITrintechExceptionManager> MockExceptionManager { get; set; }
        protected DateTime SingleDateTime = new DateTime(2017, 1, 25);

        protected override void CustomizeTestInitialize()
        {
            
            MockExceptionManager = MoqRepository.Create<ITrintechExceptionManager>();

            base.CustomizeTestInitialize();
        }


        public void ExpectToHandleExceptionAndRethrowInvalidOperation(string message)
        {
            MockExceptionManager.Setup(
                x =>
                    x.HandleException(It.IsAny<Exception>(),
                        It.Is<string>(y => y == ExceptionPolicyName.BusinessLogicPolicy.ToString())))
                .Returns(Tuple.Create<bool,Exception>(true, new InvalidOperationException(message)));
        }

        protected TManager GivenTheSystemUnderTest<TManager>(object repository) where TManager : class
        {
            return Activator.CreateInstance(typeof(TManager),
                MockExceptionManager.Object,
                repository
                ) as TManager;
        }
    }
}
