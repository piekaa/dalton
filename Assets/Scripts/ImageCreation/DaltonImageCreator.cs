using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DaltonImageCreator
{



	public static void CalculateCircles( int numberLeft, int numberRight, List<Circle> circles)
	{
		int leftNumber = numberLeft;
		int rightNumber = numberRight;

		PiekaImage leftTexture = NumberImages.Left [leftNumber];
		PiekaImage rightTexture = NumberImages.Right[rightNumber];


		circles.ForEach (c =>
		{
			if( DoesCircleFitImage( c, leftTexture) || DoesCircleFitImage( c, rightTexture ) )
				c.background = false;
			else
				c.background = true;

		}); 
 
	}



	public static PiekaImage CreateBWImage(List<Circle> circles)
	{
		PiekaImage image = new PiekaImage (Params.w, Params.h);
 
	  
		circles.ForEach (c =>
		{
			if( c.background )
				ImageCreator.DrawCircle (image, c, Color.white );
			else
				ImageCreator.DrawCircle (image, c, Color.black );

		});
 
		return image;
	}


	public static PiekaImage CreateDaltonImage(int easiness, char colorTest, List<Circle> circles)
	{
		PiekaImage image = new PiekaImage (Params.w, Params.h);
	 

		ColorProvider colorProvider = new ColorProvider (easiness, colorTest);


		circles.ForEach (c =>
		{
			if( c.background )
				ImageCreator.DrawCircle (image, c, colorProvider.GetNumberColor());
			else
				ImageCreator.DrawCircle (image, c, colorProvider.GetBackgroundColor());

		});

		 
		return image;

	}




	private static bool DoesCircleFitImage( Circle circle, PiekaImage tex )
	{
		int fitPixels = 0;
		int allPixels = 0;


		for (int i = circle.x - circle.r; i <= circle.x + circle.r; i++)
		{
			for (int j = circle.y - circle.r; j <= circle.y + circle.r; j++)
			{
				allPixels++;

				if (tex.GetPixel (i, j) == Color.black)
				{
					fitPixels++;
				}

			}
		}


		if ((float)fitPixels / allPixels >= Params.RequiredFitPercentage)
			return true;
		return false;


	}
		




}