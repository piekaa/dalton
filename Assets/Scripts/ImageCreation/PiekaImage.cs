using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiekaImage 
{

	public int Width{ get; private set;}
	public int Height{ get; private set;}

	Color32[] pixels;

	public PiekaImage(int width, int height)
	{
	    
		Width = width;
		Height = height;
		pixels = new Color32[width * height];

		for (int i = 0; i < pixels.Length; i++)
			pixels [i] = new Color32 (255, 255, 255, 255);

	}


	public PiekaImage(int width, int height, Color32[] pixels)
	{
		Width = width;
		Height = height;
		this.pixels = pixels;
	}


	public void SetPixel(int x, int y, Color32 color)
	{
		pixels [y * Width + x] = color;
	}
	public Color32 GetPixel(int x, int y)
	{

		if (y * Width + x > Width * Height)
		{
			Debug.Log (Width + " " + Height + " " + x + " " + y);
		}

		return pixels[ y * Width + x ];
	}


	public Sprite CreateSprite()
	{
		Texture2D tex = new Texture2D (Width, Height);
		tex.SetPixels32 (pixels);
		tex.Apply ();	
		return ImageCreator.CreateSprite (tex);

	}








}
