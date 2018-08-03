
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{

	FlatMechanics Building;
	public GameObject flatUI;
	public TMP_Text[] FlatTexts;
	public GameObject currentBuilding;
	public static UiManager Instance;
	public GameObject moneyDisplay;
	public PanelClose flatClose;

	void Start()
	{
		if (Instance == null)
		{
			Instance = this; ;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;


		FlatTexts = flatUI.GetComponentsInChildren<TMP_Text>();
	}

	public void SetFlatValues()
	{
		FlatMechanics flat = currentBuilding.GetComponent<FlatMechanics>();
		if (flat.owned == true)
		{
			FlatTexts[7].text = "Act of ownership T";
		}
		else
		{
			FlatTexts[7].text = "Act of ownership F";
		}

		FlatTexts[1].text = "Size: " + flat.size;
		FlatTexts[2].text = "Equipment Quality: " + flat.equipment;
		FlatTexts[3].text = "Occupied:" + flat.isTaken;
		FlatTexts[4].text = "Upgrade Size " + (flat.sizeBasePrice + flat.size * flat.sizePriceChange);
		FlatTexts[5].text = "Upgrade Equipment";
		FlatTexts[6].text = "Rent Criminal " + (flat.equipmentBasePrice + flat.equipment * flat.equipmentPriceChange);
	}

	void Update()
	{
		if (currentBuilding != null && currentBuilding.GetComponent<InteractableObject>().type == ObjectType.flat && Manager.Instance.state == GameState.BigPanel)
		{
			SetFlatValues();
		}

	}

	public void openPanel(ObjectType type)
	{
		if (type == ObjectType.flat)
		{
			flatUI.SetActive(true);
		}
	}

	public void closePanel(ObjectType type)
	{
		if (type == ObjectType.flat)
		{
			flatUI.SetActive(false);
			SetFlatValues();
		}
	}
}