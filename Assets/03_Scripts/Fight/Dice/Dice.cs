using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice 
{
	public List<Face> faces = new List<Face>();
	public int throwRemaining;
	public bool used = false;
	public DiceScarcity scarcity;

	public Face GetFace()
	{
		used = true;
		return faces[Random.Range(0, faces.Count)];
	}


	public static Dice MakeRandomDice()
	{
		float _scarcity = Random.value;
		DiceScarcity finalScarcity;

		if (_scarcity < 0.05f)
			finalScarcity = DiceScarcity.Legendary;
		else if (_scarcity < 0.2f)
			finalScarcity = DiceScarcity.Rare;
		else
			finalScarcity = DiceScarcity.Comun;

		return MakeRandomDice(finalScarcity);
	}

	public static Dice MakeRandomDice(DiceScarcity _scarcity)
	{
		Dice dice = new Dice();
		dice.scarcity = _scarcity;
		int faceCount = Random.Range(3, 10);

		int minValue = 0;
		int maxValue = 0;
		float malusChance = 0;

		switch(_scarcity)
		{
			case DiceScarcity.Comun:
				minValue = 0;
				maxValue = 7;
				malusChance = 0.2f;
				break;

			case DiceScarcity.Rare:
				minValue = 5;
				maxValue = 12;
				malusChance = 0.1f;
				break;

			case DiceScarcity.Legendary:
				minValue = 10;
				maxValue = 25;
				malusChance = 0.03f;
				break;
		}

		/*
		 * Degat: 50%
		 * Heal: 10%
		 * Heal & Degat: 40%
		 */

		float diceType = Random.value;
		for (int i = 0; i < faceCount; i++)
		{
			FaceType faceType = 0;
			int faceValue = Random.Range(minValue, maxValue);

			if (Random.value < malusChance)
				faceType = FaceType.AutoDamage;
			else if (diceType < 0.5f)
				faceType = FaceType.Damage;
			else if (diceType < 0.6f)
				faceType = FaceType.Heal;
			else
				faceType = Random.value > 0.5f ? FaceType.Heal : FaceType.Damage;


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

		public Color FaceColor
		{
			get
			{
				switch (type)
				{
					case FaceType.Damage:
						return Color.red;
					case FaceType.Heal:
						return Color.green;
					case FaceType.AutoDamage:
						return new Color(0.5f, 0, 0);
				}
				return new Color(0, 1, 1);
			}
		}
	}

	public enum FaceType
	{
		Damage,
		Heal,
		AutoDamage,
	}

	public enum DiceScarcity
	{
		Comun,
		Rare,
		Legendary,
	}
}
