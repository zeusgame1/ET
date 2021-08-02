/*
 * FileName:    FguiAdapter
 * Author:      Jave.Lin
 * CreateTime:  #2018-08-03#
 * Description: [Description]
 * 
*/
using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UObj = UnityEngine.Object;

namespace ET
{
    [ObjectSystem]
    public class FUIScalerComponentAwakeSystem : AwakeSystem<FUIScalerComponent>
    {
        public override void Awake(FUIScalerComponent self)
        {
            self.Awake();
        }
      
    }

    [ObjectSystem]
    public class FUIScalerComponentLateUpdateSystem : LateUpdateSystem<FUIScalerComponent>
    {
        public override void LateUpdate(FUIScalerComponent self)
        {
            self.LateUpdate();
        }
    }
    /// <summary>
    /// FGUI的分辨率适配类型枚举
    /// </summary>
    public enum AdaptedType
    {
        None,                       // 无
        RelationFullScreen,         // 关联+MakeFullScreen
        ScaleFullScreen,            // 缩放到全屏大小,
        Center,
        RawCenter
    }


    /// <summary>
    /// author  :   Jave.Lin
    /// date    :   2018-08-03
    /// </summary>
    public class FUIScalerComponent : Entity
    {
        public class RegisterInfo
        {
            // 便于维护的名称
            public string name;
            // 实例ID
            public int instId;
            // hash code
            public int hc;
            // 适配类型
            public AdaptedType adaptedType;
            // 是否使用全局的适配类型
            public bool useGlobalAdaptedType;
            // 原始x, y
            public float sx, sy;
            // 原始width, height
            public float sw, sh;
            // 原始scaleX, scaleY
            public float ssw, ssh;
            // 注册的GObject对象
            public GObject go;

            public override string ToString()
            {
                return $"name:{name}, type:{adaptedType}, useGlobal:{useGlobalAdaptedType}";
            }
        }
    
      
        // 实例计时器
        private int instCounter;
        // 使用中的适配方式
        private AdaptedType usingGlobalType = AdaptedType.None;
        // key : go, value : size
        private Dictionary<int, RegisterInfo> _registerMap;
        private List<RegisterInfo> _removeList;
        //// 原始的GRoot.inst width, height
        //private float srcRootW, srcRootH;
        // 上次的Screen Width, Height的值
        private float lastSW, lastSH;

        [HideInInspector]
        public Action OnRegisterChanged;

        public List<RegisterInfo> RegisterList;

