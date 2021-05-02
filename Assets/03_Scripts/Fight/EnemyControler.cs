using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : Controler
{
	public EntityMotor motor;

	public List<Dice> dicePlayable = new List<Dice>();

	public EnemyData enemyData;

	public EntityGFX gfx;

	private float attackCoolDown;

	public override void Init()
	{
		enemyData = FightData.instance.enemyData;
		Debug.Log(enemyData);
		gfx.sprites = enemyData.sprites;
		motor.maxLife = enemyData.life;
		motor.life = enemyData.life;

		foreach (DiceData curDiceData in enemyData.customDice)
		{
			motor.dices.Add(Dice.MakeDice(curDiceData));
		}

		for (int curScarcity = 0; curScarcity < 3; curScarcity++)
		{
			for (int i = 0; i < enemyData.randomDiceCount[curScarcity]; i++)
			{
				motor.dices.Add(Dice.MakeRandomDice((Dice.DiceScarcity)curScarcity));
			}
		}
	}

	public override void InitTurn()
	{
		foreach (Dice curDice in motor.dices)
		{
			if (curDice.throwRemaining != -1)
				curDice.throwRemaining = -1;
			if (curDice.used)
				continue;

			int malus = 0;
			int sum = 0;
			bool onlyHeal = true;

			foreach (Dice.Face curFace in curDice.faces)
			{
				sum += curFace.value;
				if (curFace.type == Dice.FaceType.AutoDamage)
					malus += curFace.value;

				if (curFace.type != Dice.FaceType.Heal)
					onlyHeal = false;
			}

			if (Random.value >= ((malus / (motor.life / 100f) ) / sum) && !(onlyHeal && motor.life == motor.maxLife))
			{
				dicePlayable.Add(curDice);
			}
		}
	}

	void Update()
	{
		if (attackCoolDown > 0f)
			attackCoolDown -= Time.deltaTime;
		if (motor.myTurn && attackCoolDown <= 0f)
		{
			attackCoolDown = 1f;
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
