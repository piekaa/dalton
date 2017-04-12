using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaltonImages 
{

	public int NumberLeft;
	public int NumberRight;

	public PiekaImage EasyR;
	public PiekaImage EasyG;
	public PiekaImage EasyB;

	public PiekaImage MediumR;
	public PiekaImage MediumG;
	public PiekaImage MediumB;

	public PiekaImage HardR;
	public PiekaImage HardG;
	public PiekaImage HardB;


	public PiekaImage GetEasy(char c)
	{
		if (c == 'r')
			return EasyR;
		if (c == 'g')
			return EasyG;
		if (c == 'b')
			return EasyB;
		return BW;
	}

	public PiekaImage GetMedium(char c)
	{
		if (c == 'r')
			return MediumR;
		if (c == 'g')
			return MediumG;
		if (c == 'b')
			return MediumB;
		return BW;
	}

	public PiekaImage GetHard(char c)
	{
		if (c == 'r')
			return HardR;
		if (c == 'g')
			return HardG;
		if (c == 'b')
			return HardB;
		return BW;
	}


	public PiekaImage GetCurrent()
	{
		if (RuntimeParams.Easiness == Params.Easy)
		{
			return GetEasy (RuntimeParams.Color);
		}	
		if (RuntimeParams.Easiness == Params.Medium)
		{
			return GetMedium (RuntimeParams.Color);
		}
		if (RuntimeParams.Easiness == Params.Hard)
		{
			return GetHard (RuntimeParams.Color);
		}
		return BW;
	}

	



	public PiekaImage BW;


}
