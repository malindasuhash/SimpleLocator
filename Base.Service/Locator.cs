using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service
{
    /// <summary>
    /// This class provides the service locator functionality.
    /// </summary>
    public static class Locator
    {
        private static readonly ISimpleServiceLocator _locator = new SimpleServiceLocator();

        /// <summary>
        /// Returns the Registered <see cref="T"/> from <see cref="Locator"/>.
        /// </summary>
        public static T GetInstance<T>()
        {
            return _locator.Get<T>();
        }

        /// <summary>
        /// Registers an instance of <see cref="T"/> with <see cref="Locator"/>.
        /// </summary>
        public static void SetInstance<T>(T service)
        {
            _locator.Set<T>(service);
        }

        /// <summary>
        /// Initialise the <see cref="Locator"/>.
        /// </summary>
        /// <remarks>
        /// The <see cref="Locator"/> can only be initialised once.
        /// Any attempt to re-initialise with throw <see cref="ServiceLocatorException"/>.
        /// </remarks>
        public static void Initialise()
        {
            _locator.Initialise();
        }
    }
}
