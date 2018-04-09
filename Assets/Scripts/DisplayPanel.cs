using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {
	public static  GameObject fb = null;
	public static void enable(GameObject panel){
		panel.SetActive (true);


	}
	public static void disable(GameObject panel){
		panel.SetActive (false);
		Button[] buttons = panel.GetComponentsInChildren <Button>();
		buttons [0].onClick.RemoveListener (flatb1);
		buttons [1].onClick.RemoveListener (flatb2);

	}
	public static void GeneratePanelForBuilding(GameObject forBuilding,GameObject panel){
		if(forBuilding.name.Contains("Flat")){
			fb = forBuilding;
			Text[] texts = panel.GetComponentsInChildren<Text> ();
			//Debug.Log (texts.Length);
			texts [0].text = "Flats";
			texts [1].text = "Size <b>"+fb.GetComponent<FlatMechanics>().size+"</b>";
			texts [2].text = "Eqipment <b>"+fb.GetComponent<FlatMechanics>().equpment+"</b>";
			texts [3].text = "isTaken <b>"+fb.GetComponent<FlatMechanics>().isTaken+"</b>";
			texts [4].text = "Upgrade Size";
			texts [5].text = "Upgrade Equipment";
			texts [6].text = "Rent Criminal";
			Button[] buttons = panel.GetComponentsInChildren <Button>();
			buttons [0].onClick.AddListener (flatb1);
			buttons [1].onClick.AddListener (flatb2);
		}
	}
	public static void flatb1(){
		Debug.Log("Flat 1st button");
		fb.GetComponent<FlatMechanics> ().UpgradeSize ();
	}
	public static void flatb2(){
		fb.GetComponent<FlatMechanics> ().UpgradeEquipment ();
	}

		
}
