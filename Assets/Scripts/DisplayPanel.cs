using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {

	public static void enable(GameObject panel){
		panel.SetActive (true);
	}
	public static void disable(GameObject panel){
		panel.SetActive (false);
	}
	public static void GeneratePanelForBuilding(GameObject forBuilding,GameObject panel){
		if(forBuilding.name.Contains("Hotel")){
			Text[] texts = panel.GetComponents<Text> ();
			Debug.Log (texts.Length);
			texts [0].text = "Flats";
			texts [1].text = "Size <b>"+forBuilding.GetComponent<FlatMechanics>().size+"</b>";
			texts [2].text = "Eqipment <b>"+forBuilding.GetComponent<FlatMechanics>().equpment+"</b>";
			texts [3].text = "isTaken <b>"+forBuilding.GetComponent<FlatMechanics>().isTaken+"</b>";
			Button button = panel.GetComponent<Button> ();
			button.GetComponentInChildren<Text> ().text = "Rent criminal";
		}
	}
		
}
