//#if ILRuntime
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public static class ILRuntimeCLRBinding
{
    static string BindingPath = "Assets/Cold/ILBinding";


    [MenuItem("Tools/ILRuntime/Generate CLR Binding Code")]
    static void GenerateCLRBinding()
    {
        List<Type> types = new List<Type>();
        types.Add(typeof(int));
        types.Add(typeof(float));
        types.Add(typeof(long));
        types.Add(typeof(object));
        types.Add(typeof(string));
        types.Add(typeof(Array));
        types.Add(typeof(Vector2));
        types.Add(typeof(Vector3));
        types.Add(typeof(Quaternion));
        types.Add(typeof(GameObject));
        types.Add(typeof(UnityEngine.Object));
        types.Add(typeof(Transform));
        types.Add(typeof(RectTransform));
        types.Add(typeof(Time));
        types.Add(typeof(Debug));
    
       
        //所有DLL内的类型的真实C#类型都是ILTypeInstance
        types.Add(typeof(List<ILRuntime.Runtime.Intepreter.ILTypeInstance>));

        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(types, BindingPath);
      
    }

    [MenuItem("Tools/ILRuntime/Generate CLR Binding Code by Analysis")]
    static void GenerateCLRBindingByAnalysis()
    {
        GenerateCLRBinding();
        //用新的分析热更dll调用引用来生成绑定代码
        ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();

        FileStream fs1 = new FileStream("Assets/Res/Code/Model.dll.bytes", FileMode.Open, FileAccess.Read);
       FileStream fs2 = new FileStream("Assets/Res/Code/ModelView.dll.bytes", FileMode.Open, FileAccess.Read);
       FileStream fs3 = new FileStream("Assets/Res/Code/Hotfix.dll.bytes", FileMode.Open, FileAccess.Read);
       FileStream fs4 = new FileStream("Assets/Res/Code/HotfixView.dll.bytes", FileMode.Open, FileAccess.Read);

        domain.LoadAssembly(fs1);
        domain.LoadAssembly(fs2);
        domain.LoadAssembly(fs3);
        domain.LoadAssembly(fs4);



        //Crossbind Adapter is needed to generate the correct binding code
        ETCold.ILHelper.InitILRuntime(domain);
        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, BindingPath);

        fs1.Close();
        fs2.Close();
        fs3.Close();
        fs4.Close();



        AssetDatabase.Refresh();
    }
}
//#endif