using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeParams 
{
	public static int Easiness;
	public static char Color;
	public static System.Random Random = new System.Random ();
	public static DaltonImages currentDalton;
	public static object TextureContainerLockObject = new object();
	public static int Score;
	public static int CurrentImage;

	public static int RedScore;
	public static int BlueScore;
	public static int GreenScore;


}