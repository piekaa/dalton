using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AllowedState(StateNames.GameplayShowImage)]
public class Keyboard2 : PiekaUI 
{
	public void OnClick()
	{
		FireEvent (EventIDs.Gameplay.Next);
	}
		
}
