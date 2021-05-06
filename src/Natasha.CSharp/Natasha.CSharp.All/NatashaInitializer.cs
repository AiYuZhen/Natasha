﻿using Microsoft.Extensions.DependencyModel;
using Natasha.CSharp;
using System;
using System.Threading.Tasks;

public static class NatashaInitializer
{
    private static bool _hasInitialize;
    private static readonly object _lock;

    static NatashaInitializer()
    {
        
        _lock = new object();
    }

    /// <summary>
    /// 初始化 Natasha 组件
    /// </summary>
    public static async Task Initialize(bool initializeReference = true)
    {
        if (!_hasInitialize)
        {
            lock (_lock)
            {
                if (!_hasInitialize)
                {
                    _hasInitialize = true;
                    NatashaComponentRegister.RegistDomain<NatashaAssemblyDomain>(initializeReference);
                    NatashaComponentRegister.RegistCompiler<NatashaCSharpCompiler>();
                    NatashaComponentRegister.RegistSyntax<NatashaCSharpSyntax>();
                }
            }
            
        }
       
    }

    /// <summary>
    /// 初始化 Natasha 组件并预热
    /// </summary>
    /// <returns></returns>
    public static async Task InitializeAndPreheating(bool initializeReference = true)
    {

        Initialize(initializeReference);
        var domain = DomainComponent.Random;
        if (initializeReference)
        {
            domain.AddReferencesFromDllFile(typeof(object).Assembly.Location);
        }
        var action = NDelegate.UseDomain(domain).Action("");
        action();
        action.DisposeDomain();     

    }
}

