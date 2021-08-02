

namespace ET
{
	public class LoginFinish_RemoveLoginFUI: AEvent<EventType.LoginFinish>
	{
		protected override async ETTask Run(EventType.LoginFinish args)
		{
			args.ZoneScene.GetComponent<FUIComponent>().Remove(FUILogin.UIResName);
			await ETTask.CompletedTask;
		}
	}
}
