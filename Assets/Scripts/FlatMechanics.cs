using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatMechanics : MonoBehaviour
{


	public bool isTaken = false;

	public short size = 0; //Max 4
	public int sizeBasePrice = 10000;
	public int sizePriceChange = 5000;

	public short equipment = 0; //Max 4
	public int equipmentBasePrice = 10000;
	public int equipmentPriceChange = 5000;


	public GameObject moneyObject;
	void Start()
	{
		moneyObject = UiManager.Instance.moneyDisplay;
	}

	// Update is called once per frame
	public void UpgradeSize()
	{
		if (size < 5 && Manager.Instance.cash >= (sizeBasePrice + sizePriceChange * size))
		{
			Manager.Instance.decreaseCash(sizeBasePrice + sizePriceChange * size);
			size++;
		}
	}
	public void UpgradeEquipment()
	{
		if (equipment < 5 && Manager.Instance.cash >= (equipmentBasePrice + equipmentPriceChange * equipment))
		{
			Manager.Instance.decreaseCash(equipmentBasePrice + equipmentPriceChange * equipment);
			equipment++;
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
