

namespace ET
{
	
	public class FUIInitComponent : Entity
	{
		public async ETTask Init()
		{
			await Domain.GetComponent<FUIPackageComponent>().AddPackageAsync("ModelView");
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			

			Domain.GetComponent<FUIPackageComponent>()?.RemovePackage("ModelView");
			base.Dispose();

		}
	}
}