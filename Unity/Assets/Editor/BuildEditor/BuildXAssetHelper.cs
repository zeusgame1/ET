using libx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
   public static class BuildXAssetHelper
    {

        public static void Start(UnityEditor.BuildTarget target)
        {
            BuildScript.SetBuildTarget(target);

            var watch = new Stopwatch();
            watch.Start();
            BuildScript.ApplyBuildRules();
            watch.Stop();
            ET.Log.Error("ApplyBuildRules in: " + watch.ElapsedMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            BuildScript.BuildAssetBundles();
            watch.Stop();
            ET.Log.Error("BuildAssetBundles in: " + watch.ElapsedMilliseconds + " ms.");
        }
    }
}
