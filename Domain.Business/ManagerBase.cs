using System;
using Trintech.Cadency.Utility.Exceptions;

namespace Domain.Business
{
    /// <summary>
    /// Base class for business managers
    /// </summary>
    public abstract class ManagerBase : IBusinessExceptionsAreManaged
    {
        public ITrintechExceptionManager ExceptionManager { get; private set;}


        /// <summary>
        /// Initializes a new instance of the <see cref="CertRepositoryBase"/> class.
        /// </summary>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <exception cref="System.ArgumentNullException">exceptionManager</exception>
        protected ManagerBase(ITrintechExceptionManager exceptionManager)
        {
            if (exceptionManager == null)
            {
                throw new ArgumentNullException("exceptionManager");
            }

            ExceptionManager = exceptionManager;
        }
    }
}
