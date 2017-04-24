using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSUIFramework;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad( this.gameObject );
		ZSUI.Show< MyButton >();
    }
}
