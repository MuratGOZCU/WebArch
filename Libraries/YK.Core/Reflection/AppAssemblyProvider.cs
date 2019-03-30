#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

#endregion

namespace YK.Core.Reflection
{
    public class AppAssemblyProvider : IAssemblyProvider
    {
        #region Consts

        private const string AssemblySkipPattern = 
            "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|" + 
            "^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|" + 
            "^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|" + 
            "^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|" + 
            "^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|" + 
            "^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|" + 
            "^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        #endregion

        #region Utils

        private bool Matches(string assemblyFullName) =>
            !Matches(assemblyFullName, AssemblySkipPattern);

        private bool Matches(string assemblyFullName, string pattern) =>
            Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        #endregion

        public IEnumerable<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (Matches(assembly.FullName))
                    if (assemblies.All(x => x.FullName != assembly.FullName))
                        assemblies.Add(assembly);

            return assemblies;
        }
    }
}