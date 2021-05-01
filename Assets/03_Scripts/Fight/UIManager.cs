using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public RectTransform playerLife;
	public RectTransform enemyLife;
	public Button finish;

	public PlayerControler playerControler;

	public static UIManager instance;

	public IventoryManager inventory;

	private void Awake()
	{
		instance = this;
	}

	// Update is called once per frame
	void Update()
	{
		playerLife.sizeDelta = new Vector2(FightManager.instance.player.life * 500 / FightManager.instance.player.maxLife, 0f);
		enemyLife.sizeDelta = new Vector2(FightManager.instance.enemy.life * 500 / FightManager.instance.enemy.maxLife, 0f);
		finish.interactable = playerControler.motor.myTurn;
	}

	public void FinishTurn()
	{
		playerControler.motor.myTurn = false;
	}
}
