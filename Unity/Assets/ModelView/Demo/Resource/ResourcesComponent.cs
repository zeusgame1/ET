using libx;
using UnityEngine;
using ETCold;

namespace ET
{
    [ObjectSystem]
    public class ResourcesComponentAwakeSystem : AwakeSystem<ResourcesComponent>
    {
        public override void Awake(ResourcesComponent self)
        {
            self.Awake();
        }
    }
    public class ResourcesComponent : Entity
    {

        public static ResourcesComponent Instance { get; set; }

        public void Awake()
        {
            Instance = this;


        }
        #region Assets

        /// <summary>
        /// 加载资源，path需要是全路径
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            AssetRequest assetRequest = Assets.LoadAsset(path, typeof(T));
            return (T)assetRequest.asset;
        }

        /// <summary>
        /// 异步加载资源，path需要是全路径
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ETTask<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
        {

            var tcs = ETTask<T>.Create();
            AssetRequest assetRequest = Assets.LoadAssetAsync(path, typeof(T));

            //如果已经加载完成则直接返回结果（适用于编辑器模式下的异步写法和重复加载）,下面的API如果有需求可按照此格式添加相关代码
            if (assetRequest.isDone)
            {
                tcs.SetResult((T)assetRequest.asset);
                return tcs;
            }

            //+=委托链，否则会导致前面完成委托被覆盖
            assetRequest.completed += (arq) => { tcs.SetResult((T)arq.asset); };
            return tcs;
        }

        /// <summary>
        /// 卸载资源，path需要是全路径
        /// </summary>
        /// <param name="path"></param>
        public void UnLoadAsset(string path)
        {
            //Assets.UnloadAsset(path);
        }

        #endregion

        #region Scenes

        /// <summary>
        /// 加载场景，path需要是全路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ETTask<SceneAssetRequest> LoadSceneAsync(string path)
        {
            ETTask<SceneAssetRequest> tcs = ETTask<SceneAssetRequest>.Create();
            SceneAssetRequest sceneAssetRequest = Assets.LoadSceneAsync(path, false);
            sceneAssetRequest.completed = (arq) =>
            {
                tcs.SetResult(sceneAssetRequest);
            };
            return tcs;
        }

        /// <summary>
        /// 卸载场景，path需要是全路径
        /// </summary>
        /// <param name="path"></param>
        public void UnLoadScene(string path)
        {
            // Assets.UnloadScene(path);
        }

        #endregion
    }
}