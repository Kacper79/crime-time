using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFlatButton : MonoBehaviour {

	public void UpgradeSizeFlat(){
		UiManager.Instance.currentBuilding.GetComponent <FlatMechanics>().UpgradeSize ();
	}

	public void UpgradeEquipmentFlat(){
		UiManager.Instance.currentBuilding.GetComponent <FlatMechanics>().UpgradeEquipment ();
	}
    public void PurchaseActFlat()
    {
        UiManager.Instance.currentBuilding.GetComponent<FlatMechanics>().PurchaseAct();
    }
}
