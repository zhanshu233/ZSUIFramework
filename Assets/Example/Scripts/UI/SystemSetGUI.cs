﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSUIFramework;

public class SystemSetGUI : ZSUI
{
	public Button mBtnClose = null;

	public override void Init()
	{
		ZSUIListener.AddClickEvent( mBtnClose.gameObject, Close );
	}
}
