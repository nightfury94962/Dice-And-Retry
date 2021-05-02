using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FightManager : MonoBehaviour
{
	public EntityMotor.Entity entityTurn = EntityMotor.Entity.none;

	public EntityMotor player;
	public EntityMotor enemy;

	public EntityMotor EntityPlay { get { return entityTurn == EntityMotor.Entity.player ? player : enemy; } }

	public static FightManager instance;

	public bool fightFinish = false;

	public EnemyData boss;

	private void Awake()
	{
		instance = this;

		player.entity = EntityMotor.Entity.player;
		player.enemy = enemy;

		enemy.entity = EntityMotor.Entity.enemy;
		enemy.enemy = player;

	}

	void OnEnable()
	{
		if (FightData.instance == null)
			return;
		entityTurn = EntityMotor.Entity.player;
		player.life = 1;
		enemy.life = 1;
		fightFinish = false;
		AsyncTask.MonitorTask(AsyncUpdate());
	}

	// Update is called once per frame
	void Update()
	{
		if ((player.life == 0 || enemy.life == 0f) && (player.myTurn || enemy.myTurn))
		{
			Debug.Log("Enemy Life " + enemy.life.ToString());
			Debug.Log("Player Life " + player.life.ToString());
			fightFinish = true;
			player.myTurn = false;
			enemy.myTurn = false;
		}
	}

	public async Task AsyncUpdate()
	{
		await Task.Delay(1000);
		while(!fightFinish)
		{
			await Task.Delay(1000);
			await EntityPlay.YourTurn();
			entityTurn = entityTurn == EntityMotor.Entity.player ? EntityMotor.Entity.enemy : EntityMotor.Entity.player;
		}
		Debug.Log("Game Over");
		await Task.Delay(1000);

		if (((EnemyControler)enemy.controler).enemyData == boss)
		{
			GameManager.instance.LoadRealGameOver();
		}
		else if (player.life == 0)
		{
			GameManager.instance.GameOver();
		}
		else
		{
			Player.instence.dices = player.dices;
			Player.instence.life = player.life;
			Dice _dice = enemy.dices[Random.Range(0, enemy.dices.Count)];
			_dice.throwRemaining = Random.Range(2, 7);
			Player.instence.AddDice(_dice);
			GameManager.instance.LoadMainScene();
		}
	}

}
