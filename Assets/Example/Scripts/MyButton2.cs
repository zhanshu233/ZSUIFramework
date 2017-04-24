using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSUIFramework;
using UnityEngine.UI;

public class MyButton2 : ZSUI
{
	public Button btn = null;

	public override void Init ()
	{
		ZSUI.AddClickEvent( btn, ShowButton1 );
	}

	private void ShowButton1()
	{
		ZSUI.Show< MyButton >();
	}
}
