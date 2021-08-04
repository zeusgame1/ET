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
    unsafe class FairyGUI_PackageItem_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.PackageItem);

            field = type.GetField("type", flag);
            app.RegisterCLRFieldGetter(field, get_type_0);
            app.RegisterCLRFieldSetter(field, set_type_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_type_0, AssignFromStack_type_0);
            field = type.GetField("file", flag);
            app.RegisterCLRFieldGetter(field, get_file_1);
            app.RegisterCLRFieldSetter(field, set_file_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_file_1, AssignFromStack_file_1);
            field = type.GetField("owner", flag);
            app.RegisterCLRFieldGetter(field, get_owner_2);
            app.RegisterCLRFieldSetter(field, set_owner_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_owner_2, AssignFromStack_owner_2);


        }



        static object get_type_0(ref object o)
        {
            return ((FairyGUI.PackageItem)o).type;
        }

        static StackObject* CopyToStack_type_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((FairyGUI.PackageItem)o).type;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_type_0(ref object o, object v)
        {
            ((FairyGUI.PackageItem)o).type = (FairyGUI.PackageItemType)v;
        }

        static StackObject* AssignFromStack_type_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            FairyGUI.PackageItemType @type = (FairyGUI.PackageItemType)typeof(FairyGUI.PackageItemType).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((FairyGUI.PackageItem)o).type = @type;
            return ptr_of_this_method;
        }

        static object get_file_1(ref object o)
        {
            return ((FairyGUI.PackageItem)o).file;
        }

        static StackObject* CopyToStack_file_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((FairyGUI.PackageItem)o).file;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_file_1(ref object o, object v)
        {
            ((FairyGUI.PackageItem)o).file = (System.String)v;
        }

        static StackObject* AssignFromStack_file_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.String @file = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((FairyGUI.PackageItem)o).file = @file;
            return ptr_of_this_method;
        }

        static object get_owner_2(ref object o)
        {
            return ((FairyGUI.PackageItem)o).owner;
        }

        static StackObject* CopyToStack_owner_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((FairyGUI.PackageItem)o).owner;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_owner_2(ref object o, object v)
        {
            ((FairyGUI.PackageItem)o).owner = (FairyGUI.UIPackage)v;
        }

        static StackObject* AssignFromStack_owner_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            FairyGUI.UIPackage @owner = (FairyGUI.UIPackage)typeof(FairyGUI.UIPackage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((FairyGUI.PackageItem)o).owner = @owner;
            return ptr_of_this_method;
        }



    }
}
