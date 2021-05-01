using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Dice And Retry/Dice Data")]
public class DiceData : ScriptableObject
{
	public Dice.DiceScarcity scarcity;
	public int throwQuantity;
	public int[] value;
	public Dice.FaceType[] facesType;
}
