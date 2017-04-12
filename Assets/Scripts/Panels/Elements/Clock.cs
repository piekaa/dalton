using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AllowedState(StateNames.Gameplay)]
public class Clock : Pieka {

	public float Duration = 10;
	[HideInInspector]
	public float TimeLeft;

	Text text;
	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text> ();
	}

	
	[OnEvent(EventIDs.Gameplay.ImageLoaded)]
	void StartClock()
	{
		TimeLeft = Duration;
		UpdateUI ();
	}


	void UpdateUI()
	{
		float tl = Mathf.Ceil( TimeLeft);

		if (tl < 0)
			tl = 0;

		text.text = tl+"";
	}

	protected override void OnUpdate()
	{
		TimeLeft -= Time.deltaTime;
		if( TimeLeft <= 0 )
			FireEvent (EventIDs.Gameplay.TimeIsUp);

		UpdateUI ();

	}




}
