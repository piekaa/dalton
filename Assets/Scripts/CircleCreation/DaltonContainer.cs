using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class DaltonContainer 
{

	private static DaltonImages[] daltons;
	static int nextDalton = 0;
	static int nextToCreate = 0;
	public static int readyDaltons = 0;
	static int size = 0;

	static DaltonContainer instance;

	public DaltonContainer(int _size)
	{
		daltons = new DaltonImages[_size];
		instance = this;
		size = _size;
		FillMapBuffer ();
	}


	static void FillMapBuffer()
	{
		ThreadStart threadRef = new ThreadStart (instance.CreateMaps);
		
		Thread newThread = new Thread (threadRef);
		newThread.IsBackground = true;
		newThread.Start ();
	}


	void CreateMaps()
	{ 
		while (readyDaltons < size)
		{
			List<Circle> generatedCircles =null;
			DaltonImages di = new DaltonImages ();
			try
			{

			generatedCircles = CirclesCreator.CreateRandomCircles (50, 20, 30, 15, 80, 14, 100, 12, 100, 10, 200);
 
			
			di.NumberLeft = PiekaRandom.Range (0, 10);
			di.NumberRight = PiekaRandom.Range (0, 10);
			DaltonImageCreator.CalculateCircles (di.NumberLeft, di.NumberRight, generatedCircles);


			di.EasyR = DaltonImageCreator.CreateDaltonImage (Params.Easy, 'r', generatedCircles); 
 
			di.EasyG = DaltonImageCreator.CreateDaltonImage (Params.Easy, 'g', generatedCircles); 
 
			di.EasyB = DaltonImageCreator.CreateDaltonImage (Params.Easy, 'b', generatedCircles); 
 
			di.MediumR = DaltonImageCreator.CreateDaltonImage (Params.Medium, 'r', generatedCircles); 
 
			di.MediumG = DaltonImageCreator.CreateDaltonImage (Params.Medium, 'g', generatedCircles); 
 
			di.MediumB = DaltonImageCreator.CreateDaltonImage (Params.Medium, 'b', generatedCircles); 
 
			di.HardR = DaltonImageCreator.CreateDaltonImage (Params.Hard, 'r', generatedCircles); 
 
			di.HardG = DaltonImageCreator.CreateDaltonImage (Params.Hard, 'g', generatedCircles); 
 
			di.HardB = DaltonImageCreator.CreateDaltonImage (Params.Hard, 'b', generatedCircles); 
 
			di.BW = DaltonImageCreator.CreateBWImage (generatedCircles); 
 
			}
			catch(Exception e)
			{
				Debug.Log (e.Message);
				Debug.Log (e.StackTrace);
			}

			daltons [nextToCreate++] = di;

			readyDaltons++;

	//		Debug.Log ("Dalton Added");

			nextToCreate %= size; 


			 
		//	Debug.Log(" circles length " + circleMaps[nextToCreate-1].Count	 );
		}
	}


	public static DaltonImages GetNextDalton()
	{
		DaltonImages result = daltons[nextDalton++];
		readyDaltons--;
		nextDalton %= size;

		FillMapBuffer ();

		return result;
	}



}
