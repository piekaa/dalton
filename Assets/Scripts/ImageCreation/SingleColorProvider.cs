using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleColorProvider 
{
	protected Color32 backgroundColorMin;
	protected Color32 backgroundColorMax;


	protected Color32 numberColorMin;
	protected Color32 numberColorMax;

	protected int easiness;

	private bool reverseColor;

	public SingleColorProvider (int easiness)
	{
		this.easiness = easiness;
		setUpColors ();
		setUpNumberColors ();
		 
		if (PiekaRandom.Range (0, 100) > 50)
			reverseColor = true;


	}



	private void setUpColors()
	{
		backgroundColorMax.r = (byte) PiekaRandom.Range (Params.MinColor, Params.MaxColor);
		backgroundColorMin.r = (byte) (backgroundColorMax.r - Params.ColorDelta);

		backgroundColorMax.g = (byte) PiekaRandom.Range (Params.MinColor, Params.MaxColor);
		backgroundColorMin.g = (byte) (backgroundColorMax.g - Params.ColorDelta);

		backgroundColorMax.b = (byte) PiekaRandom.Range (Params.MinColor, Params.MaxColor);
		backgroundColorMin.b = (byte)(backgroundColorMax.b - Params.ColorDelta);
	}


	protected abstract void setUpNumberColors ();

	public Color32 GetBackgroundColor ()
	{
		return GetRandomColorBetweenValues (backgroundColorMin, backgroundColorMax);

	}
	public Color32 GetNumberColor ()
	{
		return GetRandomColorBetweenValues (numberColorMin, numberColorMax);
	}


	private Color32 createReverseColor(Color32 col)
	{
		return new Color32 ( (byte)(255 - col.r), (byte)(255 - col.g), (byte)(255 - col.b), 255);
	}

	private Color32 GetRandomColorBetweenValues(Color32 min, Color32 max)
	{
		Color32 result = new Color32 ((byte)PiekaRandom.Range (min.r, max.r), (byte)PiekaRandom.Range (min.g, max.g), (byte)PiekaRandom.Range (min.b, max.b), 255);
		if (reverseColor == false)
			return result;
		else
			return createReverseColor (result);
	}

}
