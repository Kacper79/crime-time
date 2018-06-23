using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour {

	FlatMechanics Building;
	public GameObject flatUI;
	public TextMeshProUGUI[] FlatTexts;
	public GameObject currentBuilding;
	public static UiManager Instance;
	public GameObject moneyDisplay;
	public PanelClose flatClose;

	void Start () {
		Instance = this;
		FlatTexts = flatUI.GetComponentsInChildren <TextMeshProUGUI>();

		//FlatTexts [4].text = "Upgrade Size";
		//FlatTexts [5].text = "Upgrade Equipment";
		//FlatTexts [6].text = "Rent Criminal";
	}

	public void SetFlatValues(){
        FlatTexts[3].text = "<#FF0000>S</color>IZE <b>" + currentBuilding.GetComponent<FlatMechanics>().size + "</b>";
        FlatTexts[1].text = "<#FF0000>Q</color>UALITY <b> " + currentBuilding.GetComponent<FlatMechanics>().equipment + "</b>";
        //FlatTexts [3].text = "Occupied:" + currentBuilding.GetComponent <FlatMechanics> ().isTaken;
    }

	void Update(){
		if(currentBuilding != null && currentBuilding.GetComponent <Building>().type == BuildingType.Flat){
			FlatTexts [3].text = "<#FF0000>S</color>IZE <b>" + currentBuilding.GetComponent <FlatMechanics> ().size + "</b>";
			FlatTexts [1].text = "<#FF0000>Q</color>UALITY <b> " + currentBuilding.GetComponent <FlatMechanics> ().equipment + "</b>";
			//FlatTexts [3].text = "Occupied: " + currentBuilding.GetComponent <FlatMechanics> ().isTaken;
		}
	}
	
	
}
public enum BuildingType
{
	Flat,
	Bank
}
