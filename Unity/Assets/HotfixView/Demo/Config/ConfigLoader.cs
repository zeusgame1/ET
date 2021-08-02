using System.Collections.Generic;
using UnityEngine;
#if !NOT_UNITY
using ETCold;
#endif
namespace ET
{
    public class ConfigLoader: IConfigLoader
    {
        public void GetAllConfigBytes(Dictionary<string, byte[]> output)
        {
            // Dictionary<string, UnityEngine.Object> keys = ResourcesComponent.Instance.GetBundleAll("config.unity3d");

            var types = Game.EventSystem.GetTypes(typeof(ConfigAttribute));

            foreach (var kv in types)
            {
                var path = ABPathHelper.GetConfigPath(kv.Name);
                
                output[kv.Name] = ResourcesComponent.Instance.LoadAsset<TextAsset>(path).bytes;
            }
        }

        public byte[] GetOneConfigBytes(string configName)
        {
            var path = ABPathHelper.GetConfigPath(configName);

            var v = ResourcesComponent.Instance.LoadAsset<TextAsset>(path);
            return v.bytes;
        }
    }
}