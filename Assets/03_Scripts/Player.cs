using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public List<Dice> dices = new List<Dice>();

	public static Player instence;

	public IventoryManager inventory;

	public const int inventorySize = 10;

	public int life = 100;
	private void Awake()
	{
		instence = this;
		Debug.LogError("Console");
	}

	private void Start()
	{
		inventory.RefreshDiceBar(dices, null);
		life = 100;
	}

	public void AddDice(Dice dice)
	{
		if (dices.Count == inventorySize)
		{
			dices.RemoveAt(Random.Range(0, dices.Count));
		}
		dices.Insert(Random.Range(0, dices.Count), dice);
		inventory.RefreshDiceBar(dices, null);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
