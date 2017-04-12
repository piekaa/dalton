using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenColorProvider : SingleColorProvider 
{
	public GreenColorProvider (int easiness) : base  ( (int) (easiness  * (1-Params.GreenMultiplier)) )
	{
	}
	 
	protected override void setUpNumberColors ()
	{
		byte x = (byte)((easiness * Params.GreenMultiplier) / (Params.BlueMultiplier + Params.RedMultiplier)); 

 

		numberColorMax.g = (byte)(backgroundColorMax.g - easiness);
		numberColorMin.g = (byte)(numberColorMax.g - Params.ColorDelta);

		numberColorMax.r = (byte)(backgroundColorMax.r + x);
		numberColorMin.r = (byte)(backgroundColorMin.r + x);

		numberColorMax.b = (byte)(backgroundColorMax.b + x);
		numberColorMin.b = (byte)(backgroundColorMin.b + x);
	}

}
