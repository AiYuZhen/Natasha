﻿using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Natasha
{
    public static  class AssemblyExtension
    {

        /// <summary>
        /// 创建一个程序集编译类
        /// </summary>
        /// <param name="name">程序集名字</param>
        /// <returns></returns>
        public static NAssembly CreateAssembly(this AssemblyDomain domain, string name = default)
        {
            NAssembly result = new NAssembly(name);
            result.Compiler.Domain = domain;
            return result;
        }




        public static AssemblyDomain GetDomain(this Assembly assembly)
        {

            var assemblyDomain = AssemblyLoadContext.GetLoadContext(assembly);
            if (assemblyDomain == AssemblyLoadContext.Default)
            {
                return DomainManagment.Default;
            }
            return (AssemblyDomain)assemblyDomain;

        }




        public static void RemoveReferences(this Assembly assembly)
        {

            GetDomain(assembly).RemoveAssembly(assembly);

        }



        public static void DisposeDomain(this Assembly assembly)
        {

            GetDomain(assembly).Dispose();

        }

    }
}
