/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
	[ObjectSystem]
    public class FUILoginStartButtonAwakeSystem : AwakeSystem<FUILoginStartButton, GObject>
    {
        public override void Awake(FUILoginStartButton self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUILoginStartButton : FUI
	{	
		public const string UIPackageName = "ModelView";
		public const string UIResName = "LoginStartButton";
		
		
		public const string URL = "ui://n5i3k4bjgwhc1l";
		/// <summary>
        /// LoginStartButton的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GButton self;
		
		/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUILoginStartButton CreateInstance(Entity domain)
		{			
			return EntityFactory.Create<FUILoginStartButton, GObject>(domain, CreateGObject());
		}

        public static ETTask<FUILoginStartButton> CreateInstanceAsync(Entity domain)
        {
            ETTask<FUILoginStartButton> tcs = ETTask<FUILoginStartButton>.Create();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(EntityFactory.Create<FUILoginStartButton, GObject>(domain, go));
            });

            return tcs;
        }

        public static FUILoginStartButton Create(Entity domain, GObject go)
		{
			return EntityFactory.Create<FUILoginStartButton, GObject>(domain, go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUILoginStartButton GetFormPool(Entity domain, GObject go)
        {
            var fui = go.Get<FUILoginStartButton>();

            if(fui == null)
            {
                fui = Create(domain, go);
            }

            fui.isFromFGUIPool = true;

            return fui;
        }
						
		public void Awake(GObject go)
		{
			if(go == null)
			{
				return;
			}
			
			GObject = go;	
			
			if (string.IsNullOrWhiteSpace(Name))
            {
				Name = Id.ToString();
            }
			
			self = (GButton)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				 /** This is an automatically generated class by FairyGUI. Please do not modify it. **/

				m_button = com.GetController("button");
				m_n0 = (GImage)com.GetChild("n0");
				m_n1 = (GImage)com.GetChild("n1");
				m_n2 = (GImage)com.GetChild("n2");
			}
		}
		
		public override void Dispose()
		{
			if(IsDisposed)
			{
				return;
			}
			
			base.Dispose();
			
			self.Remove();
			self = null;
			/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

			m_button = null;
			m_n0 = null;
			m_n1 = null;
			m_n2 = null;
		}
	}
}