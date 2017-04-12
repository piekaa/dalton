using System.Collections.Generic;
using UnityEngine;
using System.Reflection; 
public class PiekaUI : Pieka
{
	 


	public void InitPiekaUI()
	{
		gameObject.SetActive (false);
		UnregisterAll ();
	}
  


	protected override void OnEnterToActiveState ()
	{ 
		gameObject.SetActive (true);
		RegisterAll ();
		OnEnterToActiveStateUI (); 
	}

	protected override void OnExitFromActiveState ()
	{ 
		gameObject.SetActive (false);
		UnregisterAll ();
		OnExitFromActiveStateUI ();
	}


	protected virtual void OnEnterToActiveStateUI(){}
	protected virtual void OnExitFromActiveStateUI(){}
}

