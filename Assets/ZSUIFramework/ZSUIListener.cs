namespace ZSUIFramework
{
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.EventSystems;

	public class ZSUIListener : EventTrigger
	{
		private int    arg_int = 0;
		private float  arg_flt = 0;
		private string arg_str = string.Empty;

		public delegate void ZSUIDelegate( GameObject go, int arg0, float arg1, string arg2 );
		private ZSUIDelegate onClick;

		/// 为控件添加点击事件;
		public static void AddClickEvent( GameObject go, ZSUIDelegate callback,
			int arg_int = 0, float arg_flt = 0, string arg_str = "" )
		{
			if ( null == go ) { return; }
			ZSUIListener listener = go.GetComponent< ZSUIListener >();
			if ( null == listener ) listener = go.AddComponent< ZSUIListener >();
			listener.onClick = callback;
			listener.arg_int = arg_int;
			listener.arg_flt = arg_flt;
			listener.arg_str = arg_str;
		}

		public override void OnPointerClick( PointerEventData eventData )
		{
			if ( null == onClick ) { return; } 
			onClick( gameObject, arg_int, arg_flt, arg_str );
		}
	}
}
