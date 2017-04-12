using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardnessButtonController : Pieka
{
	public HardnessButton EasyButton;
	public HardnessButton MediumButton;
	public HardnessButton HardButton;
	public Color SelectionColor;

	void Start()
	{
		OnEasyButton ();
	}


	[OnEvent(EventIDs.StartMenu.Easy)]
	void OnEasyButton()
	{
		RuntimeParams.Easiness = Params.Easy;
		EasyButton.SelectMe(SelectionColor);
		MediumButton.UnselectMe ();
		HardButton.UnselectMe ();
	}

	[OnEvent(EventIDs.StartMenu.Medium)]
	void OnMediumButton()
	{
		RuntimeParams.Easiness = Params.Medium;
		EasyButton.UnselectMe();
		MediumButton.SelectMe(SelectionColor);
		HardButton.UnselectMe();
	}

	[OnEvent(EventIDs.StartMenu.Hard)]
	void OnHardButton()
	{
		RuntimeParams.Easiness = Params.Hard;
		EasyButton.UnselectMe();
		MediumButton.UnselectMe();
		HardButton.SelectMe(SelectionColor);
	}



}
