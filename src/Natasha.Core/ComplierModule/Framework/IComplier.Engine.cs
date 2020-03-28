﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;

namespace Natasha.Core.Compiler
{

    public abstract partial class ICompiler
    {

        public HashSet<string> Sets;

        /// <summary>
        /// 使用内存流进行脚本编译
        /// </summary>
        /// <param name="sourceContent">脚本内容</param>
        /// <param name="errorAction">发生错误执行委托</param>
        /// <returns></returns>
        public (Assembly Assembly, ImmutableArray<Diagnostic> Errors, CSharpCompilation Compilation) StreamCompiler()
        {

            lock (this)
            {

                References.Clear();
                if (Domain != DomainManagment.Default)
                {

                    var defaultDomain = DomainManagment.Default;
                    HashSet<PortableExecutableReference> sets;
                    lock (defaultDomain.ReferencesCache)
                    {

                        sets = new HashSet<PortableExecutableReference>(defaultDomain.ReferencesCache);

                    }


                    foreach (var item in _domain.ShortReferenceMappings)
                    {

                        if (defaultDomain.ShortReferenceMappings.ContainsKey(item.Key))
                        {

                            sets.Remove(defaultDomain.ShortReferenceMappings[item.Key]);

                        }

                    }


                    lock (_domain.ReferencesCache)
                    {

                        References.AddRange(_domain.ReferencesCache);

                    }
                    References.AddRange(sets);

                }
                else
                {

                    lock (_domain.ReferencesCache)
                    {

                        References.AddRange(_domain.ReferencesCache);

                    }

                }


                //创建语言编译
                CSharpCompilation compilation = CSharpCompilation.Create(
                                   AssemblyName,
                                   options: new CSharpCompilationOptions(
                                       outputKind: OutputKind.DynamicallyLinkedLibrary,
                                       optimizationLevel: OptimizationLevel.Release,
                                       allowUnsafe: true),
                                   syntaxTrees: SyntaxInfos.TreeCodeMapping.Keys,
                                   references: References);


                //编译并生成程序集
                if (CompileTarget == CompilerResultTarget.Stream)
                {


                    MemoryStream stream = new MemoryStream();
                    var CompileResult = compilation.Emit(stream);
                    if (CompileResult.Success)
                    {

                        return (_domain.Handler(stream), default, compilation);

                    }
                    else
                    {

                        stream.Dispose();
                        return (null, CompileResult.Diagnostics, compilation);

                    }


                }
                else
                {


                    if (!Directory.Exists(_domain.DomainPath))
                    {

                        Directory.CreateDirectory(_domain.DomainPath);

                    }


                    var path = Path.Combine(_domain.DomainPath, AssemblyName);
                    DllFilePath = path + ".dll";
                    PdbFilePath = path + ".pdb";


                    var CompileResult = compilation.Emit(DllFilePath, PdbFilePath);
                    if (CompileResult.Success)
                    {

                        return (_domain.Handler(new FileStream(DllFilePath, FileMode.Open, FileAccess.Read)), default, compilation);

                    }
                    else
                    {

                        return (null, CompileResult.Diagnostics, compilation);

                    }


                }

            }

        }

    }

}
