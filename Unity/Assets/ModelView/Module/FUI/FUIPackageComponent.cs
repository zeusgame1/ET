using ETCold;
using FairyGUI;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 管理所有UI Package
    /// </summary>
    public class FUIPackageComponent : Entity
    {
        private readonly Dictionary<string, UIPackage> packages = new Dictionary<string, UIPackage>();

        public async ETTask AddPackageAsync(string type)
        {
            if (this.packages.ContainsKey(type))
            {
                return;
            }

            TextAsset desTextAsset =
                    await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(ABPathHelper.GetFGUIDesPath($"{type}_fui"));

            packages.Add(type, UIPackage.AddPackageAsync(desTextAsset.bytes, type, LoadPackageInternalAsync));
        }

        /// <summary>
        /// 加载资源的异步委托
        /// </summary>
        /// <param name="name">注意，这个name是FGUI内部组装的纹理全名，例如FUILogin_atlas0</param>
        /// <param name="extension"></param>
        /// <param name="type"></param>
        /// <param name="item"></param>
        private static async void LoadPackageInternalAsync(string name, string extension, System.Type type, PackageItem item)
        {
            Texture texture =
                    await ResourcesComponent.Instance.LoadAssetAsync<Texture>(ABPathHelper.GetFGUIResPath(name, extension));
            item.owner.SetItemAsset(item, texture, DestroyMethod.Unload);
            Log.Debug(extension);
        }

        /// <summary>
        /// 移除一个包，并清理其asset
        /// </summary>
        /// <param name="type"></param>
        public void RemovePackage(string type)
        {
            if (ResourcesComponent.Instance == null) return;
            UIPackage package;

            if (packages.TryGetValue(type, out package))
            {
                var p = UIPackage.GetByName(package.name);
                if (p != null)

                {
                    var items = package.GetItemsArray();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].type == PackageItemType.Atlas)
                        {
                            ResourcesComponent.Instance.UnLoadAsset(ABPathHelper.GetFGUIAtlasResPath($"{items[i].file}"));
                        }

                    }

                    // ResourcesComponent.Instance.UnLoadAsset(ABPathHelper.GetFGUIResPath($"{type}_atlas0", ".png"));
                    ResourcesComponent.Instance.UnLoadAsset(ABPathHelper.GetFGUIDesPath($"{type}_fui"));
                    UIPackage.unloadBundleByFGUI = false;
                    UIPackage.RemovePackage(package.name);
                }

                packages.Remove(package.name);
            }
        }
    }
}