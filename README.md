<p align="center">
  <span>中文</span> |  
  <a href="https://github.com/dotnetcore/natasha/tree/master/lang/english">English</a>
</p>
<p align="center"> <span>你们的反馈是我的动力，文档还有很多不足之处；</span> </p>
<p align="center"> <span> 当你看完文档之后仍然不知道如何实现你的需求，可以在issue中提出你的需求。</span> </p>

# Natasha 

[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/dotnetcore)
[![NuGet Badge](https://buildstats.info/nuget/DotNetCore.Natasha?includePreReleases=true)](https://www.nuget.org/packages/DotNetCore.Natasha)
[![Gitter](https://badges.gitter.im/dotnetcore/natasha.svg)](https://gitter.im/dotnetcore/Natasha?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![Badge](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu/#/zh_CN)
[![GitHub license](https://img.shields.io/github/license/dotnetcore/natasha.svg)](https://github.com/dotnetcore/Natasha/blob/master/LICENSE)

&ensp;&ensp;&ensp;&ensp;基于roslyn的动态编译库，为您提供高效率、高性能、可追踪的动态构建方案，兼容stanadard2.0, 只需原生C#语法不用Emit。
让您的动态方法更加容易编写、跟踪、维护。  欢迎参与讨论：[点击加入Gitter讨论组](https://gitter.im/dotnetcore/Natasha)


 ![展示](https://github.com/dotnetcore/Natasha/blob/master/Image/Natasha.gif)
<br/>

### 类库信息(Library Info)  

[![GitHub tag (latest SemVer)](https://img.shields.io/github/tag/dotnetcore/natasha.svg)](https://github.com/dotnetcore/Natasha/releases) ![GitHub repo size](https://img.shields.io/github/repo-size/dotnetcore/Natasha.svg) [![GitHub commit activity](https://img.shields.io/github/commit-activity/m/dotnetcore/natasha.svg)](https://github.com/dotnetcore/Natasha/commits/master) [![Codecov](https://img.shields.io/codecov/c/github/dotnetcore/natasha.svg)](https://codecov.io/gh/dotnetcore/Natasha)  

| Scan Name | Status |
|--------- |------------- |
| Document | [![wiki](https://img.shields.io/badge/wiki-ch-blue.svg)](https://github.com/dotnetcore/Natasha/wiki) |
| Lang | ![Complie](https://img.shields.io/badge/script-csharp-green.svg)|
| OS | ![Windows](https://img.shields.io/badge/os-windows-black.svg) ![linux](https://img.shields.io/badge/os-linux-black.svg) ![mac](https://img.shields.io/badge/os-mac-black.svg)|
| Rumtime | ![standard](https://img.shields.io/badge/platform-standard2.0-blue.svg) ![standard](https://img.shields.io/badge/platform-netcore3.0-blue.svg) ![standard](https://img.shields.io/badge/platform-netcore3.1-blue.svg)| 

<br/>  

### 持续构建(CI Build Status)  

| CI Platform | Build Server | Master Build  | Master Test |
|--------- |------------- |---------| --------|
| Github | linux/mac/windows | [![Build status](https://img.shields.io/github/workflow/status/dotnetcore/Natasha/.NET%20Core/master)](https://github.com/dotnetcore/Natasha/actions) ||
| Azure |  Windows |[![Build Status](https://dev.azure.com/NightMoonStudio/Natasha/_apis/build/status/dotnetcore.Natasha?branchName=master&jobName=Windows)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master)|[![Build Status](https://img.shields.io/azure-devops/tests/NightMoonStudio/Natasha/3/master.svg)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master) |
| Azure |  Linux |[![Build Status](https://dev.azure.com/NightMoonStudio/Natasha/_apis/build/status/dotnetcore.Natasha?branchName=master&jobName=Linux)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master)|[![Build Status](https://img.shields.io/azure-devops/tests/NightMoonStudio/Natasha/3/master.svg)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master) | 
| Azure |  Mac |[![Build Status](https://dev.azure.com/NightMoonStudio/Natasha/_apis/build/status/dotnetcore.Natasha?branchName=master&jobName=macOS)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master)|[![Build Status](https://img.shields.io/azure-devops/tests/NightMoonStudio/Natasha/3/master.svg)](https://dev.azure.com/NightMoonStudio/Natasha/_build/latest?definitionId=3&branchName=master) | 


 
<br/>  

### 性能测试
      
   - [x]  **动态调用性能测试（对照组： emit, origin）**  
     ![字段性能测试](https://github.com/dotnetcore/Natasha/blob/master/Image/Natasha%E6%80%A7%E8%83%BD%E6%B5%8B%E8%AF%951.png)
   - [x]  **动态初始化性能测试（对照组： emit, origin）**  
     ![初始化性能测试](https://github.com/dotnetcore/Natasha/blob/master/Image/Natasha%E6%80%A7%E8%83%BD%E6%B5%8B%E8%AF%952.png)
   - [x]  **内存及CPU监测截图**  
     ![内存及CPU](https://github.com/dotnetcore/Natasha/blob/master/Image/%E8%B5%84%E6%BA%90%E7%9B%91%E6%B5%8B.png) 
     

<br/>    

### Wiki审核

Teng(359768998@qq.com)

<br/>    

### 代码审核

WeihanLi

<br/>    

### 发布日志  
  
  - 2020-01-03 ： 发布v2.9.0.0, 修改大量静态初始化 API, 支持运行时引发异常， 支持新域内外部插件优先覆盖系统域插件进行编译， 修复若干编译器 BUG。 补操作文档：https://github.com/dotnetcore/Natasha/blob/master/docs/zh/api/static-init.md 。
  
  - 2020-01-06 ： 发布v2.9.6.0, 补加无参的 UnsafeAction / AsyncAction / UnsafeAsyncAction API；语法检测增加日志开关和异常引发。
  
  - 2020-01-10 ： 发布v2.9.6.1, 增加反解器的区分， List\<T\> 由 GetDevelopName 返回， List<> 由 GetRuntimeName 返回, 移除编译依赖。
    
  - 2020-01-13 ： 发布v2.9.7.0, 默认关闭成功日志提升性能，AssemblyDomain 增加事件以便外部调用者跟踪插件生命周期，调整文件结构。
  
  - 2020-01-14 ： 发布v2.9.8.0, 优化引擎锁。
  
  - 2020-02-05 ： 发布v2.9.10.0, 修复字段保护级别反解，增加栈上类型反解。
    
  - 2020-02-15 ： 发布v2.10.0.0, 增加警告编译日志（默认关闭），增加全局详细日志控制字段 UseDetailLog, 日志操作的命名空间改为system, 类型反解器添加命名空间，修改 CS0104 BUG。
  
  - 2020-03-05 ： 发布v2.10.2.0, 修复一处方法反解器的 BUG ,暂不解析 new 关键字。 
  
 <br/>  
 
 
 ### 升级日志
 
 - [[2019]](https://github.com/dotnetcore/Natasha/blob/master/docs/zh/update/2019.md)
 - [[2020]](https://github.com/dotnetcore/Natasha/blob/master/docs/zh/update/2020.md)
 <br/>  
 
 

 ### 生态微信群  
 
为防止广告骚扰，微信群已关闭，进群请发送您的微信号到 2765968624@qq.com 并说明进群原因。
 
 
  <br/>  
 
---------------------  


### 使用方法(User Api)：  

 <br/>  

 > 更多更新的参考文档：https://natasha.dotnetcore.xyz/  

<br/>    

 
#### 首先编辑您的工程文件：

```C#

  <PropertyGroup>
  
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    
    //控制台/桌面如下
    <PreserveCompilationContext>true</PreserveCompilationContext>
    
    //老版WEB需要
    <MvcRazorExcludeRefAssembliesFromPublish>false</MvcRazorExcludeRefAssembliesFromPublish>
    
    //3.1 新版WEB要加
    <PreserveCompilationReferences>true</PreserveCompilationReferences>
    //3.1 如果不加上面节点也可以引用Razor的编译服务
    Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    
    //如果你觉得发布文件夹下关于本地化的文件夹太多，您可以选择如下节点
    //选项：cs / de / es / fr / it / ja / ko / pl / ru / tr / zh-Hans / zh-Hant
    <SatelliteResourceLanguages>en</SatelliteResourceLanguages>
    
  </PropertyGroup>
 
```  

<br/>
<br/>  

  #### Natasha的动态调用模块:  已移至[【NCaller】](https://github.com/night-moon-studio/NCaller)
  #### Natasha的动态克隆模块:  已移至[【DeepClone】](https://github.com/night-moon-studio/DeepClone)  
  #### 查找树算法:  [【BTFindTreee】](https://github.com/dotnet-lab/BTFindTreee)  
  #### 快速动态缓存:  [【DynamicCache】](https://github.com/night-moon-studio/DynamicCache)  
  
<br/>
<br/>    


---------------------  


## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fdotnetcore%2FNatasha.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fdotnetcore%2FNatasha?ref=badge_large)          
      
## 依赖（Dependence）

 - Microsoft.CodeAnalysis.CSharp.Workspaces Version=3.4.0
 - Microsoft.Extensions.DependencyModel Version=3.1.0
 - Microsoft.Net.Compilers Version=3.4.0
 - Microsoft.Net.Compilers.Toolset Version=3.4.0
     
