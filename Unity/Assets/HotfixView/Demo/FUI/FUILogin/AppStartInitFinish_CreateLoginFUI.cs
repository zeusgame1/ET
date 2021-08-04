

namespace ET
{


    public class AppStartInitFinish_CreateLoginFUI : AEvent<EventType.AppStartInitFinish>
    {
        protected override async ETTask Run(EventType.AppStartInitFinish args)
        {

            var fui = await FUILogin.CreateInstanceAsync(args.ZoneScene);
            fui.Name = FUILogin.UIResName;
            fui.AddComponent<FUILoginComponent>();
            args.ZoneScene.GetComponent<FUIComponent>().Add(fui, true);
            args.ZoneScene.GetComponent<FUIScalerComponent>().Register(fui.GObject, AdaptedType.ScaleFullScreen);
        
        }
    }
}
