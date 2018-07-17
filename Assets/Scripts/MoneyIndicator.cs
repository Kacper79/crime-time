using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyIndicator : MonoBehaviour
{

	// Use this for initialization
	public Text text;

	void Start()
	{
		text.text = "$0";
	}

	// Update is called once per frame
	void Update()
	{
		text.text = "" + Manager.Instance.cash;
	}

}
