using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public EntityMotor motor;
	void Update()
	{
		if (motor.myTurn)
		{
			motor.PlayDice(motor.dices[Random.Range(0, motor.dices.Count)]);
		}
	}
}
