﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
	public EntityMotor motor;
	void Update()
	{

	}

	public override void InitTurn()
	{
		UIManager.instance.inventory.RefreshDiceBar(this);
	}

	public void PlayDice(Dice dice)
	{
		if (motor.myTurn)
		{
			motor.PlayDice(dice);
			UIManager.instance.inventory.RefreshDiceBar(this);
		}
	}
}
