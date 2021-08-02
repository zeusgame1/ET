//
// AssetsMenuItem.cs
//
// Author:
//       fjy <jiyuan.feng@live.com>
//
// Copyright (c) 2020 fjy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace libx
{
    public static class MenuItems
    {
        private const string KBuildAssetBundles = "ET/XAsset/Bundles/Build Bundles %#&B";
        private const string KCopyAssetBundles = "ET/XAsset/Bundles/Copy Bundles to Streaming Assets (Suggest for iOS review)";
        private const string KViewCachePath = "ET/XAsset/View/Caches";
        private const string KViewDataPath = "ET/XAsset/View/Built Bundles";
        private const string KCleanData = "ET/XAsset/Bundles/Clean Built Bundles";

        //[MenuItem("ET/build")]

        //static void Ax()
        //{
        //    BuildScript.BuildAssetBundles();
        //}
        [MenuItem(KBuildAssetBundles)]
        public static void BuildAssetBundles()
        {

         
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

        [MenuItem(KCleanData)]
        private static void CleanBundles()
        {
            var watch = new Stopwatch();
            watch.Start();
            ET.FileHelper.CleanDirectory(Directory.GetParent(Application.dataPath) + "/../Release/DLC");
            //  DLLMgr.Delete(Directory.GetParent(Application.dataPath) + "/DLC");
            watch.Stop();
            ET.Log.Debug("Clean bundles in: " + watch.ElapsedMilliseconds + " ms.");
        }


        [MenuItem(KViewDataPath)]
        private static void ViewDataPath()
        {
            if (Directory.Exists(Directory.GetParent(Application.dataPath).FullName + "/../Release/DLC"))
            {
                EditorUtility.OpenWithDefaultApp(Directory.GetParent(Application.dataPath).FullName + "/../Release/DLC");
            }
            else
            {
                ET.Log.Error("Unable to View Bundles: Please Build Bundles First");
            }
        }

        [MenuItem(KViewCachePath)]
        private static void ViewCachePath()
        {
            EditorUtility.OpenWithDefaultApp(Application.persistentDataPath);
        }

        [MenuItem(KCopyAssetBundles)]
        private static void CopyAssetBundles()
        {
            BuildScript.CopyAssetBundlesTo(Application.streamingAssetsPath);
        }

        #region Tools 
        [MenuItem("ET/XAsset/Tools/View CRC")]
        private static void GetCRC()
        {
            var path = EditorUtility.OpenFilePanel("OpenFile", Environment.CurrentDirectory, "");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            using (var fs = File.OpenRead(path))
            {
                var crc = Utility.GetCRC32Hash(fs);
                ET.Log.Debug(crc);
            }
        }

        [MenuItem("ET/XAsset/Tools/View MD5")]
        private static void GetMD5()
        {
            var path = EditorUtility.OpenFilePanel("OpenFile", Environment.CurrentDirectory, "");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            using (var fs = File.OpenRead(path))
            {
                var crc = Utility.GetMD5Hash(fs);
                ET.Log.Debug(crc);
            }
        }
        #endregion 
    }
}