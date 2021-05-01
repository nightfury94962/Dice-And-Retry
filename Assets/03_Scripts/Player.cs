using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public List<Dice> dice = new List<Dice>();

	public static Player instence;

	public IventoryManager inventory;
	private void Awake()
	{
		instence = this;
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
