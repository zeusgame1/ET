/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET
{
	[ObjectSystem]
    public class FUIComponent1AwakeSystem : AwakeSystem<FUIComponent1, GObject>
    {
        public override void Awake(FUIComponent1 self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class FUIComponent1 : FUI
	{	
		public const string UIPackageName = "ModelView";
		public const string UIResName = "Component1";
		
		
		public const string URL = "ui://n5i3k4bjdlg60";
		/// <summary>
        /// Component1的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GComponent self;
		
		/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

		public FUIButton1 m_n0;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static FUIComponent1 CreateInstance(Entity domain)
		{			
			return EntityFactory.Create<FUIComponent1, GObject>(domain, CreateGObject());
		}

        public static ETTask<FUIComponent1> CreateInstanceAsync(Entity domain)
        {
            ETTask<FUIComponent1> tcs = ETTask<FUIComponent1>.Create();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(EntityFactory.Create<FUIComponent1, GObject>(domain, go));
            });

            return tcs;
        }

        public static FUIComponent1 Create(Entity domain, GObject go)
		{
			return EntityFactory.Create<FUIComponent1, GObject>(domain, go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static FUIComponent1 GetFormPool(Entity domain, GObject go)
        {
            var fui = go.Get<FUIComponent1>();

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

				m_n0 = FUIButton1.Create(this.Domain,com.GetChild("n0"));
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

			m_n0.Dispose();
			m_n0 = null;
		}
	}
}