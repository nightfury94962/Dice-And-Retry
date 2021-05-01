using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
	public EntityMotor motor;

	private void Start()
	{
		motor.dices = Player.instence.dice;
		motor.life = Player.instence.life;
	}
	void Update()
	{

	}

	public override void InitTurn()
	{
		UIManager.instance.inventory.RefreshDiceBar(motor.dices, this);
	}

	public void PlayDice(Dice dice)
	{
		if (motor.myTurn)
		{
			motor.PlayDice(dice);
			UIManager.instance.inventory.RefreshDiceBar(motor.dices, this);
		}
	}
}
