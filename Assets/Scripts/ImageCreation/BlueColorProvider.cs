using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueColorProvider : SingleColorProvider 
{
	public BlueColorProvider (int easiness) : base( (int) (easiness  * (1-Params.BlueMultiplier)) )
	{
	}
	 
	protected override void setUpNumberColors ()
	{
		byte x = (byte) ((easiness * Params.BlueMultiplier) / (Params.RedMultiplier + Params.GreenMultiplier)); 

		numberColorMax.b = (byte) (backgroundColorMax.b - easiness );
		numberColorMin.b = (byte) (numberColorMax.b - Params.ColorDelta);

		numberColorMax.g = (byte) (backgroundColorMax.g + x);
		numberColorMin.g = (byte) (backgroundColorMin.g + x);

		numberColorMax.r = (byte) (backgroundColorMax.r + x);
		numberColorMin.r = (byte) (backgroundColorMin.r + x);

	}

}
