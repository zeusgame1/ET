using ETCold;

using System;
using System.Collections.Generic;
using UnityEngine;
namespace ET
{



    public static class Init
    {
        public static void Start()
        {
            Log.Info($"热更层");
            GameLoop.onUpdate += Update;
            GameLoop.onLateUpdate += LateUpdate;
            GameLoop.onApplicationQuit += OnApplicationQuit;

            //GameObject game = new GameObject();
            //game.GetComponent<Transform>();


            try
            {
                Game.EventSystem.Add(HotfixHelper.GetTypes());
                Game.EventSystem.Init();
                ProtobufHelper.Init();

                Game.Options = new Options();
                Log.Info("发送事件");
                Game.EventSystem.Publish(new EventType.AppStart()).Coroutine();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void Update()
        {
            try
            {
                Game.Update();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void LateUpdate()
        {
            try
            {
                Game.LateUpdate();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void OnApplicationQuit()
        {
            Log.Info($"Hotfix OnApplicationQuit");
            GameLoop.onUpdate -= Update;
            GameLoop.onLateUpdate -= LateUpdate;
            GameLoop.onApplicationQuit -= OnApplicationQuit;
            Game.Close();

            if (Define.IsILRuntime)
            {
                ILRuntimeHelper.Dispose();
            }
            UnityEngine.Application.Quit();
        }
    }
}