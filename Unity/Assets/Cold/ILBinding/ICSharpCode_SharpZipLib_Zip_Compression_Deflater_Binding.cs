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
    unsafe class ICSharpCode_SharpZipLib_Zip_Compression_Deflater_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater);
            args = new Type[]{typeof(System.Int32)};
            method = type.GetMethod("SetLevel", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetLevel_0);
            args = new Type[]{typeof(System.Byte[])};
            method = type.GetMethod("SetInput", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetInput_1);
            args = new Type[]{};
            method = type.GetMethod("Finish", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Finish_2);
            args = new Type[]{typeof(System.Byte[])};
            method = type.GetMethod("Deflate", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Deflate_3);
            args = new Type[]{};
            method = type.GetMethod("get_IsFinished", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_IsFinished_4);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* SetLevel_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @level = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater instance_of_this_method = (ICSharpCode.SharpZipLib.Zip.Compression.Deflater)typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetLevel(@level);

            return __ret;
        }

        static StackObject* SetInput_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @input = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater instance_of_this_method = (ICSharpCode.SharpZipLib.Zip.Compression.Deflater)typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetInput(@input);

            return __ret;
        }

        static StackObject* Finish_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater instance_of_this_method = (ICSharpCode.SharpZipLib.Zip.Compression.Deflater)typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Finish();

            return __ret;
        }

        static StackObject* Deflate_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Byte[] @output = (System.Byte[])typeof(System.Byte[]).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater instance_of_this_method = (ICSharpCode.SharpZipLib.Zip.Compression.Deflater)typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Deflate(@output);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static StackObject* get_IsFinished_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater instance_of_this_method = (ICSharpCode.SharpZipLib.Zip.Compression.Deflater)typeof(ICSharpCode.SharpZipLib.Zip.Compression.Deflater).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsFinished;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new ICSharpCode.SharpZipLib.Zip.Compression.Deflater();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
