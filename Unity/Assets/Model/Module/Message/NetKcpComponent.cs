#if !NOT_UNITY
using ETCold;
#endif
namespace ET
{
    public class NetKcpComponent: Entity
    {
        public AService Service;
        
        public IMessageDispatcher MessageDispatcher { get; set; }
    }
}