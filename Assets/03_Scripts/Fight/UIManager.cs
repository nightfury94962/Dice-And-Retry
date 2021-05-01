using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public RectTransform diceContente;
	public RectTransform faceContente;
	public GameObject faceBG;
	public RectTransform playerLife;
	public RectTransform enemyLife;

	public PlayerControler playerControler;

	public static UIManager instance;

	public Sprite[] scarcity;

	private void Awake()
	{
		instance = this;
	}

	public void RefreshDiceBar()
	{
		foreach (Transform curChild in diceContente)
		{
			if (curChild.gameObject.activeSelf)
				Destroy(curChild.gameObject);
		}
		foreach(Dice curDice in FightManager.instance.player.dices)
		{
			GameObject _diceGo = Instantiate(diceContente.Find("Template").gameObject);
			_diceGo.SetActive(true);
			_diceGo.transform.SetParent(diceContente);
			_diceGo.GetComponent<Image>().sprite = scarcity[(int)curDice.scarcity];
			_diceGo.GetComponent<Button>().interactable = !curDice.used;
			_diceGo.GetComponent<Button>().onClick.AddListener(delegate () { playerControler.PlayDice(curDice); });
			_diceGo.GetComponent<BtnOnHover>().OnEnter = delegate () { CheckDiceFace(curDice); };
			_diceGo.GetComponent<BtnOnHover>().OnExit = delegate () { CheckDiceFace(null); };

		}
	}

	public void CheckDiceFace(Dice dice)
	{
		foreach (Transform curChild in faceContente)
		{
			if (curChild.gameObject.activeSelf)
				Destroy(curChild.gameObject);
		}
		
		if (dice == null)
		{
			faceBG.SetActive(false);
			return;
		}
		faceBG.SetActive(true);
		foreach (Dice.Face curFace in dice.faces)
		{
			GameObject _diceGo = Instantiate(faceContente.Find("Template").gameObject);
			_diceGo.SetActive(true);
			_diceGo.transform.SetParent(faceContente);
			_diceGo.GetComponent<Image>().color = curFace.FaceColor;
			_diceGo.transform.Find("Text").GetComponent<Text>().text = curFace.value.ToString();
		}
	}

	// Update is called once per frame
	void Update()
	{
		playerLife.sizeDelta = new Vector2(FightManager.instance.player.life * 500 / FightManager.instance.player.maxLife, 0f);
		enemyLife.sizeDelta = new Vector2(FightManager.instance.enemy.life * 500 / FightManager.instance.player.maxLife, 0f);
	}
}
