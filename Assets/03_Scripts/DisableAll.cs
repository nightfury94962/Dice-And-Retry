using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAll : MonoBehaviour
{
	private void Awake()
	{
		foreach(GameObject _go in gameObject.scene.GetRootGameObjects())
		{
			if (_go != gameObject)
			{
				_go.SetActive(false);
			}
		}
		Destroy(gameObject);
	}
}
