using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardButton : HardnessButton 
{
	public void OnClick()
	{
		FireEvent (EventIDs.StartMenu.Hard);
	}
}