﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatMechanics : MonoBehaviour {
	public short size = 1; //Max 5
	public short equpment = 1; //Max 5
	public bool isTaken = false;
	//public int s1uc = 5000;
	public int s2uc = 10000;
	public int s3uc = 15000;
	public int s4uc = 20000;
	public int s5uc = 25000;
	public int e1uc = 5000;
	public int e2uc = 10000;
	public int e3uc = 15000;
	public int e4uc = 20000;
	public int e5uc = 25000;
	public int uacc;
	public GameObject moneyObject;
	void Start(){
		GetComponent <Building>().type = BuildingType.Flat;
	}

	void Update(){
		uacc = moneyObject.GetComponent<MoneyIndicator> ().cash;
	}
	// Update is called once per frame
	public void UpgradeSize() {
		if (size <= 5) {
			Debug.Log ("B"+size);
			if(size == 4 && uacc >= s5uc){
				moneyObject.GetComponent<MoneyIndicator> ().decreaseCash (s5uc);
				size++;
			}
			if(size == 3 && uacc >= s4uc){
				moneyObject.GetComponent<MoneyIndicator> ().decreaseCash (s4uc);
				size++;
			}
			if(size == 2 && uacc >= s3uc){
				moneyObject.GetComponent<MoneyIndicator> ().decreaseCash (s3uc);
				size++;
			}
			if(size == 1 && uacc >= s2uc){
				moneyObject.GetComponent<MoneyIndicator> ().decreaseCash (s2uc);
				size++;
			}
			Debug.Log ("A"+size);
		} else {
			Debug.Log ("Max size is 5 you can't upgrade more.Seems like you very prestige owner");
		}
	}
	public void UpgradeEquipment() {
		if (equpment <= 4) {
			if(equpment == 0 && uacc >= e1uc){
				uacc =- e1uc;
				equpment++;
			}
			if(equpment == 1 && uacc >= e2uc){
				uacc =- e2uc;
				equpment++;
			}
			if(equpment == 2 && uacc >= e3uc){
				uacc =- e3uc;
				equpment++;
			}
			if(equpment == 3 && uacc >= e4uc){
				uacc =- e4uc;
				equpment++;
			}
			if(equpment == 4 && uacc >= e5uc){
				uacc =- e5uc;
				equpment++;
			}
		} else {
			Debug.Log ("Max size is 5 you can't upgrade more.Seems like you very prestige owner");
		}
	}

	void OnMouseDown(){
		UiManager.Instance.flatUI.SetActive (!UiManager.Instance.flatUI.activeSelf);
	}
}
