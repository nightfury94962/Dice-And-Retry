using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Dice And Retry/Dice Data")]
public class DiceData : ScriptableObject
{
    public string diceName;
    public string description;
    public GameObject diceModel;
    public float life;
    public int numberOfFaces;
    public Dice.DiceType type;
}
