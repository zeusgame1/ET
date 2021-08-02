using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using UnityEngine;

namespace ETCold
{
    public static class MonoHelper
    {
        public static List<Type> Types => types;


        static List<Type> types = new List<Type>();

        static Dictionary<string, string> loadDic = new Dictionary<string, string>()
         {
             {"Model.dll","Model.pdb"},
             {"Hotfix.dll","Hotfix.pdb"},
             {"ModelView.dll","ModelView.pdb"},
             {"HotfixView.dll","HotfixView.pdb"},
         };

        public static void StartHotfix()
        {
            Debug.Log($"当前Mono模式");
            MonoStaticMethod start = null;
            foreach (var item in loadDic)
            {
                if (HotfixHelper.SkipDlls.Contains(item.Key))
                {
                    continue;
                }
              
                byte[] assBytes = LoadHelper.LoadCode(item.Key).bytes;
                byte[] pdbBytes = LoadHelper.LoadCode(item.Value).bytes;
                var assembly = Assembly.Load(assBytes, pdbBytes);
                types.AddRange(assembly.GetTypes());
                Type initType = assembly.GetType("ET.Init");
                if (initType != null)
                {
                    start = new MonoStaticMethod(initType, "Start");
                }
            }


            //byte[] assBytes = LoadHelper.LoadCode("Sripte.dll").bytes;
            //byte[] pdbBytes = LoadHelper.LoadCode("Sripte.pdb").bytes;
            //var assembly = Assembly.Load(assBytes, pdbBytes);
            //types.AddRange(assembly.GetTypes());
            //Type initType = assembly.GetType("ET.Init");
            //if (initType != null)
            //{
            //    start = new MonoStaticMethod(initType, "Start");
            //}
            if (start == null)
            {
                Debug.LogError("找不到入口");
                return;
            }
            start.Run();
        }
    }
}