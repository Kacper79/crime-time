﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatMechanics : MonoBehaviour {
	public short size = 1; //Max 5
	public short equipment = 1; //Max 5
    public bool act = false;
    public int occupied = 0;
    public int maxOccupied = 2;
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
    public int apc = 100000;
	public int uacc;
	public GameObject moneyObject;
	void Start(){
        moneyObject = UiManager.Instance.moneyDisplay;
	}

	void Update(){
		uacc = moneyObject.GetComponent<MoneyIndicator> ().cash;
        maxOccupied = 2 ^ size;
	}
	// Update is called once per frame
	public void UpgradeSize() {
		if (size <= 5 && act == true) {
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

		} else { 
		}
	}
	public void UpgradeEquipment() {
		if (equipment <= 4 && act == true) {
            if (equipment == 4 && uacc >= e5uc)
            {
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(e5uc);
                equipment++;
            }
            if (equipment == 3 && uacc >= e4uc)
            {
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(e4uc);
                equipment++;
            }
            if (equipment == 2 && uacc >= e3uc)
            {
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(e3uc);
                equipment++;
            }
            if (equipment == 1 && uacc >= e2uc)
            {
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(e2uc);
                equipment++;
            }
            if (equipment == 0 && uacc >= e1uc){
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(e1uc);
                equipment++;
			}
		} else {
		}
	}
    public void PurchaseAct()
    {
        if(act == false)
        {
            if (uacc >= apc)
            {
                moneyObject.GetComponent<MoneyIndicator>().decreaseCash(apc);
                act = true;
            }
        }
       
    }
	void OnMouseDown(){
        if(UiManager.Instance.isOnceOpened() == false)
        {
            UiManager.Instance.currentBuilding = gameObject;
            UiManager.Instance.flatUI.SetActive(true);
            UiManager.Instance.SetFlatValues();
            UiManager.Instance.setOnceOpened(true);
        }
		       
    }
    
	
}
