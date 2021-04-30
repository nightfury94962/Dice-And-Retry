using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice 
{
	public bool used = false;

	public Face GetFace()
	{
		used = true;
		return new Face()
		{
			type = FaceType.damage,
			value = 5,
		};
	}

	public struct Face
	{
		public FaceType type;
		public int value;
	}

	public enum FaceType
	{
		damage,
		heal,
		autoDamage,
	}
}
