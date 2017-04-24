﻿namespace ZSUIFramework
{
	using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.EventSystems;

	public abstract class ZSUI : MonoBehaviour
    {
		// 预设名称;
		private string _UIName = string.Empty;
		public  string mUIName 
		{ get { return _UIName; } }

		// 预设数据;
		private object _UIData = null;
		public  object mUIData
		{ get { return _UIData; } }

		// 预设实例;
		private GameObject _UIPrefab = null;
		public  GameObject mUIPrefab
		{ get { return _UIPrefab; } }

        /// <summary>
        /// 初始化；
        /// 只在实例化预设时执行一次；
        /// </summary>
        public virtual void Init() { }

        /// <summary>
        /// 刷新；
        /// 每次显示预设时都执行一次；
        /// </summary>
        public virtual void Refresh() { }

        /// <summary>
        /// 隐藏；
        /// 推荐用于频繁使用的UI预设；
        /// </summary>
        public virtual void Hide() 
		{
			_UIPrefab.SetActive( false );
		}

		/// <summary>
		/// 显示隐藏状态的UI预设;
		/// </summary>
		public virtual void Show() 
		{
			_UIPrefab.SetActive( true );
		}

        /// <summary>
        /// 销毁；
        /// </summary>
        public virtual void Destroy() 
		{ 
			if ( string.IsNullOrEmpty( _UIName ) ) { return; }
			if ( null == _DictUIInstanceCache ) { return; }
			if ( _DictUIInstanceCache.ContainsKey( _UIName ) )
			{
				_DictUIInstanceCache.Remove( _UIName );
				UnityEngine.Object.Destroy( _UIPrefab );
			}
		}


        //-------------------------------静态成员-------------------------------
		/// <summary>
		/// UI根节点;
		/// </summary>
		private static Transform _UIRoot = null;
		public  static Transform mUIRoot
		{
			get
			{
				if ( null == _UIRoot ) { InitUICanvas(); }
				return _UIRoot;
			}
		}

		// 预设路径;
		// UI组件要和对应的预设同名并放到指定路径下;
		private static string _UIPath = "Prefabs/{0}";
		public  static string mUIPath
		{ get { return _UIPath; } }

		// 当前内存中所有UI预设的实例;
		private static Dictionary< string, ZSUI > _DictUIInstanceCache = null;
		public  static Dictionary< string, ZSUI > mDictUIInstanceCache
		{ get { return _DictUIInstanceCache; } }

		/// <summary>
		/// 添加按钮点击事件;
		/// </summary>
		public static void AddClickEvent( Button button, UnityEngine.Events.UnityAction call )
		{
			if ( null == button || null == call ) { return; }
			button.onClick.AddListener( call );
		}

        /// <summary>
        /// 显示指定UI；
        /// </summary>
        public static void Show< T >() where T : ZSUI, new()
        {
			Type type = typeof ( T );
			string name = type.ToString();
			if ( null == _DictUIInstanceCache ) 
			{ _DictUIInstanceCache = new Dictionary<string, ZSUI> (); }

			// 优先从内存中寻找预设；
			ZSUI zsui = null;
			if ( _DictUIInstanceCache.TryGetValue( name, out zsui ) )
			{
				zsui.Refresh();
				zsui.Show();
				return;
			}

			// 内存未找到则实例化一个预设出来;
			GameObject prefab = Resources.Load( string.Format( _UIPath, name ) ) as GameObject;
			if ( null == prefab )
			{
				Debug.LogError( "[警告] - 在指定路径下加载预设失败！" );
				return;
			}
			GameObject go = UnityEngine.Object.Instantiate( prefab, mUIRoot );
			zsui = go.GetComponent< T >() as ZSUI;
			if ( null == zsui )
			{
				Debug.LogError( "[警告] - 在指定预设上获取组件失败！" );
				return;
			}
			_DictUIInstanceCache.Add( name, zsui );
			zsui._UIPrefab = go;
			zsui.Init();
        }

		/// <summary>
		/// 初始化UI画布;
		/// </summary>
		private static void InitUICanvas()
		{
			GameObject UICanvas = new GameObject( "UICanvas" );
			Canvas           cv = UICanvas.AddComponent< Canvas >();
			CanvasScaler     cs = UICanvas.AddComponent< CanvasScaler >();
			RectTransform    rt = UICanvas.AddComponent< RectTransform >();
			GraphicRaycaster gr = UICanvas.AddComponent< GraphicRaycaster >();
			UICanvas.layer = 5;
			_UIRoot = UICanvas.transform;
			_UIRoot.transform.parent = UICanvas.transform;
			_UIRoot.transform.localPosition = Vector3.zero;
			cv.renderMode = RenderMode.ScreenSpaceOverlay;

			GameObject UICamera = new GameObject( "UICamera" );
			Camera        cm = UICamera.AddComponent< Camera >();
			GUILayer      gl = UICamera.AddComponent< GUILayer >();
			AudioListener al = UICamera.AddComponent< AudioListener >();
			UICamera.transform.parent = UICanvas.transform;
			UICamera.transform.localPosition = Vector3.zero;
			UICamera.layer = 5;

			GameObject EventSystem = new GameObject( "EventSystem" );
			EventSystem           es = EventSystem.AddComponent< EventSystem >();
			StandaloneInputModule si = EventSystem.AddComponent< StandaloneInputModule >();
		}
    }
}