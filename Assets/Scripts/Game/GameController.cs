using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameController : Pieka 
{

	DaltonContainer circlesContainer;
	void Start()
	{ 
		circlesContainer = new DaltonContainer (Params.ImageBufor);
	//	FireEvent (EventIDs.Gameplay.LoadNewImage, new PMEventArgs( new Vector2( Random.Range( 0, 10 ), Random.Range(0,10)) ) );
	}

	private char selectedColor ='a'; 


	private int Counter = 0;


	protected override void OnUpdate()
	{ 

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (StateController.GetActiveState () == StateNames.StartMenu)
			{
				Application.Quit ();
			}
			else
			{
				StateController.SetActiveState (StateNames.StartMenu);
			}

		}

	}


	public void StartRed()
	{
		selectedColor = 'r';
		RuntimeParams.Color = 'r';
		startGame ();
	}

	public void StartGreen()
	{
		selectedColor = 'g';
		RuntimeParams.Color = 'g';
		startGame ();
	}

	public void StartBlue()
	{
		selectedColor = 'b';
		RuntimeParams.Color = 'b';
		startGame ();
	}


	public void StartAll()
	{


		selectedColor = 'a';
		RuntimeParams.Color = 'a';
		startGame ();
	}


	private void startGame()
	{ 

		Counter++;

		/*
		if (Advertisement.IsReady () && Counter % 2 == 0)
		{
			Advertisement.Show (new ShowOptions{ resultCallback = AdCallback });
			return;
		}
*/




 

		StateController.SetActiveState (StateNames.Gameplay); 
		RuntimeParams.CurrentImage = 0;
		RuntimeParams.Score = 0;
		RuntimeParams.RedScore = 0;
		RuntimeParams.GreenScore = 0;
		RuntimeParams.BlueScore = 0;
		loadNewImage ();
 
	} 


/*
	void AdCallback(ShowResult sr )
	{
		StateController.SetActiveState (StateNames.Gameplay); 
		RuntimeParams.CurrentImage = 0;
		RuntimeParams.Score = 0;
		RuntimeParams.RedScore = 0;
		RuntimeParams.GreenScore = 0;
		RuntimeParams.BlueScore = 0;
		loadNewImage ();
	}
*/

	private void loadNewImage()
	{
		RuntimeParams.CurrentImage++;
		char col = selectedColor;

		if (selectedColor == 'a')
		{
			if ( RuntimeParams.CurrentImage <= 3 )
				col = 'r';
			else if (RuntimeParams.CurrentImage <= 6)
				col = 'g';
			else
				col = 'b';

		}
 

		while (DaltonContainer.readyDaltons == 0)
		{
		}

		DaltonImages di = DaltonContainer.GetNextDalton ();
		RuntimeParams.currentDalton = di;

		RuntimeParams.Color = col;

		PMEventArgs args = new PMEventArgs ();
		args.Vector2 = new Vector2 (di.NumberLeft, di.NumberRight);
		args.Character = col;
		FireEvent (EventIDs.Gameplay.LoadNewImage, args );

	}


	[OnEvent( EventIDs.Gameplay.Confirmed) ]
	private void OnOk(string id, PMEventArgs args)
	{
		string s = args.Text;

		if (s.Length > 0)
		{
			if (s [0] - '0' == RuntimeParams.currentDalton.NumberLeft)
				IncScore ();
		}
		if (s.Length == 2)
		{
			if (s [1] - '0' == RuntimeParams.currentDalton.NumberRight)
				IncScore ();
		} 

		FireEvent (EventIDs.Gameplay.ShowBWImage);
		StateController.SetActiveState (StateNames.GameplayShowImage);
	}


	private void IncScore()
	{
		RuntimeParams.Score++;
		if (selectedColor == 'r')
			RuntimeParams.RedScore++;
		if( selectedColor == 'g' )
			RuntimeParams.GreenScore++;
		if( selectedColor == 'b' )
			RuntimeParams.BlueScore++;
		if (selectedColor == 'a')
		{
			if ( RuntimeParams.CurrentImage <= 3 )
				RuntimeParams.RedScore++;
			else if (RuntimeParams.CurrentImage <= 6)
				RuntimeParams.GreenScore++;
			else
				RuntimeParams.BlueScore++;

		}
	}


	[OnEvent( EventIDs.Gameplay.Next) ]
	private void OnNext()
	{

		if (RuntimeParams.CurrentImage >= Params.TestImagesCount)
		{
			if( selectedColor == 'r' )
				StateController.SetActiveState (StateNames.EndReportRed);	
			if( selectedColor == 'g' )
				StateController.SetActiveState (StateNames.EndReportGreen);	
			if( selectedColor == 'b' )
				StateController.SetActiveState (StateNames.EndReportBlue);	
			if( selectedColor == 'a' )
				StateController.SetActiveState (StateNames.EndReportMixed);	

		} else
		{
			StateController.SetActiveState (StateNames.Gameplay);
			loadNewImage ();
		}
	}


	[OnEvent(EventIDs.EndReport.Close)]
	private void OnCloseReport()
	{
		StateController.SetActiveState (StateNames.StartMenu);
	}


 
}
