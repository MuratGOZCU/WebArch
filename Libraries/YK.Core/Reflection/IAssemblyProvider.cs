using System.Collections.Generic;
using System.Reflection;

namespace YK.Core.Reflection
{
    public interface IAssemblyProvider
    {
        IEnumerable<Assembly> GetAssemblies();
    }
}