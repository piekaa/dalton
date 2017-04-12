using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKButtton : Pieka
{	 
	public void OnClick()
	{
		FireEvent (EventIDs.EndReport.Close);
	}
}
