using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
	public EntityMotor motor;
	void Update()
	{
		if (motor.myTurn)
		{
			motor.PlayDice(motor.dices[0]);
		}
	}
}
