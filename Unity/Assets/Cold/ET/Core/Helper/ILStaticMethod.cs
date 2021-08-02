
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;

namespace ETCold
{
	public class ILStaticMethod : IStaticMethod
	{
		private readonly AppDomain appDomain;
		private readonly IMethod method;
		private readonly object[] param;

		public ILStaticMethod(AppDomain appDomain, string typeName, string methodName, int paramsCount)
		{
			this.appDomain = appDomain;
			this.method = appDomain.GetType(typeName).GetMethod(methodName, paramsCount);
			this.param = new object[paramsCount];
		}

		public override void Run()
		{
			//using (var ctx = this.appDomain.BeginInvoke(this.method))
			//{
   //             //依次将参数压入栈，如果为成员方法，第一个参数固定为对象实例

   //             for (int i = 0; i < param.Length; i++)
   //             {
			//		ctx.PushObject(param[i]);

			//	}
			//	//开始调用
			//	ctx.Invoke();
			
			//}
			this.appDomain.Invoke(this.method, null, this.param);
		}

		public override void Run(object a)
		{
			this.param[0] = a;
			this.appDomain.Invoke(this.method, null, param);
		}

		public override void Run(object a, object b)
		{
			this.param[0] = a;
			this.param[1] = b;
			this.appDomain.Invoke(this.method, null, param);
		}

		public override void Run(object a, object b, object c)
		{
			this.param[0] = a;
			this.param[1] = b;
			this.param[2] = c;
			this.appDomain.Invoke(this.method, null, param);
		}
	}
}
