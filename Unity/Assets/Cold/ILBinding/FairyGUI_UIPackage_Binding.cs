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
    unsafe class FairyGUI_UIPackage_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(FairyGUI.UIPackage);
            args = new Type[]{typeof(System.String), typeof(System.String)};
            method = type.GetMethod("CreateObject", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CreateObject_0);
            args = new Type[]{typeof(System.String), typeof(System.String), typeof(FairyGUI.UIPackage.CreateObjectCallback)};
            method = type.GetMethod("CreateObjectAsync", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, CreateObjectAsync_1);
            args = new Type[]{};
            method = type.GetMethod("get_name", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_name_2);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("GetByName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetByName_3);
            args = new Type[]{};
            method = type.GetMethod("GetItemsArray", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, GetItemsArray_4);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("RemovePackage", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RemovePackage_5);
            args = new Type[]{typeof(System.Byte[]), typeof(System.String), typeof(FairyGUI.UIPackage.LoadResourceAsync)};
            method = type.GetMethod("AddPackageAsync", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddPackageAsync_6);
            args = new Type[]{typeof(FairyGUI.PackageItem), typeof(System.Object), typeof(FairyGUI.DestroyMethod)};
            method = type.GetMethod("SetItemAsset", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetItemAsset_7);

            field = type.GetField("unloadBundleByFGUI", flag);
            app.RegisterCLRFieldGetter(field, get_unloadBundleByFGUI_0);
            app.RegisterCLRFieldSetter(field, set_unloadBundleByFGUI_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_unloadBundleByFGUI_0, AssignFromStack_unloadBundleByFGUI_0);


        }


        static StackObject* CreateObject_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @resName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @pkgName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = FairyGUI.UIPackage.CreateObject(@pkgName, @resName);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* CreateObjectAsync_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.UIPackage.CreateObjectCallback @callback = (FairyGUI.UIPackage.CreateObjectCallback)typeof(FairyGUI.UIPackage.CreateObjectCallback).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @resName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @pkgName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            FairyGUI.UIPackage.CreateObjectAsync(@pkgName, @resName, @callback);

            return __ret;
        }

        static StackObject* get_name_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.UIPackage instance_of_this_method = (FairyGUI.UIPackage)typeof(FairyGUI.UIPackage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.name;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetByName_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @name = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = FairyGUI.UIPackage.GetByName(@name);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetItemsArray_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.UIPackage instance_of_this_method = (FairyGUI.UIPackage)typeof(FairyGUI.UIPackage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetItemsArray();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* RemovePackage_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @packageIdOrName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            FairyGUI.UIPackage.RemovePackage(@packageIdOrName);

            return __ret;
        }

        static StackObject* AddPackageAsync_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.UIPackage.LoadResourceAsync @loadFunc = (FairyGUI.UIPackage.LoadResourceAsync)typeof(FairyGUI.UIPackage.LoadResourceAsync).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @assetNamePrefix = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Byte[] @descData = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = FairyGUI.UIPackage.AddPackageAsync(@descData, @assetNamePrefix, @loadFunc);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SetItemAsset_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            FairyGUI.DestroyMethod @destroyMethod = (FairyGUI.DestroyMethod)typeof(FairyGUI.DestroyMethod).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Object @asset = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            FairyGUI.PackageItem @item = (FairyGUI.PackageItem)typeof(FairyGUI.PackageItem).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            FairyGUI.UIPackage instance_of_this_method = (FairyGUI.UIPackage)typeof(FairyGUI.UIPackage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetItemAsset(@item, @asset, @destroyMethod);

            return __ret;
        }


        static object get_unloadBundleByFGUI_0(ref object o)
        {
            return FairyGUI.UIPackage.unloadBundleByFGUI;
        }

        static StackObject* CopyToStack_unloadBundleByFGUI_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = FairyGUI.UIPackage.unloadBundleByFGUI;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_unloadBundleByFGUI_0(ref object o, object v)
        {
            FairyGUI.UIPackage.unloadBundleByFGUI = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_unloadBundleByFGUI_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @unloadBundleByFGUI = ptr_of_this_method->Value == 1;
            FairyGUI.UIPackage.unloadBundleByFGUI = @unloadBundleByFGUI;
            return ptr_of_this_method;
        }



    }
}
