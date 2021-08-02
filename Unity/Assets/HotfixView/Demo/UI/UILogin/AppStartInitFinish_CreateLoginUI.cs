

namespace ET
{
	[Event]
	public class AppStartInitFinish_CreateLoginUI : AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			await ETTask.CompletedTask;// UIHelper.Create(args.ZoneScene, UIType.UILogin);
		}
	}
}
