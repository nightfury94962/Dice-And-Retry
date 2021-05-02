using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Controler
{
	public AudioSource audioSource;
	public AudioClip damageSound;

	public EntityMotor motor;

	public override void Init()
	{
		if (FightData.instance == null)
			return;
		motor.dices = Player.instence.dices;
		motor.life = Player.instence.life;
		Debug.Log("Enable " + Player.instence.life);
	}

	public void Start()
	{
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
			AudioSource.PlayClipAtPoint(damageSound, transform.position);
			motor.PlayDice(dice);
			UIManager.instance.inventory.RefreshDiceBar(motor.dices, this);
		}
	}
}
