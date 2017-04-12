using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberImages : MonoBehaviour 
{
	public static PiekaImage[] Left;
	public static PiekaImage[] Right;

	public Sprite[] LeftImages;
	public Sprite[] RightImages;


	void Awake()
	{
		Left = new PiekaImage[LeftImages.Length];
		for (int i = 0; i < Left.Length; i++)
			Left [i] = new PiekaImage( LeftImages[i].texture.width, LeftImages[i].texture.height,  LeftImages [i].texture.GetPixels32 ());
	
	
		Right = new PiekaImage[RightImages.Length];
		for (int i = 0; i < Right.Length; i++)
			Right [i] = new PiekaImage( RightImages[i].texture.width, RightImages[i].texture.height,  RightImages [i].texture.GetPixels32 ());
	}

	 
}
