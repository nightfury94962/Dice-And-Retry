using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizeRandom : MonoBehaviour
{
    public static float RandomNum(float mean, float stdDev)
	{
		Random rand = new Random(); //reuse this if you are generating many
		float u1 = 1.0f - Random.value; //uniform(0,1] random doubles
		float u2 = 1.0f - Random.value;
		float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
		Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
		float randNormal = mean + stdDev * randStdNormal;
		return randNormal;
	}
}
