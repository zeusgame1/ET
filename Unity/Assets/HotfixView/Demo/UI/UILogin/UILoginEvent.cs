using System;
using UnityEngine;
#if !NOT_UNITY
using ETCold;
#endif
namespace ET
{
    [UIEvent(UIType.UILogin)]
    public class UILoginEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            //await ResourcesComponent.Instance.LoadBundleAsync(UIType.UILogin.StringToAB());
            //GameObject bundleGameObject = (GameObject) ResourcesComponent.Instance.GetAsset(UIType.UILogin.StringToAB(), UIType.UILogin);

            var path = ABPathHelper.GetUGUIPath(UIType.UILogin);
            var bundleGameObject = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);

            UI ui = EntityFactory.CreateWithParent<UI, string, GameObject>(uiComponent, UIType.UILogin, gameObject);

            ui.AddComponent<UILoginComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            //ResourcesComponent.Instance.UnloadBundle(UIType.UILogin.StringToAB());

            var path = ABPathHelper.GetUGUIPath(UIType.UILobby);

            ResourcesComponent.Instance.UnLoadAsset(path);
        }
    }
}