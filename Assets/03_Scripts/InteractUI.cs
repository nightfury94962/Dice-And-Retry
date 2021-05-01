using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public static InteractUI instance;
	public Text textInfo;

	private void Awake()
	{
		instance = this;
	}

	public void SetText(string text)
	{
		textInfo.text = text;
	}
}
