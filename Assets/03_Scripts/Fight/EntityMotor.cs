using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EntityMotor : MonoBehaviour
{
	public Entity entity = Entity.none;
	public int life = 100;
	public int maxLife = 100;


	public bool myTurn = false;

	public EntityMotor enemy;
	public Controler controler;
	public EntityGFX gfx;

	public List<Dice> dices = new List<Dice>();


	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public async Task YourTurn()
	{
		await Play();
	}


	public async Task Play()
	{
		myTurn = true;
		ResetDice();
		controler.InitTurn();
		Debug.LogFormat("{0} Play", entity);
		while(myTurn)
		{
			await Task.Delay(1);
		}
		Debug.LogFormat("{0} Finish Play", entity);
	}

	public bool PlayDice(Dice dice)
	{
		if (dice.used || dice.throwRemaining == 0)
			return false;
		Dice.Face face = dice.GetFace();
		switch(face.type)
		{
			case Dice.FaceType.Damage:
				enemy.TakeDamage(face.value);
				break;
			case Dice.FaceType.AutoDamage:
				TakeDamage(face.value);
				break;
			case Dice.FaceType.Heal:
				TakeDamage(-face.value);
				break;
		}

		if (dice.throwRemaining == 0)
			dices.Remove(dice);

		if (DiceRemaining() == 0)
			myTurn = false;

		return true;
	}

	public void TakeDamage(int damage)
	{
		life -= damage;
		if (life > maxLife)
			life = maxLife;
		if (life < 0)
			life = 0;
		gfx.TakeDamage(damage);
	}

	public int DiceRemaining()
	{
		int diceRemaining = 0;
		foreach(Dice curDice in dices)
		{
			if (!curDice.used)
				diceRemaining += 1;
		}
		return diceRemaining;
	}

	public void ResetDice()
	{
		foreach (Dice curDice in dices)
			curDice.used = false;
	}
	public enum Entity
	{
		none,
		player,
		enemy,
	}
}

