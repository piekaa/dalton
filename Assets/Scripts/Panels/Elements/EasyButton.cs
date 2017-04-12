using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyButton : HardnessButton 
{
	public void OnClick()
	{
		FireEvent (EventIDs.StartMenu.Easy);
	}
}
