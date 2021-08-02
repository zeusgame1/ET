﻿#if !NOT_UNITY
using ETCold;
#endif
namespace ET
{
	[Event]
	public class EnterMapFinish_RemoveLobbyUI: AEvent<EventType.EnterMapFinish>
	{
		protected override async ETTask Run(EventType.EnterMapFinish args)
		{
			// 加载场景资源
			//await ResourcesComponent.Instance.LoadBundleAsync("map.unity3d");
			//// 切换到map场景
			//using (SceneChangeComponent sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>())
			//{
			//	await sceneChangeComponent.ChangeSceneAsync("Map");
			//}
			var path = ABPathHelper.GetScenePath("Map");
			var rs = await ResourcesComponent.Instance.LoadSceneAsync(path);
			args.ZoneScene.AddComponent<OperaComponent>();
            await UIHelper.Remove(args.ZoneScene, UIType.UILobby);
		}
	}
}
