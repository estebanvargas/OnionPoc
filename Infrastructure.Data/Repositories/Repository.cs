using System;
using Trintech.Cadency.Utility.Exceptions;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// Base class for repositories
    /// </summary>
    public abstract class Repository : IDataExceptionsAreManaged
    {
        public ITrintechExceptionManager ExceptionManager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <exception cref="System.ArgumentNullException">exceptionManager</exception>
        protected Repository(ITrintechExceptionManager exceptionManager)
        {
            if (exceptionManager == null)
            {
                throw new ArgumentNullException("exceptionManager");
            }

            ExceptionManager = exceptionManager;
        }
    }
}