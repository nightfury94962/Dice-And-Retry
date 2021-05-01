using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Dice And Retry/Dice Data")]
public class DiceData : ScriptableObject
{
    public int id;
    public string nom;
    public string description;
    public Sprite image;
    public float nb_utilisation;
    public int nb_face;
    public Dice.DiceType type;
}
