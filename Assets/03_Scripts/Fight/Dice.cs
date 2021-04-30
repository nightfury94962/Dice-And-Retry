using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice 
{
	public float timeLeft;
	public bool used = false;
	public List<Face> faces = new List<Face>();

	public Face GetFace()
	{
		used = true;
		return faces[Random.Range(0, faces.Count)];
	}

	public static Dice MakeRandomDice()
	{
		Dice dice = new Dice();
		int faceCount = Random.Range(3, 10);
		DiceType diceType = (DiceType)Random.Range(0, 3);
		for (int i = 0; i < faceCount; i++)
		{
			FaceType faceType = 0;
			int faceValue = Random.Range(3, 40);
			switch(diceType)
			{
				case DiceType.Damage:
					faceType = FaceType.Damage;
					break;
				case DiceType.Heal:
					faceType = FaceType.Heal;
					break;
				case DiceType.DamageAndHeal:
					faceType = Random.Range(0, 2) == 0 ? FaceType.Damage : FaceType.Heal;
					break;
			}
			dice.faces.Add(new Face()
			{
				type = faceType,
				value = faceValue,
			});
		}

		return dice;
	}

	public struct Face
	{
		public FaceType type;
		public int value;
	}

	public enum FaceType
	{
		Damage,
		Heal,
		AutoDamage,
	}

	public enum DiceType
	{
		Damage,
		Heal,
		DamageAndHeal,
	}
}
