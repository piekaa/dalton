using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumButton : HardnessButton 
{
	public void OnClick()
	{
		FireEvent (EventIDs.StartMenu.Medium);
	}
}