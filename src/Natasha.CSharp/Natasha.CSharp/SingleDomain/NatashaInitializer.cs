﻿#if !MULTI
using Microsoft.CodeAnalysis;
using Natasha.CSharp;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

public static class NatashaInitializer
{
    private static readonly object _lock = new();

    private static bool _isCompleted = false;
    public static void Preheating(Func<AssemblyName, string?, bool>? excludeReferencesFunc = null)
    {

        if (!_isCompleted)
        {
            lock (_lock)
            {
                if (_isCompleted)
                {
                    return;
                }

                _isCompleted = true;

                if (excludeReferencesFunc == null)
                {
                    excludeReferencesFunc = (_, _) => false;
                }
#if DEBUG
                Stopwatch stopwatch = new();
                stopwatch.Start();
#endif

                DefaultUsing.SetDefaultUsingFilter(excludeReferencesFunc);
                IEnumerable<string>? paths = NatashaReferencePathsHelper.GetReferenceFiles(excludeReferencesFunc);

                
#if DEBUG
                stopwatch.RestartAndShowCategoreInfo("[Reference]", "过滤初始化引用", 1);
#endif
                if (paths!=null && paths.Count()>0)
                {
                    ResolverMetadata(paths);
#if DEBUG
                    stopwatch.RestartAndShowCategoreInfo("[  Domain  ]", "默认信息初始化", 1);
#endif

                    AssemblyCSharpBuilder cSharpBuilder = new();
                    cSharpBuilder.UseNatashaFileOut();
                    cSharpBuilder.ConfigCompilerOption(item => item.AddSupperess("CS8019").UseSuppressReportor(false));
                    cSharpBuilder.EnableSemanticHandler = true;
                    cSharpBuilder.Add(DefaultUsing.UsingScript + "public class A{}");
                    var assembly = cSharpBuilder.GetAssembly();

#if DEBUG
                    stopwatch.StopAndShowCategoreInfo("[FirstCompile]", "初始化编译", 1);
#endif
                }

            }
        }

    }
    private static void ResolverMetadata(IEnumerable<string> paths)
    {

            Parallel.ForEach(paths, (path) =>
            {
                //Assembly? assembly = null;
                try
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoadFrom(path);
                    NatashaReferenceCache.AddReference(path);
                    DefaultUsing.AddUsingWithoutCheck(assembly);
                }
                catch
                {
                    //Console.WriteLine(assembly?.FullName);
                }

            });
 

    }

}
#endif