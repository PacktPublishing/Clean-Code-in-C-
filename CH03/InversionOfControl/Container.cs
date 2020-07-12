using System;
using System.Collections.Generic;

namespace CH3.InversionOfControl
{
    /// <summary>
    /// Inversion of control container.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// The container used to create and inject.
        /// </summary>
        /// <param name="container">Container</param>
        /// <returns></returns>
        public delegate object Creator(Container container);

        private readonly Dictionary<string, object> configuration = new Dictionary<string, object>();
        private readonly Dictionary<Type, Creator> typeToCreator = new Dictionary<Type, Creator>();

        /// <summary>
        /// Gets the configuration metadata.
        /// </summary>
        public Dictionary<string, object> Configuration
        {
            get { return configuration; }
        }

        /// <summary>
        /// Dependency register.
        /// </summary>
        /// <typeparam name="T">The dependency type</typeparam>
        /// <param name="creator"></param>
        public void Register<T>(Creator creator)
        {
            typeToCreator.Add(typeof(T), creator);
        }

        /// <summary>
        /// Returns an instance of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Instance of type T.</returns>
        public T Create<T>()
        {
            return (T)typeToCreator[typeof(T)](this);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <typeparam name="T">The configuration type</typeparam>
        /// <param name="name">The configuration name</param>
        /// <returns>Configuration</returns>
        public T GetConfiguration<T>(string name)
        {
            return (T)configuration[name];
        }
    }
}
