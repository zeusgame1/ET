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
    unsafe class ETCold_GameLoop_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETCold.GameLoop);

            field = type.GetField("onUpdate", flag);
            app.RegisterCLRFieldGetter(field, get_onUpdate_0);
            app.RegisterCLRFieldSetter(field, set_onUpdate_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_onUpdate_0, AssignFromStack_onUpdate_0);
            field = type.GetField("onLateUpdate", flag);
            app.RegisterCLRFieldGetter(field, get_onLateUpdate_1);
            app.RegisterCLRFieldSetter(field, set_onLateUpdate_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_onLateUpdate_1, AssignFromStack_onLateUpdate_1);
            field = type.GetField("onApplicationQuit", flag);
            app.RegisterCLRFieldGetter(field, get_onApplicationQuit_2);
            app.RegisterCLRFieldSetter(field, set_onApplicationQuit_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_onApplicationQuit_2, AssignFromStack_onApplicationQuit_2);


        }



        static object get_onUpdate_0(ref object o)
        {
            return ETCold.GameLoop.onUpdate;
        }

        static StackObject* CopyToStack_onUpdate_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETCold.GameLoop.onUpdate;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_onUpdate_0(ref object o, object v)
        {
            ETCold.GameLoop.onUpdate = (System.Action)v;
        }

        static StackObject* AssignFromStack_onUpdate_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @onUpdate = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ETCold.GameLoop.onUpdate = @onUpdate;
            return ptr_of_this_method;
        }

        static object get_onLateUpdate_1(ref object o)
        {
            return ETCold.GameLoop.onLateUpdate;
        }

        static StackObject* CopyToStack_onLateUpdate_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETCold.GameLoop.onLateUpdate;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_onLateUpdate_1(ref object o, object v)
        {
            ETCold.GameLoop.onLateUpdate = (System.Action)v;
        }

        static StackObject* AssignFromStack_onLateUpdate_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @onLateUpdate = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ETCold.GameLoop.onLateUpdate = @onLateUpdate;
            return ptr_of_this_method;
        }

        static object get_onApplicationQuit_2(ref object o)
        {
            return ETCold.GameLoop.onApplicationQuit;
        }

        static StackObject* CopyToStack_onApplicationQuit_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ETCold.GameLoop.onApplicationQuit;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_onApplicationQuit_2(ref object o, object v)
        {
            ETCold.GameLoop.onApplicationQuit = (System.Action)v;
        }

        static StackObject* AssignFromStack_onApplicationQuit_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @onApplicationQuit = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ETCold.GameLoop.onApplicationQuit = @onApplicationQuit;
            return ptr_of_this_method;
        }



    }
}
