using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
	[SerializeField]
	public bool OnChest;
	public bool isOpen;

	public Sprite chestOpen;

	public AudioSource audioSource;
	public AudioClip OpenChestSound;

	public DiceData[] customDices;
	public Dice.DiceScarcity[] randomDices;
	public int diceLoot = 1;

	private void Awake()
	{
	}

	private void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.Play();
	}

	// Update is called once per frame
	void Update()
	{
		if (OnChest && !isOpen && Input.GetKeyDown("e"))
		{
			OpenChest();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && !isOpen)
		{
			InteractUI.instance.SetText("Appuie sur 'E' pour interagir");
			OnChest = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			InteractUI.instance.SetText("");
			OnChest = false;
		}
	}


	void OpenChest()
	{
		audioSource.PlayOneShot(OpenChestSound);
		GetComponent<SpriteRenderer>().sprite = chestOpen;
		for (int i = 0; i < diceLoot; i++)
		{
			if (Random.value < customDices.Length / (float)(customDices.Length + randomDices.Length))
				Player.instence.AddDice(Dice.MakeDice(customDices[Random.Range(0, customDices.Length)]));
			else
				Player.instence.AddDice(Dice.MakeRandomDice(randomDices[Random.Range(0, randomDices.Length)]));
		}


		isOpen = true;
		InteractUI.instance.SetText("");
	}
}
