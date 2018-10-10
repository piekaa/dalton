using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardnessButton : Pieka 
{

	private Color InitialColor;

	void Awake()
	{
		InitialColor = GetComponent<Image> ().color;
	}

	public void SelectMe(Color selectionColor)
	{
		GetComponent<Image> ().color = selectionColor;
	}

	public void UnselectMe()
	{
		GetComponent<Image> ().color = InitialColor;
	}


}
