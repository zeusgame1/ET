namespace ET
{
    [Event]
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<UIComponent>();

            zoneScene.AddComponent<FUIComponent>();
            zoneScene.AddComponent<FUIPackageComponent>();
            zoneScene.AddComponent<FUIScalerComponent>();
            await zoneScene.AddComponent<FUIInitComponent>().Init();
            await ETTask.CompletedTask;
        }
    }
}