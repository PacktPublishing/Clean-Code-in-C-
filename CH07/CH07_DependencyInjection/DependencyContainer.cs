using System;
using System.Collections.Generic;
using System.Reflection;

namespace CH07_DependencyInjection
{
    public class DependencyContainer
    {
        public static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();
        public static readonly IDictionary<Type, object> Instances = new Dictionary<Type, object>();

        public static void Register<TContract, TImplementation>()
        {
            Types[typeof(TContract)] = typeof(TImplementation);
        }

        public static void Register<TContract, TImplementation>(TImplementation instance)
        {
            Instances[typeof(TContract)] = instance;
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type contract)
        {
            if (Instances.ContainsKey(contract))
            {
                return Instances[contract];
            }
            else
            {
                Type implementation = Types[contract];
                ConstructorInfo constructor = implementation.GetConstructors()[0];
                ParameterInfo[] constructorParameters = constructor.GetParameters();
                if (constructorParameters.Length == 0)
                {
                    return Activator.CreateInstance(implementation);
                }
                List<object> parameters = new List<object>(constructorParameters.Length);
                foreach (ParameterInfo parameterInfo in constructorParameters)
                {
                    parameters.Add(Resolve(parameterInfo.ParameterType));
                }
                return constructor.Invoke(parameters.ToArray());
            }
        }
    }
}
