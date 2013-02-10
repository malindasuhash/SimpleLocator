using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service
{
    /// <summary>
    /// This custom exception to indicate <see cref="ServiceLocator"/> fatal errors.
    /// </summary>
    public class ServiceLocatorException : Exception
    {
        public ServiceLocatorException(string message)
            : base(message)
        {
        }
    }
}
