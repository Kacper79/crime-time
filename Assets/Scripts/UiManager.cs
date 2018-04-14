using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {

	FlatMechanics Building;
	public GameObject flatUI;
	public Text[] FlatTexts;
	public GameObject currentBuilding;
	public static UiManager Instance;

	void Start () {
		Instance = this;
		FlatTexts = flatUI.GetComponentsInChildren <Text>();

		FlatTexts [4].text = "Upgrade Size";
		FlatTexts [5].text = "Upgrade Equipment";
		FlatTexts [6].text = "Rent Criminal";
	}
	
	
}
public enum BuildingType
{
	Flat,
	Bank
}
