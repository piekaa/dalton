public class EventIDs 
{
	public class Lifecycle
	{
		public const string FirstUpdate = "Lifecycle.FirstUpdate";
		public const string StateChange = "Lifecycle.StateChange";
	}

	public class Gameplay
	{
		public const string LoadNewImage = "Gameplay.LoadNewImage";
		public const string Confirmed = "Gameplay.Confirmed";
		public const string ShowBWImage = "Gameplay.ShowBWImage";
		public const string Next = "Gameplay.Next";
		public const string ImageLoaded = "Gameplay.ImageLoaded";
		public const string TimeIsUp = "Gameplay.TimeIsUp";
	}

	public class EndReport
	{
		public const string Close = "EndReport.Close"; 
	}


	public class StartMenu
	{
		public const string Easy = "StartMenu.Easy" ;
		public const string Medium = "StartMenu.Medium";
		public const string Hard = "StartMenu.Hard";
	}

	public class Test
	{
		public const string Value = "Test.Value";

		public class InnerTest
		{
			public const string InnerValue = "Test.InnerTest.Value";
		}
	}

}



