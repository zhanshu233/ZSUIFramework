using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSUIFramework;
using UnityEngine.UI;

public class MyButton : ZSUI
{
	public Button btn = null;

	public override void Init ()
	{
		ZSUI.AddClickEvent( btn, BtnClick );
	}

	private void BtnClick()
	{
		base.Hide();
		ZSUI.Show< MyButton2 >();
	}
}
