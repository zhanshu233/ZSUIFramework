using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSUIFramework;
using UnityEngine.EventSystems;

public class MainStageGUI : ZSUI 
{
	public Image image = null;
	public Button btn = null;

	public override void Init()
	{
		ZSUIListener.AddClickEvent( btn.gameObject, Speak );
	}

	public void Speak( GameObject go, int arg0, float arg1, string arg2 )
	{
		Debug.Log( "arg0:=" + arg0.ToString() );
		Debug.Log( "arg1:=" + arg1.ToString() );
		Debug.Log( "arg2:=" + arg2 );
	}
}
