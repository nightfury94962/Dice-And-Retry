using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : Controler
{
	public EntityMotor motor;

	public List<Dice> dicePlayable = new List<Dice>();

	public override void InitTurn()
	{
		foreach (Dice curDice in motor.dices)
		{
			if (curDice.used)
				continue;

			int malus = 0;
			int sum = 0;

			foreach (Dice.Face curFace in curDice.faces)
			{
				sum += curFace.value;
				if (curFace.type == Dice.FaceType.AutoDamage)
					malus += curFace.value;
			}

			if (Random.value >= (malus / sum))
			{
				dicePlayable.Add(curDice);
			}
		}
	}

	void Update()
	{
		if (motor.myTurn)
		{
			if (dicePlayable.Count != 0)
			{
				motor.PlayDice(dicePlayable[0]);
				dicePlayable.RemoveAt(0);
			}
			else
			{
				motor.myTurn = false;
			}
		}
	}
}
