using System;
using System.Threading;
using UnityEngine;


namespace ETCold
{
    public class GameInit : MonoBehaviour
    {
        public bool IsILRuntime;

        /// <summary>
        /// 需要跳过的DLL
        /// </summary>
        public string[] SkipDlls;
        void Awake()
        {
         


            SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
            DontDestroyOnLoad(this.gameObject);
            Define.IsEditor = Application.isEditor;
            Define.IsILRuntime = IsILRuntime;


            HotfixHelper.SkipDlls = System.Linq.Enumerable.ToList(SkipDlls);

        }





        //public void StartHotfix()
        //{
        //    HotfixHelper.StartHotfix();
        //}



        private void Start()
        {
                GameLoop.onStart?.Invoke();
        }

        private void OnEnable()
        {
                GameLoop.onEnable?.Invoke();
        }

        private void OnDisable()
        {
                GameLoop.onDisable?.Invoke();
        }

        private void Update()
        {
                ThreadSynchronizationContext.Instance.Update();
                GameLoop.onUpdate?.Invoke();
        }

        private void LateUpdate()
        {
                GameLoop.onLateUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
                GameLoop.onFixedUpdate?.Invoke();
        }

        private void OnDestroy()
        {
            try
            {
                GameLoop.onDestroy?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void OnApplicationPause(bool isPause)
        {
            try
            {
                GameLoop.onApplicationPause?.Invoke(isPause);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void OnApplicationFocus(bool isFocus)
        {
            try
            {
                GameLoop.onApplicationFocus?.Invoke(isFocus);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private void OnApplicationQuit()
        {
            try
            {
                GameLoop.onApplicationQuit?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}