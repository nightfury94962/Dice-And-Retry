﻿using System.Collections;
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

	private void Awake()
	{
		instance = this;
	}

	void Start()
	{
		player.entity = EntityMotor.Entity.player;
		player.enemy = enemy;

		enemy.entity = EntityMotor.Entity.enemy;
		enemy.enemy = player;

		entityTurn = EntityMotor.Entity.player;
		AsyncTask.MonitorTask(AsyncUpdate());
	}

	// Update is called once per frame
	void Update()
	{
		if ((player.life <= 0 || enemy.life <= 0) && fightFinish == false)
		{
			fightFinish = true;
			player.myTurn = false;
			enemy.myTurn = false;
			Debug.Log("Game Over");
		}
	}

	public async Task AsyncUpdate()
	{
		await Task.Delay(1000);
		while(!fightFinish)
		{
			await EntityPlay.YourTurn();
			entityTurn = entityTurn == EntityMotor.Entity.player ? EntityMotor.Entity.enemy : EntityMotor.Entity.player;

			await Task.Delay(1000);
		}
	}

}