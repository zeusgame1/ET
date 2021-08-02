using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class System_Net_NetworkInformation_NetworkInterface_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(System.Net.NetworkInformation.NetworkInterface);
            args = new Type[]{};
            method = type.GetMethod("GetAllNetworkInterfaces", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetAllNetworkInterfaces_0);
            args = new Type[]{};
            method = type.GetMethod("get_NetworkInterfaceType", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_NetworkInterfaceType_1);
            args = new Type[]{};
            method = type.GetMethod("GetIPProperties", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetIPProperties_2);


        }


        static StackObject* GetAllNetworkInterfaces_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_NetworkInterfaceType_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Net.NetworkInformation.NetworkInterface instance_of_this_method = (System.Net.NetworkInformation.NetworkInterface)typeof(System.Net.NetworkInformation.NetworkInterface).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.NetworkInterfaceType;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetIPProperties_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Net.NetworkInformation.NetworkInterface instance_of_this_method = (System.Net.NetworkInformation.NetworkInterface)typeof(System.Net.NetworkInformation.NetworkInterface).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetIPProperties();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
