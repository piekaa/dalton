using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProvider  
{
	 
	private SingleColorProvider colorProvider;

	public ColorProvider(int easiness, char colorTest)
	{
		if (colorTest == 'r')
		{
			colorProvider = new RedColorProvider (easiness);
		}
		if (colorTest == 'g')
		{
			colorProvider = new GreenColorProvider (easiness);
		}
		if (colorTest == 'b')
		{
			colorProvider = new BlueColorProvider (easiness);
		}
	}

	 

	public Color32 GetBackgroundColor()
	{
		return colorProvider.GetBackgroundColor ();
	}


	public Color32 GetNumberColor()
	{
		return colorProvider.GetNumberColor ();
	}

	 

}
