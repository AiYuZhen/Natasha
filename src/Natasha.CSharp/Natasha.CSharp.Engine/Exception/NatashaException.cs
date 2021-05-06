﻿using Microsoft.CodeAnalysis;
using Natasha.Error;
using Natasha.Error.Model;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Natasha.CSharpEngine.Error
{
    public class NatashaExceptionWrapper
    {
        /// <summary>
        /// 获取语法树异常信息
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static NatashaException GetSyntaxException(SyntaxTree tree)
        {

            NatashaException exception;
            var diagnostics = tree.GetDiagnostics();
            if (diagnostics==null)
            {

                exception = new NatashaException();
            }
            else
            {

                StringBuilder builder = new StringBuilder();
                foreach (var item in diagnostics)
                {
                    builder.AppendLine(item.GetMessage());
                }
                exception = new NatashaException(builder.ToString());
                exception.Formatter = tree.ToString();
                builder.Insert(0, exception.Formatter);
                exception.Log = builder.ToString();
                exception.Diagnostics.AddRange(diagnostics);
                exception.ErrorFlag = ExceptionKind.Syntax;

            }
            exception.Tree = tree;
            return exception;

        }

        /// <summary>
        /// 获取编译异常信息
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static List<NatashaException> GetCompileException(string assemblyName, ImmutableArray<Diagnostic> errors)
        {

            var exceptions = new Dictionary<string, NatashaException>();
            var results = new List<NatashaException>();
            foreach (var item in errors)
            {

                var tree = item.Location.SourceTree;
                if (tree == null)
                {

                    if (results.Count == 0)
                    {
                        results.Add(new NatashaException($"编译错误 : {item.Id} {item.GetMessage()}") { ErrorFlag = ExceptionKind.Compile, Name = assemblyName });
                    }
                    results[0].Diagnostics.Add(item);

                }
                else
                {
                    var key = tree.ToString();
                    if (!exceptions.ContainsKey(key))
                    {
                        exceptions[key] = new NatashaException($"编译错误 : {item.Id} {item.GetMessage()}") { ErrorFlag = ExceptionKind.Compile, Name = assemblyName, Formatter = key };
                    }
                    exceptions[key].Diagnostics.Add(item);

                }

            }
            results.AddRange(exceptions.Values);
            return results;

        }
    }
}
