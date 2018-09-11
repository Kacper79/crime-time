
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
			FlatTexts[5].text = "Act of ownership T";
		}
		else
		{
			FlatTexts[5].text = "Act of ownership F";
		}

		FlatTexts[3].text = "SIZE  <b>" + flat.size + "</b>";
		FlatTexts[1].text = "QUALITY <b>: " + flat.equipment + "</b>";
		//FlatTexts[].text = "Occupied:" + flat.isTaken;
		FlatTexts[4].text = "Upgrade";// + (flat.sizeBasePrice + flat.size * flat.sizePriceChange);
		FlatTexts[2].text = "Upgrade";
		FlatTexts[9].text = "OccupiedD <b>" + flat.roomNA + "/" + 8 * flat.size  + "</b>";
		FlatTexts[6].text = "Purchase";
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
			SetFlatValues();
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
	public int power(int n,int e){
		int r = 1;      
		if(e==5){
			r = n * n * n * n * n;
		}
		if (e == 4)
        {
            r = n * n * n * n;
        }
		if (e == 3)
        {
            r = n * n * n;
        }
		if (e == 2)
        {
            r = n * n;
        }
		if (e == 1)
        {
            r = n;
        }
		return n;
	}
}