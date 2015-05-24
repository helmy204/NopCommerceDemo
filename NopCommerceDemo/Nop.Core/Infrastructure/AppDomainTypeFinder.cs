using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// A class that finds types needed by Nop by looping assemblies in the
    /// currently executing AppDomain. Only assemblies whose names matches
    /// certain patterns are investigated and an optional list of assemblies
    /// referred by <see cref="AssemblyNames"/> are always investigated.
    /// </summary>
    public class AppDomainTypeFinder:ITypeFinder
    {
        public IList<System.Reflection.Assembly> GetAssemblies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> FindClasswsOfType(Type assignTypeFrom, bool onlyConcreteClassess = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<System.Reflection.Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> FindClassesOfType<T>(IEnumerable<System.Reflection.Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            throw new NotImplementedException();
        }
    }
}
