﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlatMechanics : AssetMek
{

	public GameObject estate;
	public OpenPanel open;
	public bool isTaken = false;

	public short size = 0; //Max 4
	public int sizeBasePrice = 10000;
	public int sizePriceChange = 5000;

	public short equipment = 0; //Max 4
	public int equipmentBasePrice = 10000;
	public int equipmentPriceChange = 5000;
	public int value;
	//public bool owned = false;
	public int actprice = 10000;
	public int roomNA = 0;
	public Person owner;

	public GameObject moneyObject;
	void Start()
	{
		//moneyObject = UiManager.Instance.moneyDisplay;
	}
	public int GetValue(){
		int va = size * sizePriceChange + sizeBasePrice + equipment * equipmentPriceChange + equipmentBasePrice + actprice;
        if (estate != null)
        {
            va *= estate.GetComponent<EstateMek>().estateMultiplier;
        }
		return va;
	}
	public void UpgradeSize()
	{
		if (size < 5 && Manager.Instance.cash >= (sizeBasePrice + sizePriceChange * size) && owner == PlayerManager.Instance.player)
		{
			Manager.Instance.decreaseCash(sizeBasePrice + sizePriceChange * size);
			size++;
		}
	}
	public void UpgradeEquipment()
	{
		if (equipment < 5 && Manager.Instance.cash >= (equipmentBasePrice + equipmentPriceChange * equipment) && owner == PlayerManager.Instance.player)
		{
            Manager.Instance.decreaseCash(equipmentBasePrice + equipmentPriceChange * equipment);
			equipment++;
		}
	}
	public void PurchaseAct()
	{
		if (owner != PlayerManager.Instance.player && Manager.Instance.cash >= actprice)
		{
			Manager.Instance.decreaseCash(actprice);
            owner = PlayerManager.Instance.player;

            PlayerManager.Instance.AddAsset(gameObject);
		}
	}
	public void Rent()
	{
		var validJobs = from job in PlayerManager.Instance.jobs
			                                         where job.Jobtype == JobType.Flat_RentHouse
						select job;
		if (validJobs.Count() == 0)
		{
			Debug.Log("Open job panel");
		}
	}


	/*void OnMouseDown()
	{
		if (!UiManager.Instance.flatClose.animating)
		{
			if (UiManager.Instance.currentBuilding != gameObject)
			{
				UiManager.Instance.flatUI.SetActive(false);
				UiManager.Instance.currentBuilding = gameObject;
				UiManager.Instance.SetFlatValues();
			}
			else
			{
				UiManager.Instance.currentBuilding = null;
				UiManager.Instance.flatClose.Close();
			}
			UiManager.Instance.flatUI.SetActive(true);
		}

	}*/
}
