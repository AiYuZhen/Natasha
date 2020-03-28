﻿using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Natasha
{
    public class CompilationException
    {

        public CompilationException()
        {

            Diagnostics = new List<Diagnostic>();
            ErrorFlag = CompileError.None;

        }


        //编译日志
        public string Log;

        //错误信息
        public string Message;

        //格式化后的脚本字符串
        public string Formatter;

        //错误类型
        public CompileError ErrorFlag;

        //roslyn诊断集合
        public List<Diagnostic> Diagnostics;
       
    }



    public enum CompileError
    {
        None,
        Assembly,
        Type,
        Method,
        Delegate,
        Syntax,
        Compile
    }

}
