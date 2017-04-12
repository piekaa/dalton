using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesCreator 
{
	public static List<Circle> CreateRandomCircles(int tryTimes, params int[] p)
	{
		CircleMap circleMap = new CircleMap (Params.w, Params.h, Params.MaxR);

		for (int paramIndex = 0; paramIndex < p.Length; paramIndex += 2)
		{

			int r = p [paramIndex];
			int n = p [paramIndex + 1];


			for (int i = 0; i < n; i++)
			{
		//		Debug.Log (i + "/" + n);
				for (int j = 0; j < tryTimes; j++)
				{
					if (circleMap.TryAddRandomCircle (r))
						break;
				}
			}


		}

		return circleMap.GetCircles ();
	}
}
