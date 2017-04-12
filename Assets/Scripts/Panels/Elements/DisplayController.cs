using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayController : Pieka
{
	string currentNubmer = "";


	private Text text;

	void Awake()
	{
		text = GetComponent<Text> ();
	}

	void UpdateImage()
	{
		text.text = currentNubmer;
	}

	[OnEvent(EventIDs.Gameplay.LoadNewImage)]
	public void Clear()
	{
		currentNubmer = "";
		UpdateImage ();
	}

	[OnEvent(EventIDs.Gameplay.ShowBWImage)]
	void OnShowBW()
	{

		string goodNumber = RuntimeParams.currentDalton.NumberLeft + "" + RuntimeParams.currentDalton.NumberRight;

		string face = "";
		int score = 0;
		if (currentNubmer.Length > 0)
		{
			if (currentNubmer [0] - '0' == RuntimeParams.currentDalton.NumberLeft)
				score++;
		}
		if (currentNubmer.Length == 2)
		{
			if (currentNubmer [1] - '0' == RuntimeParams.currentDalton.NumberRight)
				score++;
		}

		if (score == 0)
			face = ":(";
		if (score == 1)
			face = ":|";
		if (score == 2)
			face = ":)";
		

				currentNubmer += " : " + RuntimeParams.currentDalton.NumberLeft + "" + RuntimeParams.currentDalton.NumberRight + " " + face;
		UpdateImage ();
	}


	public void OnButtonClicked(string button)
	{
		if (button == "X")
		{
			backspace ();
		}
		if (isNumber (button))
		{
			if (currentNubmer.Length < 2)
			{
				currentNubmer += button [0];
			}
		}
		if (button == "OK")
		{
			FireEvent (EventIDs.Gameplay.Confirmed, new PMEventArgs(currentNubmer));
		}
		UpdateImage ();
	}


	private void backspace()
	{
		if (currentNubmer.Length == 2)
		{
			currentNubmer = "" + currentNubmer [0];
		} else if (currentNubmer.Length == 1)
		{
			currentNubmer = "";
		}
	}

	private bool isNumber(string s )
	{
		if (s.Length != 1)
			return false;

		char c = s [0];

		if (c >= '0' && c <= '9')
			return true;
		return false;

	}


	[OnEvent(EventIDs.Gameplay.TimeIsUp)]
	private void OnTimeIsUp()
	{
		FireEvent (EventIDs.Gameplay.Confirmed, new PMEventArgs(currentNubmer));
	}

 
}
