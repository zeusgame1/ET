using System;

namespace ETCold
{
	public  class GameLoop
	{
		public static Action onStart;
		public static Action onEnable;
		public static Action onDisable;
		public static Action onUpdate;
		public static Action onFixedUpdate;
		public static Action onLateUpdate;
		public static Action onDestroy;
		public static Action<bool> onApplicationFocus;
		public static Action<bool> onApplicationPause;
		public static Action onApplicationQuit;
	}
}
