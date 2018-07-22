using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class WebJob : MonoBehaviour
{

	// Use this for initialization
	public string clientName;
	public bool done;


	public JOB_TYPE Jobtype;
	public int price;

	public GameObject panel;

	void Start()
	{
		Debug.Log("Start");
		ConstructUI();
	}

	public void ConstructUI()
	{
		TMP_Text[] texts = panel.GetComponentsInChildren<TMP_Text>();

		//GameObject g = Instantiate(proto);

		//Text[] texts = panel.GetComponentsInChildren<Text>();
		texts[0].text = clientName;
		texts[1].text = Jobtype.ToString();
		texts[2].text = price.ToString();
	}
}
public enum JOB_TYPE
{
	Criminal_house,
	Rent_house
}