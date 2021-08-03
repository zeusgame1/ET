using ILRuntime.CLR.Method;
using ILRuntime.CLR.Utils;
using ILRuntime.Runtime.Enviorment;
//using ILRuntime.Runtime.Generated;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;

using UnityEngine;

namespace ETCold
{
    public static class ILHelper
    {
        public static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
#if DEBUG && !NO_PROFILER
            appdomain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
#endif

#if UNITY_EDITOR
            appdomain.DebugService.StartDebugService(56000);
#endif
            //跨域继承
            RegisterCrossBindingAdaptor(appdomain);

            //重定向
            RegisterILRuntimeCLRRedirection(appdomain);

            //委托
            RegisterMethodDelegate(appdomain);
            RegisterFunctionDelegate(appdomain);
            RegisterDelegateConvertor(appdomain);

            ////////////////////////////////////
            // CLR绑定的注册，一定要记得将CLR绑定的注册写在CLR重定向的注册后面，因为同一个方法只能被重定向一次，只有先注册的那个才能生效
            ////////////////////////////////////
            Type t = Type.GetType("ILRuntime.Runtime.Generated.CLRBindings");
            if (t != null)
            {
                t.GetMethod("Initialize")?.Invoke(null, new object[] { appdomain });
            }
        }


        ///跨域继承适配
        public static void RegisterCrossBindingAdaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            Assembly assembly = typeof(ILHelper).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                object[] attrs = type.GetCustomAttributes(typeof(ILAdapterAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }
                object obj = Activator.CreateInstance(type);
                CrossBindingAdaptor adaptor = obj as CrossBindingAdaptor;
                if (adaptor == null)
                {
                    continue;
                }
                appdomain.RegisterCrossBindingAdaptor(adaptor);
            }
        }


        ///无返回值委托适配
        public static void RegisterMethodDelegate(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {


            appdomain.DelegateManager.RegisterMethodDelegate<List<object>>();

            appdomain.DelegateManager.RegisterMethodDelegate<object>();
            appdomain.DelegateManager.RegisterMethodDelegate<bool>();
            appdomain.DelegateManager.RegisterMethodDelegate<string>();
            appdomain.DelegateManager.RegisterMethodDelegate<float>();

            appdomain.DelegateManager.RegisterMethodDelegate<long, int>();
            appdomain.DelegateManager.RegisterMethodDelegate<long, MemoryStream>();
            appdomain.DelegateManager.RegisterMethodDelegate<long, IPEndPoint>();

            appdomain.DelegateManager.RegisterMethodDelegate<libx.AssetRequest>();
			
			appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String, System.Type, FairyGUI.PackageItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<FairyGUI.GObject>();

        }
        ///带返回委托适配

        public static void RegisterFunctionDelegate(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Events.UnityAction>();

            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, ET.ETTask>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String>();            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>();            appdomain.DelegateManager.RegisterFunctionDelegate<List<int>, int>();
            appdomain.DelegateManager.RegisterFunctionDelegate<List<int>, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<int, bool>();//Linq
            appdomain.DelegateManager.RegisterFunctionDelegate<int, int, int>();//Linq
            appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, List<int>>, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, int>, KeyValuePair<int, int>, int>();
        }


        ///委托转换
        public static void RegisterDelegateConvertor(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((Action)act)();
                });
            });
            appdomain.DelegateManager.RegisterDelegateConvertor<Comparison<KeyValuePair<int, int>>>((act) =>
            {
                return new Comparison<KeyValuePair<int, int>>((x, y) =>
                {
                    return ((Func<KeyValuePair<int, int>, KeyValuePair<int, int>, int>)act)(x, y);
                });
            });
			appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.UIPackage.LoadResourceAsync>((act) =>
{
    return new FairyGUI.UIPackage.LoadResourceAsync((name, extension, type, item) =>
    {
        ((Action<System.String, System.String, System.Type, FairyGUI.PackageItem>)act)(name, extension, type, item);
    });
});

appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.UIPackage.CreateObjectCallback>((act) =>
{
    return new FairyGUI.UIPackage.CreateObjectCallback((result) =>
    {
        ((Action<FairyGUI.GObject>)act)(result);
    });
});
appdomain.DelegateManager.RegisterDelegateConvertor<FairyGUI.EventCallback0>((act) =>
{
    return new FairyGUI.EventCallback0(() =>
    {
        ((Action)act)();
    });
});

        }


        static unsafe void RegisterILRuntimeCLRRedirection(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            //注册3种Log
            Type debugType = typeof(Debug);
            var logMethod = debugType.GetMethod("Log", new[] { typeof(object) });
            appdomain.RegisterCLRMethodRedirection(logMethod, Log);
            var logWarningMethod = debugType.GetMethod("LogWarning", new[] { typeof(object) });
            appdomain.RegisterCLRMethodRedirection(logWarningMethod, LogWarning);
            var logErrorMethod = debugType.GetMethod("LogError", new[] { typeof(object) });
            appdomain.RegisterCLRMethodRedirection(logErrorMethod, LogError);

            //LitJson适配
            LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appdomain);
            //Protobuf适配
            ProtoBuf.PBType.RegisterILRuntimeCLRRedirection(appdomain);
        }






        /// <summary>
        /// Debug.LogError 实现
        /// </summary>
        /// <param name="__intp"></param>
        /// <param name="__esp"></param>
        /// <param name="__mStack"></param>
        /// <param name="__method"></param>
        /// <param name="isNewObj"></param>
        /// <returns></returns>
        unsafe static StackObject* LogError(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack,
        CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);

            object message = typeof(object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var stacktrace = __domain.DebugService.GetStackTrace(__intp);
            Debug.LogError(message + "\n\n==========ILRuntime StackTrace==========\n" + stacktrace);
            return __ret;
        }

        /// <summary>
        /// Debug.LogWarning 实现
        /// </summary>
        /// <param name="__intp"></param>
        /// <param name="__esp"></param>
        /// <param name="__mStack"></param>
        /// <param name="__method"></param>
        /// <param name="isNewObj"></param>
        /// <returns></returns>
        unsafe static StackObject* LogWarning(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack,
        CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);

            object message = typeof(object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var stacktrace = __domain.DebugService.GetStackTrace(__intp);
            Debug.LogWarning(message + "\n\n==========ILRuntime StackTrace==========\n" + stacktrace);
            return __ret;
        }

        /// <summary>
        /// Debug.Log 实现
        /// </summary>
        /// <param name="__intp"></param>
        /// <param name="__esp"></param>
        /// <param name="__mStack"></param>
        /// <param name="__method"></param>
        /// <param name="isNewObj"></param>
        /// <returns></returns>
        unsafe static StackObject* Log(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack,
        CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);

            object message = typeof(object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var stacktrace = __domain.DebugService.GetStackTrace(__intp);
            Debug.Log(message + "\n\n==========ILRuntime StackTrace==========\n" + stacktrace);
            return __ret;
        }


    }
}