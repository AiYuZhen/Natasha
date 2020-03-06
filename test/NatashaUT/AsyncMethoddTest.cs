﻿using Natasha;
using Natasha.Operator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NatashaUT
{

    [Trait("快速构建", "异步方法")]
    public class AsyncMethoddTest
    {
        [Fact(DisplayName = "手动强转异步委托1")]
        public static async void RunAsyncDelegate1()
        {
            var delegateAction = FastMethodOperator
                .Default()
                        .UseAsync()
                        .Param<string>("str1")
                        .Param<string>("str2")
                        .MethodBody(@"
                            string result = str1 +"" ""+ str2;
                            Console.WriteLine(result);
                            return result;")
                        .Return<Task<string>>()
                .Complie();

            string result =await ((Func<string, string, Task<string>>)delegateAction)?.Invoke("Hello", "World1!");
            Assert.Equal("Hello World1!", result);
        }




        [Fact(DisplayName = "手动强转异步委托2")]
        public static async void RunAsyncDelegate2()
        {
            var delegateAction = FastMethodOperator.Default()

                        .UseAsync()
                        .Param<string>("str1")
                        .Param<string>("str2")
                        .MethodBody(@"
                            await Task.Delay(1000);
                            string result = str1 +"" ""+ str2;
                            Console.WriteLine(result);
                            return result;")
                        .Return<Task<string>>()

                .Complie();

            string result = await ((Func<string, string, Task<string>>)delegateAction)?.Invoke("Hello", "World1!");
            Assert.Equal("Hello World1!", result);
        }




        [Fact(DisplayName = "NDomain - AsyncFunc异步委托")]
        public static async void RunAsyncDelegate5()
        {
            var action = NDomain.Random().AsyncFunc<string, string, Task<string>>(@"
                            string result = arg1 +"" ""+ arg2;
                            Console.WriteLine(result);
                            return result;");

            string result = await action("Hello", "World1!");
            Assert.Equal("Hello World1!", result);
        }




        [Fact(DisplayName = "NDomain - UnsafeAsyncFunc非安全异步委托")]
        public static async void RunAsyncDelegate6()
        {
            var action = NDomain.Random().UnsafeAsyncFunc<string, string, Task<string>>(@"
                            string result = arg1 +"" ""+ arg2;
                            Console.WriteLine(result);
                            return result;");

            string result = await action("Hello", "World1!");
            Assert.Equal("Hello World1!", result);
        }




        [Fact(DisplayName = "自动泛型异步委托1")]
        public static async void RunAsyncDelegate3()
        {

            var delegateAction = NewMethod.Create<Func<string, string, Task<string>>>(builder => builder
                    .UseAsync()
                    .MethodBody(@"
                            string result = arg1 +"" ""+ arg2;
                            Console.WriteLine(result);
                            return result;")
                    );

            string result =await delegateAction.Method("Hello", "World2!");
            Assert.Equal("Hello World2!", result);


        }




        [Fact(DisplayName = "自动泛型异步委托2")]
        public static async void RunAsyncDelegate4()
        {
            var delegateAction = FastMethodOperator.Default()

                .UseAsync()
                .MethodBody(@"
                            await Task.Delay(100);
                            string result = arg1 +"" ""+ arg2;
                            Console.WriteLine(result);
                            return result;")

                .Complie<Func<string, string, Task<string>>>();

            string result = await delegateAction?.Invoke("Hello", "World2!");
            Assert.Equal("Hello World2!", result);
        }




        [Fact(DisplayName = "NDomain - Delegate自定义委托")]
        public static void RunDelegate8()
        {
            var action = NDomain.Random().Delegate<TestDelegate>(@"
                            return value.Length;");

            int result = action("Hello");
            Assert.Equal(5, result);
        }

    }

    public delegate int TestDelegate(string value);
}
