using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public List<Dice> dice = new List<Dice>();

	public static Player instence;

	public IventoryManager inventory;

	public int life;
	private void Awake()
	{
		instence = this;
		life = 100;
	}

	private void Start()
	{
		inventory.RefreshDiceBar(dice, null);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
