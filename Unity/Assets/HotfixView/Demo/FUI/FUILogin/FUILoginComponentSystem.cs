using System;
using System.Net;

using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [ObjectSystem]
    public class FUILoginComponentAwakeSystem : AwakeSystem<FUILoginComponent>
    {
        public override void Awake(FUILoginComponent self)
        {
            Log.Error("FUILogin binding");
            self.fuiLogin = self.GetParent<FUILogin>();

            self.fuiLogin.m_n1.self.onClick.Set(() =>
            {
                self.OnLogin();
            });

                
            

        }
    }
 
  
    public static class FUILoginComponentSystem
    {
      
        public static void OnLogin(this FUILoginComponent self)
		{
			LoginHelper.Login(self.DomainScene(), ConstValue.LoginAddress, self.fuiLogin.m_Account.text, self.fuiLogin.m_Password.text).Coroutine();
		}
	}
}
