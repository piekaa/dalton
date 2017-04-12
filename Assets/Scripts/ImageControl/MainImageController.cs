using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainImageController : Pieka {


	Image image;


	void Awake()
	{
		image = GetComponent<Image> ();
	}
 

	[OnEvent(EventIDs.Gameplay.LoadNewImage)]
	void LoadNewImage(string id, PMEventArgs args)
	{
//		print ("LoadNewImage");
		image.sprite = RuntimeParams.currentDalton.GetCurrent ().CreateSprite();
		FireEvent (EventIDs.Gameplay.ImageLoaded);
  
	//	image.sprite = new PiekaImage(Params.w, Params.h).CreateSprite();
	}


	[OnEvent(EventIDs.Gameplay.ShowBWImage)]
	void ShowBW(string id, PMEventArgs args)
	{
//		print ("LoadNewImage");
		image.sprite = RuntimeParams.currentDalton.BW.CreateSprite();
	}

	  
}
