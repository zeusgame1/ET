using System;
using System.ComponentModel;

using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;


namespace ETCold
{
    [ILAdapter]
    public class ISupportInitializeClassInheritanceAdaptor : CrossBindingAdaptor
    {
        public override Type BaseCLRType => typeof(ISupportInitialize);

        public override Type AdaptorType => typeof(ISupportInitializeAdaptor);


        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new ISupportInitializeAdaptor(appdomain, instance);
        }

    }
    public class ISupportInitializeAdaptor : ISupportInitialize, CrossBindingAdaptorType
    {

        private ILTypeInstance instance;
        private ILRuntime.Runtime.Enviorment.AppDomain appDomain;

        private IMethod IBeginInit;
        private IMethod IEndInit;
        private readonly object[] param0 = new object[0];


        public ISupportInitializeAdaptor()
        {

        }

        public ISupportInitializeAdaptor(ILRuntime.Runtime.Enviorment.AppDomain appDomain, ILTypeInstance instance)
        {
            this.appDomain = appDomain;
            this.instance = instance;
        }


        public ILTypeInstance ILInstance => this.instance;


        public void BeginInit()
        {
            if (IBeginInit==null)
            {
                IBeginInit = instance.Type.GetMethod("BeginInit");
            }
            this.appDomain.Invoke(IBeginInit, instance, null);
        }

        public void EndInit()
        {
            if (IEndInit == null)
            {
                IEndInit = instance.Type.GetMethod("EndInit");
                this.appDomain.Invoke(IEndInit, instance, null);
            }
        }

    }
}