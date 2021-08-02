using System;
using UnityEngine;
#if !NOT_UNITY
using ETCold;
#endif
namespace ET
{
    [UIEvent(UIType.UILobby)]
    public class UILobbyEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            await ETTask.CompletedTask;
            //ResourcesComponent.Instance.LoadBundle(UIType.UILobby.StringToAB());
            //GameObject bundleGameObject = (GameObject) ResourcesComponent.Instance.GetAsset(UIType.UILobby.StringToAB(), UIType.UILobby);
            var path = ABPathHelper.GetUGUIPath(UIType.UILobby);
            var bundleGameObject = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
            UI ui = EntityFactory.CreateWithParent<UI, string, GameObject>(uiComponent, UIType.UILobby, gameObject);

            ui.AddComponent<UILobbyComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            var path = ABPathHelper.GetUGUIPath(UIType.UILobby);
            ResourcesComponent.Instance.UnLoadAsset(path);
            //ResourcesComponent.Instance.UnloadBundle(UIType.UILobby.StringToAB());
        }
    }
}