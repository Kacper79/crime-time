using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstateMek : MonoBehaviour
{

	public GameObject[] flats;
	public int estateMultiplier;//you can name it prestige tax

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void Confiscate()
	{
		foreach (GameObject g in flats)
		{
			FlatMechanics f = g.GetComponent<FlatMechanics>();
			f.equipment = 0;
			f.size = 1;
			//f.act = false;
			//show loss panel
		}
	}

}
