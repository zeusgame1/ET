/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
	[ObjectSystem]
    public class FUIButton1AwakeSystem : AwakeSystem<FUIButton1, GObject>
    {
        public override void Awake(FUIButton1 self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIButton1 : FUI
	{	
		public const string UIPackageName = "ModelView";
		public const string UIResName = "Button1";
		
		
		public const string URL = "ui://n5i3k4bjf5b71";
		/// <summary>
        /// Button1的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GButton self;
		
		/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

		public Controller m_button;
		public GGraph m_n0;
		public GGraph m_n1;
		public GGraph m_n2;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIButton1 CreateInstance(Entity domain)
		{			
			return EntityFactory.Create<FUIButton1, GObject>(domain, CreateGObject());
		}

        public static ETTask<FUIButton1> CreateInstanceAsync(Entity domain)
        {
            ETTask<FUIButton1> tcs = ETTask<FUIButton1>.Create();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(EntityFactory.Create<FUIButton1, GObject>(domain, go));
            });

            return tcs;
        }

        public static FUIButton1 Create(Entity domain, GObject go)
		{
			return EntityFactory.Create<FUIButton1, GObject>(domain, go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIButton1 GetFormPool(Entity domain, GObject go)
        {
            var fui = go.Get<FUIButton1>();

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
				m_n0 = (GGraph)com.GetChild("n0");
				m_n1 = (GGraph)com.GetChild("n1");
				m_n2 = (GGraph)com.GetChild("n2");
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