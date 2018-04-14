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
	public GameObject moneyDisplay;

	void Start () {
		Instance = this;
		FlatTexts = flatUI.GetComponentsInChildren <Text>();

		FlatTexts [4].text = "Upgrade Size";
		FlatTexts [5].text = "Upgrade Equipment";
		FlatTexts [6].text = "Rent Criminal";
	}

	public void SetFlatValues(){
		FlatTexts [1].text = "Size: " + currentBuilding.GetComponent <FlatMechanics> ().size;
		FlatTexts [2].text = "Equipment Quality: " + currentBuilding.GetComponent <FlatMechanics> ().equipment;
		FlatTexts [3].text = "Taken: " + currentBuilding.GetComponent <FlatMechanics> ().isTaken;
	}
	
	
}
public enum BuildingType
{
	Flat,
	Bank
}
