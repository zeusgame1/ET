using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;

namespace ETCold
{
    public static class ILRuntimeHelper
    {

        static Dictionary<string, string> loadDic = new Dictionary<string, string>()
         {
             {"Model.dll","Model.pdb"},
             {"Hotfix.dll","Hotfix.pdb"},
             {"ModelView.dll","ModelView.pdb"},
             {"HotfixView.dll","HotfixView.pdb"},
         };

        static List<(MemoryStream code, MemoryStream pdb)> streamList = new List<(MemoryStream code, MemoryStream pdb)>();
        static ILRuntime.Runtime.Enviorment.AppDomain appDomain;

        static IStaticMethod start;

        static List<Type> types;

        public static List<Type> Types => types;


        public static void Start()
        {
            Debug.Log($"当前使用的是ILRuntime模式");
            appDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
            var reader = new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider();

            foreach (var item in loadDic)
            {
                if (HotfixHelper.SkipDlls.Contains(item.Key))
                {
                    continue;
                }
              
                byte[] assBytes = LoadHelper.LoadCode(item.Key).bytes;
                byte[] pdbBytes = LoadHelper.LoadCode(item.Value).bytes;
                var assStream = new MemoryStream(assBytes);
                var pdbStream = new MemoryStream(pdbBytes);


                streamList.Add((assStream, pdbStream));
            }

            foreach (var item in streamList)
            {
               
                appDomain.LoadAssembly(item.code, item.pdb, reader);
            }


            // byte[] assBytes = LoadHelper.LoadCode("Script.dll").bytes;
            // byte[] pdbBytes = LoadHelper.LoadCode("Script.pdb").bytes;

            // var assStream = new MemoryStream(assBytes);
            // var pdbStream = new MemoryStream(pdbBytes);
            // appDomain.LoadAssembly(assStream, pdbStream, reader);
         
            ILHelper.InitILRuntime(appDomain);
            start = new ILStaticMethod(appDomain, "ET.Init", "Start", 0);

            types = appDomain.LoadedTypes.Values.Select(x => x.ReflectionType).ToList();

          
            start.Run();
          
           
        }

        public static void Dispose()
        {

         //   appDomain.Dispose();
            appDomain = null;
            for (int i = 0; i < streamList.Count; i++)
            {

                streamList[i].code.Dispose();
                streamList[i].pdb.Dispose();
            }
            // libx.Assets.RemoveUnusedAssets();
          
        }
    }
}