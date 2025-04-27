using System;
using System.Linq;
using System.Reflection;

namespace DZCP.Loader
{
    public class DependencyResolver
    {
        public object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors();
            if (constructors.Length == 0)
            {
                return Activator.CreateInstance(type);
            }

            var constructor = constructors.OrderByDescending(c => c.GetParameters().Length).First();
            var parameters = constructor.GetParameters();
            var args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = Activator.CreateInstance(parameters[i].ParameterType);
            }

            return constructor.Invoke(args);
        }
    }
}