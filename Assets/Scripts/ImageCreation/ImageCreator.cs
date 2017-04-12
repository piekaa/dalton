using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageCreator 
{
 

	public static Texture2D CreateTexture()
	{
		int w = Params.w, h = Params.h;
		Texture2D tex = new Texture2D (w, h);

		
 
		for (int i = 0; i < w; i++)
		{ 
			for (int j = 0; j < h; j++)
			{
				tex.SetPixel (i, j, new Color32 (255, 255, 255, 255));
			}
		}
		tex.Apply ();
		return tex;
	}


	public static void DrawCircle(Texture2D tex, int x, int y, int r, Color c)
	{

		Debug.Log (Mathf.Max (0, x - r) + " " + Mathf.Min (tex.width, x + r));
		Debug.Log ( Mathf.Max (0, y - r) + " " +  Mathf.Min (tex.height, y + r));



		for (int i = Mathf.Max (0, x - r); i < Mathf.Min (tex.width, x + r); i++)
		{
			for (int j = Mathf.Max (0, y - r); j < Mathf.Min (tex.height, y + r); j++)
			{
				if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
				{
					tex.SetPixel (i, j, c);
				}
			}
		} 
	}


	public static void DrawCircleAndApply(Texture2D tex, int x, int y, int r, Color c)
	{

		DrawCircle (tex, x, y, r, c);		
		tex.Apply ();
	}



	public static void DrawCircle(Texture2D tex, Circle circle , Color c)
	{

		int x = circle.x; 
		int y = circle.y; 
		int r = circle.r;
  


		for (int i = Mathf.Max (0, x - r); i < Mathf.Min (tex.width, x + r); i++)
		{
			for (int j = Mathf.Max (0, y - r); j < Mathf.Min (tex.height, y + r); j++)
			{
				if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
				{
					tex.SetPixel (i, j, c);
				}
			}
		} 
	}


	public static void DrawCircle(PiekaImage tex, Circle circle , Color c)
	{

		int x = circle.x; 
		int y = circle.y; 
		int r = circle.r;



		for (int i = Mathf.Max (0, x - r); i < Mathf.Min (tex.Width, x + r); i++)
		{
			for (int j = Mathf.Max (0, y - r); j < Mathf.Min (tex.Height, y + r); j++)
			{
				if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
				{
					tex.SetPixel (i, j, c);
				}
			}
		} 
	}


	public static void DrawCircleAndApply(Texture2D tex, Circle circle , Color c)
	{

		DrawCircle (tex, circle, c);		
		tex.Apply ();
	}




	public static Sprite CreateSprite()
	{
		Texture2D tex = CreateTexture (); 
		return CreateSprite (tex);
	}
 

	public static Sprite CreateSprite(Texture2D tex)
	{
		return  Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.5f));
	}



	public static byte ToBNWColorValue( Color32 col )
	{
		return (byte)  ((float)col.r*Params.RedMultiplier + (float)col.g*Params.GreenMultiplier + (float)col.b*Params.BlueMultiplier);
	}


	public static Sprite CreateBWPicture(Sprite sprite)
	{
		Texture2D tex = sprite.texture;

		Texture2D newTex = new Texture2D (tex.width, tex.height);


		for (int i = 0; i < tex.width; i++)
		{
			for (int j = 0; j < tex.height; j++)
			{

				Color32 col = tex.GetPixel (i, j);

				byte newCol = ToBNWColorValue (col);


				newTex.SetPixel (i, j, new Color32(newCol,newCol,newCol, 255));
			}

		}


		newTex.Apply ();


		return CreateSprite (newTex);




	}



}
