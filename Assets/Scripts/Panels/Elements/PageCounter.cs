using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PageCounter : Pieka {
  
	Text text;
	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text> ();
	}


	[OnEvent(EventIDs.Gameplay.ImageLoaded)]
	void StartClock()
	{ 
		UpdateUI ();
	}


	void UpdateUI()
	{
		text.text = RuntimeParams.CurrentImage + "/" + Params.TestImagesCount;
	}
	 
}
