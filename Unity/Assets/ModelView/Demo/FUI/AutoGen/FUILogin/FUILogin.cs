/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
	[ObjectSystem]
    public class FUILoginAwakeSystem : AwakeSystem<FUILogin, GObject>
    {
        public override void Awake(FUILogin self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUILogin : FUI
	{	
		public const string UIPackageName = "ModelView";
		public const string UIResName = "Login";
		
		
		public const string URL = "ui://n5i3k4bjgwhc3";
		/// <summary>
        /// Login的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

		public GImage m_n0;
		public GImage m_n2;
		public FUILoginStartButton m_n1;
		public GTextInput m_Account;
		public GTextInput m_Password;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUILogin CreateInstance(Entity domain)
		{			
			return EntityFactory.Create<FUILogin, GObject>(domain, CreateGObject());
		}

        public static ETTask<FUILogin> CreateInstanceAsync(Entity domain)
        {
            ETTask<FUILogin> tcs = ETTask<FUILogin>.Create();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(EntityFactory.Create<FUILogin, GObject>(domain, go));
            });

            return tcs;
        }

        public static FUILogin Create(Entity domain, GObject go)
		{
			return EntityFactory.Create<FUILogin, GObject>(domain, go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUILogin GetFormPool(Entity domain, GObject go)
        {
            var fui = go.Get<FUILogin>();

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
			
			self = (GComponent)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				 /** This is an automatically generated class by FairyGUI. Please do not modify it. **/

				m_n0 = (GImage)com.GetChild("n0");
				m_n2 = (GImage)com.GetChild("n2");
				m_n1 = FUILoginStartButton.Create(this.Domain,com.GetChild("n1"));
				m_Account = (GTextInput)com.GetChild("Account");
				m_Password = (GTextInput)com.GetChild("Password");
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

			m_n0 = null;
			m_n2 = null;
			m_n1.Dispose();
			m_n1 = null;
			m_Account = null;
			m_Password = null;
		}
	}
}