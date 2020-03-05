﻿using Natasha.Reverser.Model;
using System;
using System.Reflection;
using System.Text;
using System.Runtime.CompilerServices;

namespace Natasha.Reverser
{
    /// <summary>
    /// 修饰符反解
    /// </summary>
    public static class ModifierReverser
    {
        /// <summary>
        /// 根据修饰符枚举，获取修饰符
        /// </summary>
        /// <param name="enumModifier">修饰符枚举</param>
        /// <returns></returns>
        public static string GetModifier(Modifiers enumModifier)
        {
            switch (enumModifier)
            {
                case Modifiers.Static:
                    return "static ";
                case Modifiers.Virtual:
                    return "virtual ";
                case Modifiers.New:
                    return "new ";
                case Modifiers.Abstract:
                    return "abstract ";
                case Modifiers.Override:
                    return "override ";
                default:
                    return "";
            }
        }




        /// <summary>
        /// 获取方法的修饰符
        /// </summary>
        /// <param name="reflectMethodInfo">方法反射信息</param>
        /// <returns></returns>
        public static string GetModifier(MethodInfo reflectMethodInfo)
        {
            //此段代码由工良提供
            if (reflectMethodInfo.IsStatic)
            {
                return "static ";
            }
            // 没有相应的信息，说明没有使用以上关键字修饰
            if (!reflectMethodInfo.IsHideBySig)
                return default;

            // 是否抽象方法
            if (reflectMethodInfo.IsAbstract)
                return "abstract ";

            // virtual、override、实现接口的方法
            if (reflectMethodInfo.IsVirtual)
            {
                // 实现接口的方法
                if (reflectMethodInfo.IsFinal)
                    return default;
                // 没有被重写，则为 virtual
                if (reflectMethodInfo.Equals(reflectMethodInfo.GetBaseDefinition()))
                    return "virtual ";
                else
                    return "override ";
            }
            return default;

        }




        /// <summary>
        /// 获取字段的修饰符
        /// </summary>
        /// <param name="reflectFieldInfo">字段反射信息</param>
        /// <returns></returns>
        public static string GetModifier(FieldInfo reflectFieldInfo)
        {

            if (reflectFieldInfo.IsStatic)
            {

                return "static ";

            }


            if (reflectFieldInfo.IsInitOnly)
            {

                return "readonly ";

            }


            return "";
        }




        /// <summary>
        /// 获取类型的修饰符信息
        /// </summary>
        /// <param name="info">类型</param>
        /// <returns></returns>
        public static string GetModifier(Type info)
        {

            StringBuilder builder = new StringBuilder();
            if (info.IsClass)
            {

                if (info.IsAbstract)
                {

                    if (info.IsSealed)
                    {
                        builder.Append("static ");
                    }
                    else
                    {
                        builder.Append("abstract ");
                    }

                }
                else if (info.IsSealed)
                {
                    builder.Append("sealed ");
                }

            }

#if !NETSTANDARD2_0
            else if (info.IsValueType)
            {

                if (!info.IsEnum)
                {

                    if (info.GetCustomAttribute<IsReadOnlyAttribute>()!=default)
                    {
                        builder.Append("readonly ");
                    }
                    if (info.IsByRefLike)
                    {
                        builder.Append("ref ");
                    }

                }

            }
#endif


            return builder.ToString();
        }

    }

}
