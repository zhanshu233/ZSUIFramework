using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSUIFramework;

public class MainStageGUI : ZSUI 
{
	public Button mBtnPlayerInfo = null;
	public Button mBtnSystemSet  = null;
	public Button mBtnCreatRoom  = null;
	public Button mBtnJoinRoom   = null;

	public override void Init()
	{
		ZSUIListener.AddClickEvent( mBtnPlayerInfo.gameObject , OpenPlayerInfoGUI , 0 , 0 , "" ); // 打开人物信息界面;
		ZSUIListener.AddClickEvent( mBtnSystemSet.gameObject  , OpenSystemSetGUI  , 0 , 0 , "" ); // 打开系统设置界面;
		ZSUIListener.AddClickEvent( mBtnCreatRoom.gameObject  , OpenCreatRoomGUI  , 0 , 0 , "" ); // 打开创建房间界面;
		ZSUIListener.AddClickEvent( mBtnJoinRoom.gameObject   , OpenJoinRoomGUI   , 0 , 0 , "" ); // 打开加入房间界面;
	}

	private void OpenPlayerInfoGUI( GameObject go, int arg0, float arg1, string arg2 )
	{
		Show< PlayerInfoGUI >();
	}

	private void OpenSystemSetGUI( GameObject go, int arg0, float arg1, string arg2 )
	{
		Show< SystemSetGUI >();
	}

	private void OpenCreatRoomGUI( GameObject go, int arg0, float arg1, string arg2 )
	{
		Show< CreatRoomGUI >();
	}

	private void OpenJoinRoomGUI( GameObject go, int arg0, float arg1, string arg2 )
	{
		Show< JoinRoomGUI >();
	}
}
