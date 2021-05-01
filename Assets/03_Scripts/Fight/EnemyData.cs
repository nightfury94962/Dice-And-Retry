using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Dice And Retry/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string name;
    public int life;
    public Sprite[] sprites;

    public DiceData[] customDice;

    public int[] randomDiceCount = new int[3];
}
