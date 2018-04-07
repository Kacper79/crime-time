using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatMechanics : MonoBehaviour {
	public short size = 1; //Max 5
	public short equpment = 1; //Max 5
	public bool isTaken = false;
	
	// Update is called once per frame
	void UpgradeSize() {
		if (size <= 5) {
			size++;
		} else {
			Debug.Log ("Max size is 5 you can't upgrade more.Seems like you very prestige owner");
		}
	}
	void UpgradeEquipment() {
		if (equpment <= 5) {
			equpment++;
		} else {
			Debug.Log ("Max size is 5 you can't upgrade more.Seems like you very prestige owner");
		}
	}
}
