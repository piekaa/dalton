using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CircleMap
{
	private List<Circle> circles = new List<Circle>();

	private List<Circle>[][] map;

	private int w; 
	private int h;
	private int maxR;
	private int spaceW;
	private int spaceH;

	private int sizeX;
	private int sizeY;

	public CircleMap (int w, int h, int maxR)
	{
		this.w = w;
		this.h = h;
		this.maxR = maxR;
		CreateMap ();
	}



	private void CreateMap()
	{
		maxR *= 2;
		spaceW =  Mathf.CeilToInt ((float)w / maxR);
		spaceH = Mathf.CeilToInt ((float)h / maxR);

		sizeX = maxR;
		sizeY = maxR; 
  
		map = new List<Circle>[spaceW][];
 
		for (int i = 0 ; i < spaceW ; i++)
		{
			map [i] = new List<Circle>[spaceH];
			for (int j = 0; j < spaceH; j++)
			{
				map [i] [j] = new List<Circle> ();
			}
		} 
	}

	

	public bool TryAddCircle(Circle circle)
	{
		 
		if ( Vector2.Distance( new Vector2( circle.x, circle.y), new Vector2( w/2, h/2) ) + circle.r >= w/2 ) 
			return false;

		int placeX = circle.x / sizeX;
		int placeY = circle.y / sizeY;


		bool canAdd = true;


	//	Debug.Log ("b4 for");
		for (int i = Mathf.Max (placeX -1 , 0); i < Mathf.Min (placeX +2 , spaceW); i++)
		{
			for(int j = Mathf.Max( placeY -1 , 0 ) ; j < Mathf.Min (placeY +2, spaceH) ; j++)
			{

				if( map[i][j].Exists( c => c.IsColliding( circle ) ) )
				{
					canAdd = false;
					goto outer;
				}
			}
		}
		outer:



		if (canAdd)
		{
			map [placeX] [placeY].Add (circle);
			circles.Add (circle);
		}
	//	Debug.Log ("after for");
		return canAdd;


//		bool canAdd = circles.TrueForAll (c => c.IsColliding (circle) == false);
//		if (canAdd)
//		{
//			circles.Add (circle);
//		}
//		return canAdd;
	}

	public bool TryAddRandomCircle(int r)
	{   
		Circle circle = null;
		int x = PiekaRandom.Range(r, w - r);
		int y = PiekaRandom.Range(r, h - r);
		circle = new Circle (x, y, r); 
		return TryAddCircle (circle); 
	}


	public List<Circle> GetCircles()
	{
		return circles;
	}


}
