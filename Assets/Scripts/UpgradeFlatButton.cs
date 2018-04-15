using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFlatButton : MonoBehaviour {

	public void UpgradeSize(){
		UiManager.Instance.currentBuilding.GetComponent <FlatMechanics>().UpgradeSize ();
	}

	public void UpgradeEquipment(){
		UiManager.Instance.currentBuilding.GetComponent <FlatMechanics>().UpgradeEquipment ();
	}
}