        // 全局的适配方式适配方式
        [Header("全局方式")]
        public AdaptedType globalAdaptedType = AdaptedType.ScaleFullScreen;
        [Header("当前已注册了的自适应对象的数量")]
        public int Count;
        // 注册自适应
        // 注意3D UI不适用
        // usingGlobalAdaptedType，是否使用FguiAdapter.defaultAdaptedType
        // GObject go手动dispose前，一定要Unregister一下，否则会泄漏
        public void Register(GObject go,
            AdaptedType adaptedType = AdaptedType.Center,
            bool usingGlobalAdaptedType = true,
            string name = null)
        {
            var hc = go.GetHashCode();
            RegisterInfo info = null;
            if (_registerMap.TryGetValue(hc, out info))
            {
                info.adaptedType = adaptedType;
                info.useGlobalAdaptedType = usingGlobalAdaptedType;
                info.name = string.IsNullOrEmpty(name) ? $"AutoName_{++info.instId}" : name;
                AdaptSingle(go);
                return; // already register, re-adapt
            }
            info = new RegisterInfo()
            {
                instId = ++instCounter,
                name = string.IsNullOrEmpty(name) ? $"AutoName_{hc/*++info.instId*/}" : name,
                hc = hc,
                useGlobalAdaptedType = usingGlobalAdaptedType,
                adaptedType = adaptedType,
                sx = go.x,
                sy = go.y,
                sw = go.width,
                sh = go.height,
                ssw = go.scaleX,
                ssh = go.scaleY,
                go = go,
            };
            _registerMap[hc] = info;
            RegisterList.Add(info);
            AdaptSingle(go);
            OnRegisterChanged?.Invoke();
        }
        // 取消注册自适应
        // recover == true时，会恢复到注册那刻前的width, height, scale, 否则会不恢复
        public void Unregister(GObject go, bool recover = false)
        {
            var hc = go.GetHashCode();
            RegisterInfo info = null;
            if (!_registerMap.TryGetValue(hc, out info))
            {
                return; // not found register
            }
            if (recover)
            {
                Recover(go, info);
            }
            _registerMap.Remove(hc);
            RegisterList.Remove(info);
            OnRegisterChanged?.Invoke();
        }
        public void ForceAdaptAll()
        {
            foreach (var item in _registerMap)
            {
                var info = item.Value;
                if (info.go == null || info.go.displayObject == null || info.go.displayObject.gameObject == null)
                {
                    _removeList.Add(info);
                    continue;
                }
                AdaptSingle(info.go);
            }
        }
        public void AdaptSingle(GObject go)
        {
            RegisterInfo info = null;
            if (!_registerMap.TryGetValue(go.GetHashCode(), out info))
            {
                return; // not found
            }
            var type = info.useGlobalAdaptedType ?
                    globalAdaptedType : info.adaptedType;
            switch (type)
            {
                case AdaptedType.None:
                    Recover(go, info);
                    break;
                case AdaptedType.RelationFullScreen:
                    go.SetScale(info.ssw, info.ssh);
                    go.SetXY(info.sx, info.sy);
                    go.MakeFullScreen();
                    break;
                case AdaptedType.ScaleFullScreen:
                    go.SetSize(info.sw, info.sh);
                    go.SetXY(info.sx, info.sy);
                    go.SetScale(GRoot.inst.width / go.width, GRoot.inst.height / go.height);
                    break;
                case AdaptedType.Center:
                    go.SetSize(info.sw, info.sh);
                    go.SetScale(info.ssw, info.ssh);
                    go.SetXY(
                    (GRoot.inst.width - info.go.width) / 2,
                    (GRoot.inst.height - info.go.height) / 2);
                    break;
                case AdaptedType.RawCenter:

                    go.SetXY(
                   (GRoot.inst.width - info.go.width) / 2,
                   (GRoot.inst.height - info.go.height) / 2);

                    break;
                default:
                    break;
            }
        }
        private void CheckAdapt()
        {
            var adapt = false;
            if (lastSW != Screen.width || lastSH != Screen.height)
            {
                adapt = true;
                lastSW = Screen.width;
                lastSH = Screen.height;
            }
            if (usingGlobalType != globalAdaptedType)
            {
                adapt = true;
                usingGlobalType = globalAdaptedType;
            }
            if (adapt)
            {
                ForceAdaptAll();
            }
        }
        private void DeepCopyFrom(FUIScalerComponent obj)
        {
            Clear();

            OnRegisterChanged = obj.OnRegisterChanged;
            RegisterList = obj.RegisterList;
            globalAdaptedType = obj.globalAdaptedType;
            usingGlobalType = obj.usingGlobalType;
            _registerMap = obj._registerMap;
            _removeList = obj._removeList;
            lastSW = obj.lastSW;
            lastSH = obj.lastSH;

            obj._registerMap = null;
            obj._removeList = null;

            Domain.RemoveComponent<FUIScalerComponent>();
            //if (obj.gameObject != null)
            //{
            //    UObj.DestroyImmediate(obj.gameObject);
            //}
            //else
            //{
            //    UObj.DestroyImmediate(obj);
            //}
        }
        private void Recover(GObject go, RegisterInfo info)
        {
            go.SetXY(info.sx, info.sy);
            go.SetSize(info.sw, info.sh);
            go.SetScale(info.ssw, info.ssh);
        }
        private void Clear()
        {
            OnRegisterChanged = null;
            if (_registerMap != null)
            {
                _registerMap.Clear();
                _registerMap = null;
            }
            if (_removeList != null)
            {
                _removeList.Clear();
                _removeList = null;
            }
            if (RegisterList != null)
            {
                RegisterList.Clear();
                RegisterList = null;
            }
        }
        public void Awake()
        {
           
                RegisterList = new List<RegisterInfo>();
                _registerMap = new Dictionary<int, RegisterInfo>();
                _removeList = new List<RegisterInfo>();
                lastSW = Screen.width;
                lastSH = Screen.height;
                ForceAdaptAll();
           
        }
      
        public void LateUpdate()
        {
            CheckAdapt();

            if (_removeList != null && _removeList.Count > 0)
            {
                for (int i = 0, len = _removeList.Count; i < len; i++)
                {
                    _registerMap.Remove(_removeList[i].hc);
                }
                _registerMap.Clear();
            }

            if (_registerMap != null)
            {
                Count = _registerMap.Count;
            }
            else
            {
                Count = 0;
            }
        }
      
        public override void Dispose()
        {
            Clear();
            base.Dispose();
        }
    }
}