using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedColorProvider : SingleColorProvider  
{

	public RedColorProvider (int easiness) : base( (int) (easiness  * (1-Params.RedMultiplier)) )
	{
	}
	 
	protected override void setUpNumberColors ()
	{
		byte x =  (byte)(  (easiness * Params.RedMultiplier) / (Params.BlueMultiplier + Params.GreenMultiplier)); 


		numberColorMax.r = (byte) ( backgroundColorMax.r - easiness );
		numberColorMin.r = (byte) (numberColorMax.r - Params.ColorDelta);

		numberColorMax.g = (byte) (backgroundColorMax.g + x);
		numberColorMin.g = (byte) (backgroundColorMin.g + x);

		numberColorMax.b = (byte) (backgroundColorMax.b + x);
		numberColorMin.b = (byte) (backgroundColorMin.b + x);




	}
}
