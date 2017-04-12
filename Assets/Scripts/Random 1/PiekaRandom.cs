using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiekaRandom  
{
 

	private const long m = 4294967296; // aka 2^32
	private const long a = 1664525;
	private const long c = 1013904223;
	private static long _last;
	private static bool inited;
	public static void init()
	{
		_last = System.DateTime.Now.Ticks % m;
	}
 

	public static long Next()
	{

		if (!inited)
		{
			inited = true;
			init ();
		}

		_last = ((a * _last) + c) % m;

		return _last;
	}

	public static int Next(int minValue, int maxValue)
	{



		return (int) ( Next()%(maxValue-minValue) + minValue);
	} 

	public static int Range(int min, int max )
	{
 
		return Next (min, max);


	}
 
}
