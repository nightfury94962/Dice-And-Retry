using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventoryManager : MonoBehaviour
{

	public RectTransform diceContente;
	public RectTransform faceContente;
	public GameObject faceBG;
	public Text throwRemaining;

	public Sprite[] scarcity;
	public void RefreshDiceBar(List<Dice> dice, PlayerControler playerControler)
	{
		foreach (Transform curChild in diceContente)
		{
			if (curChild.gameObject.activeSelf)
				Destroy(curChild.gameObject);
		}
		foreach (Dice curDice in dice)
		{
			GameObject _diceGo = Instantiate(diceContente.Find("Template").gameObject);
			_diceGo.SetActive(true);
			_diceGo.transform.SetParent(diceContente);
			_diceGo.GetComponent<Image>().sprite = scarcity[(int)curDice.scarcity];
			_diceGo.GetComponent<Button>().interactable = !curDice.used;
			if (playerControler != null)
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

		throwRemaining.gameObject.SetActive(false);

		if (dice == null)
		{
			faceBG.SetActive(false);
			return;
		}

		if (dice.throwRemaining != -1)
		{
			throwRemaining.gameObject.SetActive(true);
			throwRemaining.text = "Throw Remaining: " + dice.throwRemaining;
		}

		faceBG.SetActive(true);
		foreach (Dice.Face curFace in dice.faces)
		{
			GameObject _diceGo = Instantiate(faceContente.Find("Template").gameObject);
			_diceGo.SetActive(true);
			_diceGo.transform.SetParent(faceContente);
			_diceGo.GetComponent<Image>().color = curFace.FaceColor();
			_diceGo.transform.Find("Text").GetComponent<Text>().text = curFace.value.ToString();
		}
	}
}
