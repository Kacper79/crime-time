using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour
{
	public static GameObject fb = null;
	public static void enable(GameObject panel)
	{
		panel.SetActive(true);


	}
	public static void disable(GameObject panel)
	{
		panel.SetActive(false);
		Button[] buttons = panel.GetComponentsInChildren<Button>();
		buttons[0].onClick.RemoveListener(FlatButton1);
		buttons[1].onClick.RemoveListener(FlatButton2);

	}
	public static void GeneratePanelForBuilding(GameObject forBuilding, GameObject panel)
	{
		if (forBuilding.name.Contains("Flat"))
		{
			fb = forBuilding;
			Text[] texts = panel.GetComponentsInChildren<Text>();
			//Debug.Log (texts.Length);

			FlatMechanics flatAttributes = fb.GetComponent<FlatMechanics>();

			texts[0].text = "Flats";
			texts[1].text = "Size <b>" + flatAttributes.size + "</b>";
			texts[2].text = "Eqipment <b>" + flatAttributes.equipment + "</b>";
			texts[3].text = "isTaken <b>" + flatAttributes.isTaken + "</b>";
			texts[4].text = "Upgrade Size " + (flatAttributes.sizeBasePrice + flatAttributes.sizeBasePrice * flatAttributes.size);
			texts[5].text = "Upgrade Equipment " + (flatAttributes.sizeBasePrice + flatAttributes.sizeBasePrice * flatAttributes.size);
			texts[6].text = "Rent Criminal";
			Button[] buttons = panel.GetComponentsInChildren<Button>();
			buttons[0].onClick.AddListener(FlatButton1);
			buttons[1].onClick.AddListener(FlatButton2);
		}
	}
	public static void FlatButton1()
	{
		fb.GetComponent<FlatMechanics>().UpgradeSize();
	}
	public static void FlatButton2()
	{
		fb.GetComponent<FlatMechanics>().UpgradeEquipment();
	}


}
